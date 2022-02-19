using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MAQUINACERO_DP_SA_DE_CV.Conexion
{
    class Consultas
    {
        private Conector CN = new Conector();
        private SqlCommand consult = new SqlCommand();
        private SqlDataReader leerFilas;

        public DataTable selectProducto()
        {
            DataTable tabla = new DataTable();
            try
            {
                consult.Connection = CN.connectSQL();
                consult.CommandText = "SELECT p.Codigo, f.Tipo, f.Descripcion as Forma, ma.Descripcion as Material, p.Medida, me.Descripcion as Unidad, p.meComercial as 'Comercial', me2.Descripcion as 'Unidad comercial', p.Precio, p.Ubicacion FROM Producto as p inner join Forma as f on p.ID_forma = f.ID_forma inner join Material as ma on ma.ID_material = p.ID_material inner join Medida as me on p.ID_medida = me.ID_medida inner join Medida as me2 on me2.ID_medida = p.ID_medida2 ORDER BY f.Descripcion;";
                //consult.CommandType = CommandType.StoredProcedure; //Solo para procedimientos
                leerFilas = consult.ExecuteReader();
                tabla.Load(leerFilas);
                leerFilas.Close();
                CN.disConnectSQL();
                return tabla;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public DataTable Consulta(String _consult)
        {
            DataTable tabla = new DataTable();
            try
            {
                consult.Connection = CN.connectSQL();
                consult.CommandText = _consult;
                //consult.CommandType = CommandType.StoredProcedure; //Solo para procedimientos
                leerFilas = consult.ExecuteReader();
                tabla.Load(leerFilas);
                leerFilas.Close();
                CN.disConnectSQL();
                return tabla;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

    }
}
