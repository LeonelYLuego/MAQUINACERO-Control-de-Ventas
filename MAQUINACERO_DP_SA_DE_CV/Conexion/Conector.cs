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
    class Conector
    {
        private SqlConnection con = new SqlConnection("server=BALTA;database=MAQUINACERO;Trusted_Connection=True;");
        public SqlConnection connectSQL()
        {
            if (con.State == ConnectionState.Closed)
            {
                try
                {
                    con.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return con;
        }
        public void disConnectSQL()
        {
            if (con.State == ConnectionState.Open)
            {
                try
                {
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public SqlConnection getConexionSQL()
        {
            return con;
        }
    }
}
