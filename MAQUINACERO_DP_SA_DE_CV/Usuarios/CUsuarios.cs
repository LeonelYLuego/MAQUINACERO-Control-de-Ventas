using MAQUINACERO_DP_SA_DE_CV.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAQUINACERO_DP_SA_DE_CV.Usuarios
{
    class CUsuarios
    {
        private Consultas CN = new Consultas();
        public bool ValidarContraseña(String Usuario, String Contraseña)
        {
            DataTable tabla = CN.Consulta("SELECT Usuario, Contraseña FROM Usuarios WHERE Usuario = '" + Usuario + "';");
            if(tabla.Rows.Count > 0)
            {
                if (tabla.Rows[0]["Usuario"].ToString() == Usuario && Contraseña == tabla.Rows[0]["Contraseña"].ToString())
                    return true;
            }
            return false;
        }

        public DataTable ObtenerUsuarios()
        {
            return CN.Consulta("SELECT Nombre FROM Usuarios WHERE ID_usuario != 0;");
        }

        public bool ValidarNombre(String nombre)
        {
            DataTable tabla = CN.Consulta("SELECT ID_usuario FROM Usuarios WHERE Nombre = '" + nombre + "';");
            if (tabla.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public void AgregarUsuario(String nombre, String usuario, String Contraseña)
        {
            CN.Consulta("INSERT INTO Usuarios(ID_usuario, Nombre, Usuario, Contraseña) VALUES ((select max (ID_usuario) FROM Usuarios) + 1, '" + nombre + "', '" + usuario + "', '" + Contraseña + "');");
        }

        public void EliminarUsuario(String Nombre)
        {
            CN.Consulta("DELETE FROM Usuarios WHERE Nombre = '" + Nombre + "';");
        }
    }
}
