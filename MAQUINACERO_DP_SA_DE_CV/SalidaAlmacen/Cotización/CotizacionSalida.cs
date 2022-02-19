using MAQUINACERO_DP_SA_DE_CV.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAQUINACERO_DP_SA_DE_CV.SalidaAlmacen.Cotización
{
    class CotizacionSalida : ClaseBase
    {
        public float obtenerKilogramos(String codigo)
        {
            DataTable tabla = CN.Consulta("SELECT Kilogramos FROM Almacen WHERE Codigo = '" + codigo + "';");
            if(tabla.Rows.Count > 0)
            {
                return float.Parse(tabla.Rows[0]["Kilogramos"].ToString());
            }
            return 0;
        }

        public DataTable obtenerUnidadSinConversion()
        {
            return CN.Consulta("SELECT Descripcion FROM Medida WHERE Conversion IS NOT NULL ORDER BY Descripcion;");
        }

        public bool obtenerUnidadFracciones(String texto)
        {
            bool var = false;
            DataTable aux = CN.Consulta("SELECT Fraccion FROM Medida WHERE Descripcion = '" + texto + "';");
            if (aux.Rows.Count > 0)
            {
                DataRow row = aux.Rows[0];
                if (row["Fraccion"].ToString() == "False")
                    var = false;
                else if (row["Fraccion"].ToString() == "True")
                    var = true;
            }
            return var;
        }

        public float obtenerConversionAMetros(String unidad)
        {
            DataTable tabla = CN.Consulta("SELECT Conversion FROM Medida WHERE Descripcion = '" + unidad + "' AND Conversion IS NOT NULL;");
            if(tabla.Rows.Count > 0)
            {
                return float.Parse(tabla.Rows[0]["Conversion"].ToString());
            }
            return 0;
        }

        public float obtenerPrecioCorte(String codigo)
        {
            DataTable tabla = CN.Consulta("SELECT pc.Precio FROM PrecioCorte as pc INNER JOIN Material as ma ON pc.ID_grupo = ma.ID_grupo INNER JOIN Producto as p  ON p.ID_material = ma.ID_material WHERE p.ID_forma = pc.ID_forma AND p.Medida = pc.Medida AND p.Codigo = '" + codigo + "';");
            if (tabla.Rows.Count > 0)
            {
                return float.Parse(tabla.Rows[0]["Precio"].ToString());
            }
            return 0;
        }

        public float obtenerPrecioPorKilogramos(String codigo)
        {
            DataTable tabla = CN.Consulta("SELECT Precio FROM Producto WHERE Codigo = '" + codigo + "';");
            if (tabla.Rows.Count > 0)
            {
                return float.Parse(tabla.Rows[0]["Precio"].ToString());
            }
            return 0;
        }

        public int obtenerPorcentaje(int ID_grupoPrecio)
        {
            DataTable tabla = CN.Consulta("SELECT Porcentaje FROM GrupoPrecio WHERE ID_grupoPrecio = " + ID_grupoPrecio + ";");
            if (tabla.Rows.Count > 0)
            {
                return int.Parse(tabla.Rows[0]["Porcentaje"].ToString());
            }
            return -1;
        }

        public float obtenerPrecioDolar()
        {
            DateTime dateTime = new DateTime();
            dateTime = DateTime.Now;
            string strDate = Convert.ToDateTime(dateTime).ToString("yyyy-MM-dd");
            DataTable tabla = CN.Consulta("SELECT Precio From Dolar WHERE Fecha = '" + strDate + "';");
            if (tabla.Rows.Count > 0)
            {
                return float.Parse(tabla.Rows[0]["Precio"].ToString());
            }
            return 0;
        }

        public bool agregarCotizacionSalida(DataTable tabla, String codigo, int tipoMaterial, TextBox txtKilogramos, CheckBox checkPiezas, NumericUpDown numPiezas, TextBox txtMedidaPieza, ComboBox cmbUnidadPieza, TextBox txtPrecioCorte, TextBox txtPrecioTotalCorte, ComboBox cmbCriterio, TextBox txtPrecio, TextBox txtPrecioMXN, NumericUpDown numCortes)
        {
            DataRow row = tabla.NewRow();
            DataTable aux = CN.Consulta("SELECT p.Codigo, f.Tipo, f.Descripcion as Forma, ma.Descripcion as Material, p.Medida, me.Descripcion as Unidad, p.meComercial as 'Comercial', me2.Descripcion as 'Unidad comercial', p.Precio, p.Ubicacion FROM Producto as p inner join Forma as f on p.ID_forma = f.ID_forma inner join Material as ma on ma.ID_material = p.ID_material inner join Medida as me on p.ID_medida = me.ID_medida inner join Medida as me2 on me2.ID_medida = p.ID_medida2 WHERE p.Codigo = '" + codigo + "' ORDER BY f.Descripcion;");
            if(aux.Rows.Count <= 0)
            {
                MessageBox.Show("Error: producto no encontrado");
                return false;
            }
            for(int i = 0; i < 10; i++)
                row[i] = aux.Rows[0][i];
            float kilogramos = this.obtenerKilogramos(codigo);
            row["Kilogramos Almacen"] = kilogramos;
            switch (tipoMaterial)
            {
                case 1:
                    row["Tramos Completos Almacen"] = kilogramos / obtenerKilogramosPorPieza(codigo);
                    break;
                case 2:
                    row["Metros Almacen"] = kilogramos / obtenerKilogramosPorMetro(codigo);
                    row["Tramos Completos Almacen"] = (kilogramos / obtenerKilogramosPorMetro(codigo)) / obtenerCantidadPorMetros(codigo);
                    break;
            }
            kilogramos = float.Parse(txtKilogramos.Text);
            row["Kilogramos Cotizacion"] = kilogramos;
            switch (tipoMaterial)
            {
                case 1:
                    row["Tramos Completos Cotizacion"] = kilogramos / obtenerKilogramosPorPieza(codigo);
                    break;
                case 2:
                    row["Metros Cotizacion"] = kilogramos / obtenerKilogramosPorMetro(codigo);
                    row["Tramos Completos Cotizacion"] = (kilogramos / obtenerKilogramosPorMetro(codigo)) / obtenerCantidadPorMetros(codigo);
                    break;
            }
            row["Piezas"] = (int) numPiezas.Value;
            if (checkPiezas.Checked && numPiezas.Value > 1)
            {
                row["Medida Pieza"] = txtMedidaPieza.Text;
                row["Unidad Pieza"] = cmbUnidadPieza.Text;
            }
            if (txtPrecioCorte.Text != "")
                row["Precio Por Corte"] = float.Parse(txtPrecioCorte.Text);
            else
                row["Precio Por Corte"] = 0;
            row["Num. Cortes"] = (int) numCortes.Value;
            row["Precio Total Corte"] = float.Parse(txtPrecioTotalCorte.Text);
            row["Criterio"] = cmbCriterio.SelectedItem.ToString();
            row["Precio Cotizacion"] = float.Parse(txtPrecio.Text);
            if (this.obtenerPrecioDolar() != 0)
                row["Precio Cotizacion MXN"] = float.Parse(txtPrecioMXN.Text);
            tabla.Rows.Add(row);
            return true;
        }

        public void modificarCriterios(int ID_grupoPrecio, float porcentaje)
        {
            CN.Consulta("UPDATE GrupoPrecio SET Porcentaje = " + porcentaje + " WHERE ID_grupoPrecio = " + ID_grupoPrecio + ";");
        }

        public float obtenerMedidaComercial(String codigo)
        {
            DataTable tabla = CN.Consulta("SELECT p.meComercial, me.Conversion FROM Producto as p INNER JOIN Medida as me ON p.ID_medida2 = me.ID_medida WHERE p.Codigo = '" + codigo + "' AND me.Conversion IS NOT NULL;");
            if(tabla.Rows.Count > 0)
            {
                float a = float.Parse(tabla.Rows[0]["meComercial"].ToString());
                float b = float.Parse(tabla.Rows[0]["Conversion"].ToString());
                return a * b;
            }
            return 0;
        }

        public float obtenerKilogramosPieza(String codigo)
        {
            int tipoMaterial = this.obtenerTipoMaterial(codigo);
            switch (tipoMaterial)
            {
                case 1:
                    return obtenerKilogramosPorPieza(codigo);
                case 2:
                    float kilosPorMetro = obtenerKilogramosPorMetro(codigo);
                    float meComercial = obtenerMedidaComercial(codigo);
                    return meComercial * kilosPorMetro;
                default:
                    return 0;
            }
        }

        public float obtenerPrecioPieza(String codigo)
        {
            DataTable tabla = CN.Consulta("SELECT Precio From Producto WHERE Codigo = '" + codigo + "';");
            if(tabla.Rows.Count > 0)
            {
                return float.Parse(tabla.Rows[0]["Precio"].ToString());
            }
            return 0;
        }

        public int obtenerGrupoPrecio(String descripcion)
        {
            switch (descripcion)
            {
                case "Criterio 1":
                    return 0;
                case "Criterio 2":
                    return 1;
                case "Criterio 3":
                    return 2;
                case "A negociar":
                    return 3;
            }
            return -1;
        }

        public float obtenerPrecio(String codigo, int ID_grupoPrecio)
        {
            float precio = obtenerPrecioPieza(codigo);
            if (ID_grupoPrecio != 3)
            {
                float porcentaje = obtenerPorcentaje(ID_grupoPrecio) / 100f;
                precio = precio + (precio * porcentaje);
            }
            return precio;
        }
    }
}
