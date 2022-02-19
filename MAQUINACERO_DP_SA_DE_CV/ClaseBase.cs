using MAQUINACERO_DP_SA_DE_CV.Conexion;
using MAQUINACERO_DP_SA_DE_CV.Programa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAQUINACERO_DP_SA_DE_CV
{
    class ClaseBase
    {
        protected Consultas CN = new Consultas();
        private float medida, meComercial;
        
        public String obtenerDescripcion(String codigo)
        {
            DataTable tabla = CN.Consulta("SELECT f.Tipo, f.Descripcion as Forma, ma.Descripcion as Material, p.Medida, me.Descripcion as Unidad FROM Producto as p inner join Forma as f on p.ID_forma = f.ID_forma inner join Material as ma on ma.ID_material = p.ID_material inner join Medida as me on p.ID_medida = me.ID_medida inner join Medida as me2 on me2.ID_medida = p.ID_medida2 WHERE p.Codigo = '" + codigo + "';");
            if (tabla.Rows.Count > 0)
                return tabla.Rows[0]["Tipo"].ToString() + ' ' + tabla.Rows[0]["Forma"].ToString() + ' ' + tabla.Rows[0]["Material"].ToString() + ' ' + tabla.Rows[0]["Medida"].ToString() + ' ' + tabla.Rows[0]["Unidad"].ToString();
            else
            {
                if (MessageBox.Show("Producto no encontrado\n¿Desesas agregarlo?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    Agregar_producto ap = new Agregar_producto(false, "");
                    ap.StartPosition = FormStartPosition.CenterScreen;
                    ap.ShowDialog();
                    tabla = CN.Consulta("SELECT f.Tipo, f.Descripcion as Forma, ma.Descripcion as Material, p.Medida, me.Descripcion as Unidad FROM Producto as p inner join Forma as f on p.ID_forma = f.ID_forma inner join Material as ma on ma.ID_material = p.ID_material inner join Medida as me on p.ID_medida = me.ID_medida inner join Medida as me2 on me2.ID_medida = p.ID_medida2 WHERE p.Codigo = '" + codigo + "';");
                    if (tabla.Rows.Count > 0)
                        return tabla.Rows[0]["Tipo"].ToString() + ' ' + tabla.Rows[0]["Forma"].ToString() + ' ' + tabla.Rows[0]["Material"].ToString() + ' ' + tabla.Rows[0]["Medida"].ToString() + ' ' + tabla.Rows[0]["Unidad"].ToString();
                    else
                        return "";
                }
                else
                    return "";
            }
        }

        public int obtenerTipoMaterial(String codigo)
        {
            String tipo, forma;
            float densidad, conversion;
            DataTable datos = CN.Consulta("SELECT me.Conversion, a.Kilogramos, p.meComercial, me.Descripcion FROM Almacen as a RIGHT JOIN Producto as p ON a.Codigo = p.Codigo INNER JOIN Medida as me ON p.ID_medida2 = me.ID_medida WHERE p.Codigo = '" + codigo + "';");
            if (datos.Rows.Count > 0)
            {
                DataRow row = datos.Rows[0];
                if (row["Descripcion"].ToString() == "KG")
                {
                    medida = float.Parse(row["meComercial"].ToString());
                    return 1;
                }
                else if (row.IsNull("Conversion"))
                    return 0;
            }
            datos = CN.Consulta("SELECT f.Tipo, f.Descripcion as Forma, ma.Densidad, p.Medida, me.Conversion, a.Kilogramos FROM Almacen as a RIGHT JOIN Producto as p ON a.Codigo = p.Codigo INNER JOIN Forma as f ON f.ID_forma = p.ID_forma INNER JOIN Material as ma ON p.ID_material = ma.ID_material INNER JOIN Medida as me ON me.ID_medida = p.ID_medida WHERE p.Codigo = '" + codigo + "';");
            if (datos.Rows.Count > 0)
            {
                DataRow row = datos.Rows[0];
                if ((row["Tipo"].ToString() != "BARRA") || (row["Forma"].ToString() != "REDONDO" && row["Forma"].ToString() != "CUADRADO" && row["Forma"].ToString() != "HEXAGONAL" && row["Forma"].ToString() != "SOLERA" && row["Forma"].ToString() != "REDONDO HUECO") || (row.IsNull("Conversion")))
                {
                    return 0;
                }
                tipo = row["Tipo"].ToString();
                forma = row["Forma"].ToString();
                densidad = float.Parse(row["Densidad"].ToString());
                conversion = float.Parse(row["Conversion"].ToString());
                String sMedida = row["Medida"].ToString(); int band = 0;
                for (int i = 0; i < sMedida.Length; i++)
                    if (sMedida[i] == ' ' || sMedida[i] == '/')
                        band = 1;
                    else if (sMedida[i] == 'x' || sMedida[i] == 'X')
                    {
                        band = 2;
                        break;
                    }
                    else if (sMedida[i] != ' ' && sMedida[i] != '/' && sMedida[i] != '.' && (sMedida[i] < '0' || sMedida[i] > '9'))
                    {
                        return 0;
                    }
                if (band == 0)
                {
                    medida = float.Parse(row["Medida"].ToString());
                }
                else if (band == 1)
                {
                    medida = obtenerFraccion(sMedida);
                }
                else if (band == 2)
                {
                    int x = 0, xubi = 0;
                    for (int i = 0; i < sMedida.Length; i++)
                    {
                        if (sMedida[i] == 'x' || sMedida[i] == 'X')
                        {
                            x++;
                            xubi = i;
                        }
                    }
                    if (x != 1 || xubi == 0 || (xubi == sMedida.Length - 1))
                    {
                        return 0;
                    }
                    else if (sMedida[xubi + 1] != ' ' || sMedida[xubi - 1] != ' ')
                    {
                        return 0;
                    }
                    String aux = "";
                    for (int i = 0; i < (xubi - 1); i++)
                    {
                        aux += sMedida[i];
                    }
                    float medida1 = obtenerFraccion(aux) * conversion;
                    aux = "";
                    for (int i = (xubi + 2); i < sMedida.Length; i++)
                    {
                        aux += sMedida[i];
                    }
                    float medida2 = obtenerFraccion(aux) * conversion;
                    switch (forma)
                    {
                        case "SOLERA":
                            medida = medida1 * medida2;
                            break;
                        case "REDONDO HUECO":
                            medida1 /= 2;
                            medida1 = medida1 * medida1 * 3.141592653589f;
                            medida2 /= 2;
                            medida2 = medida2 * medida2 * 3.141592653589f;
                            if (medida1 > medida2)
                                medida = medida1 - medida2;
                            else if (medida2 > medida1)
                                medida = medida2 - medida1;
                            else
                                return 0;
                            break;
                        default:
                            return 0;
                    }
                }
                switch (forma)
                {
                    case "REDONDO":
                        medida *= conversion;
                        medida /= 2;
                        medida = medida * medida * 3.141592653589f;
                        break;
                    case "CUADRADO":
                        medida *= conversion;
                        medida = medida * medida;
                        break;
                    case "HEXAGONAL":
                        medida *= conversion;
                        medida = ((6 * (medida * (0.5773502692f))) * (medida / 2)) / 2;
                        break;
                }
                medida *= densidad * 1000;
                int Funcion = 2;
                datos = CN.Consulta("SELECT p.meComercial, me.Conversion FROM Producto as p INNER JOIN Medida as me ON p.ID_medida2 = me.ID_medida WHERE p.Codigo = '" + codigo + "';");
                if (datos.Rows.Count > 0)
                {
                    row = datos.Rows[0];
                    if (row.IsNull("Conversion"))
                    {
                        meComercial = 0;
                        return Funcion;
                    }
                    conversion = float.Parse(row["Conversion"].ToString());
                    sMedida = row["meComercial"].ToString(); bool band2 = false;
                    for (int i = 0; i < sMedida.Length; i++)
                        if (sMedida[i] == ' ' || sMedida[i] == '/')
                            band2 = true;
                        else if (sMedida[i] != ' ' && sMedida[i] != '/' && sMedida[i] != '.' && (sMedida[i] < '0' || sMedida[i] > '9'))
                        {
                            meComercial = 0;
                            return Funcion;
                        }
                    if (!band2)
                    {
                        meComercial = float.Parse(row["meComercial"].ToString());
                    }
                    else
                    {
                        meComercial = obtenerFraccion(sMedida);
                    }
                    meComercial = meComercial * conversion;
                    return Funcion;
                }
                meComercial = 0;
                return Funcion;
            }
            return 0;
        }

        public float obtenerFraccion(String numero)
        {
            if(numero.Length > 0)
            {
                if (numero[0] == ' ' || numero[0] == '/' || numero[numero.Length - 1] == ' ' || numero[numero.Length - 1] == '/')
                    return 0;
            }
            bool band = true;
            for (int i = 0; i < numero.Length; i++)
            {
                if (numero[i] == ' ' || numero[i] == '/')
                    band = false;
                if (numero[i] != ' ' && numero[i] != '/' && (numero[i] < '0' || numero[i] > '9'))
                    return 0;
            }
            if (band)
                return float.Parse(numero);
            String entero = "", numerador = "", denominador = "";
            for (int i = 0; i < numero.Length; i++)
            {
                if (numero[i] == ' ')
                    for (int j = (i - 1); j >= 0; j--)
                        entero += numero[j];
                else if (numero[i] == '/')
                {
                    for (int j = (i - 1); j >= 0; j--)
                    {
                        if (numero[j] == ' ')
                            break;
                        numerador += numero[j];
                    }
                    for (int j = (i + 1); j < numero.Length; j++)
                    {
                        if (numero[j] == ' ')
                            break;
                        denominador += numero[j];
                    }
                    break;
                }

            }
            if (numerador == "" || denominador == "")
                return 0;
            float n = float.Parse(numerador);
            float d = float.Parse(denominador);
            float e = entero == "" ? 0 : float.Parse(entero);
            return e + (n / d);
        }

        public float obtenerKilogramosPorMetro(String codigo)
        {
            if (obtenerTipoMaterial(codigo) == 2)
                return medida;
            else
                return 0;
        }

        public float obtenerKilogramosPorPieza(String codigo)
        {
            if (obtenerTipoMaterial(codigo) == 1)
                return medida;
            else
                return 0;
        }

        public float obtenerCantidadPorMetros(String codigo)
        {
            if (obtenerTipoMaterial(codigo) == 2)
                return meComercial;
            else
                return 0;
        }

        public bool validarFloat(char c, TextBox text)
        {
            if ((c < '0' || c > '9') && c != '\b' && c != '.')
            {
                return true;
            }
            int p = 0;
            for (int i = 0; i < text.TextLength; i++)
                if (text.Text[i] == '.')
                    p++;
            if (p >= 1 && c == '.')
                return true;
            else if(text.TextLength == 0 && c == '.')
                return true;
            return false;
        }

        public bool validarFraccion(char c, TextBox text)
        {
            if ((c < '0' || c > '9') && c != '/' && c != ' ' && c != '\b')
            {
                return true;
            }
            bool esp = false, dia = false;
            for (int i = 0; i < text.TextLength; i++)
            {
                if (text.Text[i] == ' ')
                    esp = true;
                else if (text.Text[i] == '/')
                    dia = true;
            }
            if (text.Text == "" && (c == ' ' || c == '/'))
                return true;
            if ((c == ' ' && esp) || (c == ' ' && dia) || (c == '/' && dia))
                return true;
            return false;
        }

        public bool validarLetras(char c, TextBox text, int limite)
        {
            if ((c < 'a' || c > 'z') && (c < 'A' || c > 'Z') && c != ' ' && c != '\b')
                return true;
            if (text.TextLength >= limite && c != '\b')
                return true;
            if (text.TextLength > 0)
                    if (text.Text[text.TextLength - 1] == ' ' && c == ' ')
                        return true;
            return false;
        }

        public bool validarUbicacionArchivo(char c, TextBox text)
        {
            if ((c < '0' || c > '9') && (c < 'a' || c > 'z') && (c < 'A' || c > 'Z') && c != '_' && c != '\b')
                return true;
            return false;
        }

        public bool comprobarDolar()
        {
            DateTime dateTime = new DateTime();
            dateTime = DateTime.Now;
            string strDate = Convert.ToDateTime(dateTime).ToString("yyyy-MM-dd");
            DataTable tabla = CN.Consulta("SELECT Precio From Dolar WHERE Fecha = '" + strDate + "';");
            if (tabla.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public String obtenerUbicacionArchivo(String ID_ubicacion)
        {
            DataTable tabla = CN.Consulta("SELECT Direccion FROM DireccionCarpeta WHERE ID_direccion = '" + ID_ubicacion + "';");
            if(tabla.Rows.Count > 0)
            {
                return tabla.Rows[0]["Direccion"].ToString();
            }
            return "";
        }
    }
}
