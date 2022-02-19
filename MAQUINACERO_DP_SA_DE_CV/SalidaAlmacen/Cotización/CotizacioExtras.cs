using MAQUINACERO_DP_SA_DE_CV.Cliente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAQUINACERO_DP_SA_DE_CV.SalidaAlmacen.Cotización
{
    public partial class CotizacioExtras : Form
    {
        private ClaseBase CB = new ClaseBase();
        private DataTable tabla;
        public int ID_cliente;
        public CotizacioExtras(DataTable _tabla)
        {
            InitializeComponent();
            tabla = _tabla;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkEnvio_CheckedChanged(object sender, EventArgs e)
        {
            txtCostoEnvio.Enabled = chkEnvio.Checked;
            txtTiempo.Enabled = chkEnvio.Checked;
        }

        private void chkOtro_CheckedChanged(object sender, EventArgs e)
        {
            txtCosto.Enabled = chkOtro.Checked;
        }

        private void txtCostoEnvio_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = CB.validarFloat(e.KeyChar, txtCostoEnvio);
        }

        private void txtTiempo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = CB.validarFloat(e.KeyChar, txtTiempo);
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = CB.validarFloat(e.KeyChar, txtCosto);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if((chkEnvio.Checked && (txtCostoEnvio.Text == "" || txtTiempo.Text == "")) || (chkOtro.Checked && txtCosto.Text == "") || txtNoCompra.Text == "" || txtUbicacion.Text == "" || txtNombreArchivo.Text == "")
            {
                MessageBox.Show("Llene todos los campos correctamente");
                return;
            }
            Documento doc = new Documento();
            doc.Generardocumento(tabla, this);
            this.Close();
        }

        private void txtNoCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
                e.Handled = true;
        }

        private void btnUbicacionArchivo_Click(object sender, EventArgs e)
        {
            using (var fd = new FolderBrowserDialog())
            {
                if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fd.SelectedPath))
                {
                    txtUbicacion.Text = fd.SelectedPath;
                }
            }
        }

        private void txtNombreArchivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if ((c < '0' || c > '9') && (c < 'a' || c > 'z') && (c < 'A' || c > 'Z') && c != ' ' && c != '_' && c != '\b')
                e.Handled = true;
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            DatosCliente dc = new DatosCliente(this);
            dc.StartPosition = FormStartPosition.CenterScreen;
            dc.ShowDialog();
        }
    }
}
