using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MAQUINACERO_DP_SA_DE_CV.Conexion;
using System.Windows.Forms;

namespace MAQUINACERO_DP_SA_DE_CV.SalidaAlmacen
{
    class PrecioCorte
    {
        private Consultas CN = new Consultas();

        public static DataTable select()
        {
            Consultas CN = new Consultas();
            DataTable tabla = CN.Consulta("SELECT pc.ID_precio, f.Tipo as Forma, f.Descripcion, g.ID_grupo as 'Grupo corte', pc.Medida, pc.Precio FROM PrecioCorte as pc INNER JOIN Forma as f ON pc.ID_forma = f.ID_forma INNER JOIN Grupo as g ON g.ID_grupo = pc.ID_grupo ORDER BY f.Descripcion, pc.Medida;");
            DataTable aux = tabla;
            aux.Columns.Remove("ID_precio");
            return aux;
        }

        public bool insert(String tipo, String forma, String medida, int id_grupo, float precio)
        {
            DataTable tabla = CN.Consulta("SELECT COUNT(*) as Cantidad FROM PrecioCorte as pc INNER JOIN Forma as f ON f.ID_forma = pc.ID_forma INNER JOIN Grupo as g ON pc.ID_grupo = g.ID_grupo WHERE f.Tipo = '" + tipo + "' and f.Descripcion " + (forma == "" ? "is null" : ("= '" + forma + '\'')) + " and g.ID_grupo = " + id_grupo + " and pc.Medida = '" + medida + "';");
            if (tabla.Rows[0]["Cantidad"].ToString() != "0")
            {
                MessageBox.Show("Error: precio de corte ya registrado");
                return false;
            }
            CN.Consulta("INSERT INTO PrecioCorte(ID_precio, ID_forma, ID_grupo, Medida, Precio) VALUES ((select max(ID_precio) from PrecioCorte) + 1, (select max(ID_forma) from Forma where Tipo = '" + tipo + "' and Descripcion " + (forma == "" ? "is null" : ("= '" + forma + '\'')) + "), " + id_grupo + ", '" + medida + "', " + precio + ");");
            return true;
        }

        public int buscarID_precio(String tipo, String forma, int id_grupo, String medida, float precio)
        {
            DataTable tabla = CN.Consulta("SELECT pc.ID_precio FROM PrecioCorte as pc INNER JOIN Forma as f ON f.ID_forma = pc.ID_forma INNER JOIN Grupo as g ON pc.ID_grupo = g.ID_grupo WHERE f.Tipo = '" + tipo + "' and f.Descripcion " + (forma == "" ? "is null" : ("= '" + forma + '\'')) + " and g.ID_grupo = " + id_grupo + " and pc.Medida = '" + medida + "';");
            if(tabla.Rows.Count > 0)
            {
                return int.Parse(tabla.Rows[0][0].ToString());
            }
            return -1;
        }

        public DataTable selectDatosConID(int ID_precio)
        {
            return CN.Consulta("SELECT f.Tipo, f.Descripcion as Forma, g.ID_grupo as 'Grupo corte', pc.Medida, pc.Precio FROM PrecioCorte as pc INNER JOIN Forma as f ON pc.ID_forma = f.ID_forma INNER JOIN Grupo as g ON g.ID_grupo = pc.ID_grupo WHERE pc.ID_precio = " + ID_precio + ";");
        }

        public void update(int ID_precio, float precio)
        {
            CN.Consulta("UPDATE PrecioCorte SET Precio = " + precio + " WHERE ID_precio = " + ID_precio + ";");
        }

        public void delete(int ID_precio)
        {
            CN.Consulta("DELETE FROM PrecioCorte WHERE ID_precio = " + ID_precio + ";");
        }
    };
}
