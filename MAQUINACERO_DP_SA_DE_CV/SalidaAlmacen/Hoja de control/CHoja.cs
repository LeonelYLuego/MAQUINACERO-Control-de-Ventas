using MAQUINACERO_DP_SA_DE_CV.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAQUINACERO_DP_SA_DE_CV.SalidaAlmacen.Hoja_de_control
{
    class CHoja
    {
        private DataTable tabla;
        private Consultas CN = new Consultas();
        private List<String> codigosSinExistencia;
        private int ID_cliente;
        private String dia;

        public void RegistroSalida(DataTable _tabla, int _ID_cliente)
        {
            tabla = _tabla;
            ID_cliente = _ID_cliente;
            DateTime dateTime = new DateTime();
            dateTime = DateTime.Now;
            dia = Convert.ToDateTime(dateTime).ToString("yyyy-MM-dd");
            Agregar(VerificarProductoEnAlmacen());
        }

        private bool VerificarProductoEnAlmacen()
        {
            List<String> codigos = new List<String>();
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                String codigo = tabla.Rows[i]["Codigo"].ToString();
                if(CN.Consulta("SELECT ID_almacen FROM Almacen WHERE Codigo = '" + codigo + "';").Rows.Count == 0)
                    codigos.Add(codigo);
            }
            codigosSinExistencia = codigos;
            if(codigos.Count > 0)
            {
                String aux = "Los productos:\n";
                for(int i = 0; i < codigos.Count; i++)
                    aux += + '\t' + codigos[i] + '\n';
                aux += "No se encuentran en el almacen\nDeseas agregarlos con existencias negativas?";
                if (MessageBox.Show(aux, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    return true;
                else
                    return false;
            }
            return false;
        }

        private void Agregar(bool SinExistencia)
        {
            for(int i = 0; i < tabla.Rows.Count; i++)
            {
                String codigo = tabla.Rows[i]["Codigo"].ToString();
                if (BuscarConcidencia(codigo) && SinExistencia)
                {
                    AgregarProductoAlAlmacen(codigo);
                    AgregarSalida(codigo, i);
                }
                else if(!BuscarConcidencia(codigo))
                {
                    AgregarSalida(codigo, i);
                }
            }
        }

        private bool BuscarConcidencia(String codigo)
        {
            for (int j = 0; j < codigosSinExistencia.Count; j++)
                if (codigosSinExistencia[j] == codigo)
                {
                    return true;
                }
            return false;
        }

        private void AgregarProductoAlAlmacen(String codigo)
        {
            if(CN.Consulta("SELECT ID_almacen FROM Almacen WHERE Codigo = '" + codigo + "';").Rows.Count == 0)
            {
                CN.Consulta("INSERT INTO Almacen(ID_almacen, Codigo, Kilogramos) VALUES ((select max(ID_almacen) from Almacen) + 1, '" + codigo + "', 0);");
            }
            
        }

        private void AgregarSalida(String codigo, int direccion)
        {
            CN.Consulta("INSERT INTO Salida(ID_salida, ID_almacen, Kilogramos, Fecha, ID_cliente) VALUES ((select max(ID_salida) from Salida) + 1, (select max(ID_almacen) from Almacen where Codigo = '" + codigo + "'), " + tabla.Rows[direccion]["Kilogramos cotizacion"].ToString() + ", '" + dia + "'," + (ID_cliente == 0 ? "NULL" : ID_cliente.ToString()) + ");");
            CN.Consulta("UPDATE Almacen SET Kilogramos = (select isnull(sum(e.kilogramos),0) from almacen as a inner join entrada as e on a.ID_almacen = e.ID_almacen where a.Codigo = '" + codigo + "')-(select isnull(sum(s.Kilogramos),0) from almacen as a inner join salida as s on a.ID_almacen = s.ID_almacen where a.Codigo = '" + codigo + "') WHERE Codigo= '" + codigo + "';");
        }
    }
}
