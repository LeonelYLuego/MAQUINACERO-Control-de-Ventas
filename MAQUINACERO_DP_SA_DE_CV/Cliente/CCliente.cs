using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAQUINACERO_DP_SA_DE_CV.Cliente
{
    class CCliente : ClaseBase
    {
        public DataTable obtenerClientes()
        {
            return CN.Consulta("SELECT Nombre, Telefono, CorreoElectronico, Calle, Numero, Colonia, Estado, Municipio, CodigoPostal, RFC FROM  Cliente;");
        }

        public void agregarCliente(String nombre, String telefono, String correo, String calle, int numero, String colonia, String estado, String municipio, int postal, String RFC)
        {
            CN.Consulta("INSERT INTO Cliente(ID_cliente, Nombre, Telefono, CorreoElectronico, Calle, Numero, Colonia, Estado, Municipio, CodigoPostal, RFC) VALUES ((select max(id_cliente) from cliente) + 1, '" + nombre + "', '" + telefono + "', '" + correo + "', '" + calle + "', " + numero + ", '" + colonia + "', '" + estado + "','" + municipio + "', " + postal + ", " + (RFC == "" ? "NULL" : '\'' + RFC + '\'') + ");");
        }

        public int obtenerID_cliente(String nombre, String telefono, String correo, String calle, int numero, String colonia, String estado, String municipio, int postal, String RFC)
        {
            DataTable tabla = CN.Consulta("SELECT ID_cliente FROM Cliente WHERE Nombre = '" + nombre + "' AND Telefono = '" + telefono + "' AND CorreoElectronico = '" + correo + "' AND Calle = '" + calle + "' AND Numero = " + numero + " AND Colonia = '" + colonia + "' AND Estado = '" + estado + "' AND Municipio = '" + municipio + "' AND CodigoPostal = " + postal + " AND RFC " + (RFC == ""? "IS NULL" : "= '" + RFC + "'") + " ;");
            if(tabla.Rows.Count > 0)
            {
                return int.Parse(tabla.Rows[0]["ID_cliente"].ToString());
            }
            return 0;
        }

        public void eliminarCliente(int ID_cliente)
        {
            CN.Consulta("DELETE FROM Salida WHERE ID_cliente = " + ID_cliente + ";");
            CN.Consulta("DELETE FROM Cliente WHERE ID_cliente = " + ID_cliente + ";");
        }

        public DataTable obtenerCliente(int ID_cliente)
        {
            return CN.Consulta("SELECT Nombre, Telefono, CorreoElectronico, Calle, Numero, Colonia, Estado, Municipio, CodigoPostal, RFC FROM  Cliente WHERE ID_cliente = " + ID_cliente + ";");
        }

        public void modificarCliente(int ID_cliente, String nombre, String telefono, String correo, String calle, int numero, String colonia, String estado, String municipio, int postal, String RFC)
        {
            CN.Consulta("UPDATE Cliente SET Nombre = '" + nombre + "', Telefono = '" + telefono + "', CorreoElectronico = '" + correo + "', Calle = '" + calle + "', Numero = " + numero + ", Colonia = '" + colonia + "', Estado = '" + estado + "', CodigoPostal = " + postal + ", RFC " + (RFC == "" ? "= NULL" : "= '" + RFC + "'") + ", Municipio = '" + municipio + "' WHERE ID_cliente = " + ID_cliente + ";");
        }

        public DataTable buscarCliente(String nombre)
        {
            return CN.Consulta("SELECT Nombre, Telefono, CorreoElectronico, Calle, Numero, Colonia, Estado, Municipio, CodigoPostal, RFC FROM  Cliente WHERE Nombre LIKE '%" + nombre + "%';");
        }
    }
}
