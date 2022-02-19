using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MAQUINACERO_DP_SA_DE_CV.Conexion;

namespace MAQUINACERO_DP_SA_DE_CV.Clases
{
    class CAlmacen : ClaseBase
    {
        private String tipo, forma;
        private float densidad, medida, conversion, kilogramos;

        public CAlmacen() { }

        public DataTable VisualizarAlmacen()
        {
            String consult = "SELECT p.Codigo, f.Tipo, f.Descripcion as Forma, ma.Descripcion as Material, p.Medida, me.Descripcion as Unidad, p.meComercial as'Comercial', me2.Descripcion as 'Unidad comercial', p.Precio, p.Ubicacion, a.Kilogramos FROM Almacen as a INNER JOIN Producto as p ON a.Codigo = p.Codigo INNER JOIN Forma as f ON f.ID_forma = p.ID_forma INNER JOIN Material as ma ON p.ID_material = ma.ID_material INNER JOIN Medida as me ON me.ID_medida = p.ID_medida INNER JOIN Medida as me2 ON me2.ID_medida = p.ID_medida2 ORDER BY f.Descripcion;";
            return CN.Consulta(consult);
        }

        public int Cantidad(String consult)
        {
            DataTable aux = CN.Consulta(consult);
            if (aux.Rows.Count > 0)
            {
                DataRow row = aux.Rows[0];
                return Int32.Parse(row["Piezas"].ToString());
            }
            return -1;
        }

        public float ObtenerMetros(String codigo)
        {
            DataTable datos = CN.Consulta("SELECT f.Tipo, f.Descripcion as Forma, ma.Densidad, p.Medida, me.Conversion, a.Kilogramos FROM Almacen as a INNER JOIN Producto as p ON a.Codigo = p.Codigo INNER JOIN Forma as f ON f.ID_forma = p.ID_forma INNER JOIN Material as ma ON p.ID_material = ma.ID_material INNER JOIN Medida as me ON me.ID_medida = p.ID_medida WHERE p.Codigo = '" + codigo + "';");
            if (datos.Rows.Count > 0)
            {
                DataRow row = datos.Rows[0];
                if ((row["Tipo"].ToString() != "BARRA") || (row["Forma"].ToString() != "REDONDO" && row["Forma"].ToString() != "CUADRADO" && row["Forma"].ToString() != "HEXAGONAL" && row["Forma"].ToString() != "SOLERA") || (row.IsNull("Conversion")))
                    return 0;
                tipo = row["Tipo"].ToString();
                forma = row["Forma"].ToString();
                densidad = float.Parse(row["Densidad"].ToString());
                conversion = float.Parse(row["Conversion"].ToString());
                kilogramos = float.Parse(row["Kilogramos"].ToString());
                String sMedida = row["Medida"].ToString(); int band = 0;
                for (int i = 0; i < sMedida.Length; i++)
                    if (sMedida[i] == ' ' || sMedida[i] == '/')
                        band = 1;
                    else if (sMedida[i] == 'x' || sMedida[i] == 'X')
                    {
                        band = 2;
                        break;
                    }
                    else if (sMedida[i] != ' ' && sMedida[i] != '/' && sMedida[i] != '.' && (sMedida[i] < '0' || sMedida[i] > '9') && (sMedida[i] != 'x' || sMedida[i] != 'X'))
                        return 0;
                if (band == 0)
                {
                    medida = float.Parse(row["Medida"].ToString());
                }
                else if (band == 1)
                {
                    medida = fraccion(sMedida);
                }
                else if(band == 2)
                {
                    if (forma != "SOLERA")
                        return 0;
                    int x = 0, xubi = 0;
                    for(int i = 0; i < sMedida.Length; i++)
                    {
                        if (sMedida[i] == 'x' || sMedida[i] == 'X')
                        {
                            x++;
                            xubi = i;
                        }
                    }
                    if (x != 1 || xubi == 0 || (xubi == sMedida.Length - 1))
                        return 0;
                    else if (sMedida[xubi + 1] != ' ' || sMedida[xubi - 1] != ' ')
                        return 0;
                    String aux = "";
                    for(int i = 0; i < (xubi - 1); i++)
                    {
                        aux += sMedida[i];
                    }
                    medida = fraccion(aux) * conversion;
                    aux = "";
                    for (int i = (xubi + 2); i < sMedida.Length; i++)
                    {
                        aux += sMedida[i];
                    }
                    medida *= fraccion(aux) * conversion;
                }

                densidad *= 1000;
                if (forma != "SOLERA")
                    medida *= conversion;
                switch (forma)
                {
                    case "REDONDO":
                        medida /= 2;
                        medida = medida * medida * 3.141592653589f;
                        break;
                    case "CUADRADO":
                        medida = medida * medida;
                        break;
                    case "HEXAGONAL":
                        medida = ((6 * (medida * (0.5773502692f))) * (medida / 2)) / 2;
                        break;
                }
                medida *= densidad;
                return kilogramos / medida;
            }
            return 0;
        }

        protected float fraccion(String numero)
        {
            bool band = true;
            for (int i = 0; i < numero.Length; i++)
                if (numero[i] == ' ' || numero[i] == '/')
                    band = false;
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
            float n = float.Parse(numerador);
            float d = float.Parse(denominador);
            float e = entero == "" ? 0 : float.Parse(entero);
            return e + (n / d);
        }

        public float barras(String codigo, float metros)
        {
            DataTable datos = CN.Consulta("SELECT a.Kilogramos, p.meComercial, me.Descripcion FROM Almacen as a INNER JOIN Producto as p ON a.Codigo = p.Codigo INNER JOIN Medida as me ON p.ID_medida2 = me.ID_medida WHERE p.Codigo = '" + codigo + "';");
            if (datos.Rows.Count > 0)
            {
                DataRow row = datos.Rows[0];
                if(row["Descripcion"].ToString() == "KG")
                {
                    kilogramos = float.Parse(row["Kilogramos"].ToString());
                    medida = float.Parse(row["meComercial"].ToString());
                    return kilogramos / medida;
                }
            }
            if (metros == 0)
            return 0;
            datos = CN.Consulta("SELECT p.meComercial, me.Conversion FROM Producto AS p INNER JOIN Medida as me ON p.ID_medida2 = me.ID_medida WHERE p.Codigo = '" + codigo + "';");
            if (datos.Rows.Count > 0)
            {
                DataRow row = datos.Rows[0];
                if (row.IsNull("Conversion"))
                    return 0;
                conversion = float.Parse(row["Conversion"].ToString());
                String sMedida = row["meComercial"].ToString(); bool band = false;
                for (int i = 0; i < sMedida.Length; i++)
                    if (sMedida[i] == ' ' || sMedida[i] == '/')
                        band = true;
                    else if (sMedida[i] != ' ' && sMedida[i] != '/' && sMedida[i] != '.' && (sMedida[i] < '0' || sMedida[i] > '9'))
                        return 0;
                if (!band)
                {
                    medida = float.Parse(row["meComercial"].ToString());
                }
                else
                {
                    String entero = "", numerador = "", denominador = "";
                    for (int i = 0; i < sMedida.Length; i++)
                    {
                        if (sMedida[i] == ' ')
                            for (int j = (i - 1); j >= 0; j--)
                                entero += sMedida[j];
                        else if (sMedida[i] == '/')
                        {
                            for (int j = (i - 1); j >= 0; j--)
                            {
                                if (sMedida[j] == ' ')
                                    break;
                                numerador += sMedida[j];
                            }
                            for (int j = (i + 1); j < sMedida.Length; j++)
                            {
                                if (sMedida[j] == ' ')
                                    break;
                                denominador += sMedida[j];
                            }
                            break;
                        }

                    }
                    int n = Int32.Parse(numerador);
                    int d = Int32.Parse(denominador);
                    int e = entero == "" ? 1 : int.Parse(entero);
                    medida = (float)e * ((float)n / (float)d);
                }
                return metros / (medida * conversion);
            }
                return 0;
        }
    }
}
