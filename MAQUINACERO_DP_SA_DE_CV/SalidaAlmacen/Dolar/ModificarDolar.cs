using MAQUINACERO_DP_SA_DE_CV.Conexion;
using MAQUINACERO_DP_SA_DE_CV.SalidaAlmacen.Cotización;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAQUINACERO_DP_SA_DE_CV.SalidaAlmacen.Dolar
{
    public partial class ModificarDolar : Form
    {
        Label lbADolar;
        private CotizacionSalida CS = new CotizacionSalida();
        private Consultas CN = new Consultas();
        public ModificarDolar(Label _lbADolar)
        {
            InitializeComponent();
            lbADolar = _lbADolar;
        }

        private void ModificarDolar_Load(object sender, EventArgs e)
        {
            txtPrecio.Text = CS.obtenerPrecioDolar().ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(txtPrecio.Text == "")
            {
                MessageBox.Show("Llene todos los campos correctamente");
                return;
            }
            DateTime dateTime = new DateTime();
            dateTime = DateTime.Now;
            string strDate = Convert.ToDateTime(dateTime).ToString("yyyy-MM-dd");
            DataTable aux = CN.Consulta("SELECT ID_dolar FROM Dolar WHERE Fecha = '" + strDate + "';");
            if (aux.Rows.Count > 0)
            {
                CN.Consulta("UPDATE Dolar SET Precio = " + txtPrecio.Text + " WHERE ID_dolar = " + aux.Rows[0]["ID_dolar"] + ";");
            }
            else
            {
                CN.Consulta("INSERT INTO Dolar(ID_dolar, Precio, Fecha) VALUES ((select max(ID_dolar) from Dolar) + 1, " + txtPrecio.Text + ", '" + strDate + "');");
            }
            lbADolar.Visible = !CS.comprobarDolar();
            this.Close();
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = CS.validarFloat(e.KeyChar, txtPrecio);
        }
    }
}
