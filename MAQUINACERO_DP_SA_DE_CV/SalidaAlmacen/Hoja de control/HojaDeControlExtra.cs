using MAQUINACERO_DP_SA_DE_CV.Cliente;
using MAQUINACERO_DP_SA_DE_CV.SalidaAlmacen.Cotización;
using MAQUINACERO_DP_SA_DE_CV.SalidaAlmacen.Hoja_de_control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAQUINACERO_DP_SA_DE_CV.Hoja_de_control
{
    public partial class HojaDeControlExtra : Form
    {
        public int ID_cliente = 0;
        private ClaseBase CB = new ClaseBase();
        private DataTable tabla;
        public HojaDeControlExtra()
        {
            InitializeComponent();
        }

        public HojaDeControlExtra(DataTable _tabla) {
            InitializeComponent();
            tabla = _tabla;
        }

        private void HojaDeControlExtra_Load(object sender, EventArgs e)
        {

        }

        #region keyTyped

        private void txtNoCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
                e.Handled = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
                e.Handled = true;
        }

        private void txtTiempo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = CB.validarFloat(e.KeyChar, txtTiempo);
        }

        private void txtNombreArchivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = CB.validarUbicacionArchivo(e.KeyChar, txtNombreArchivo);
        }


        #endregion

        #region Press

        private void chkEnvio_CheckedChanged(object sender, EventArgs e)
        {
            txtTiempo.Enabled = chkEnvio.Checked;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            DatosCliente dc = new DatosCliente(this);
            dc.StartPosition = FormStartPosition.CenterScreen;
            dc.ShowDialog();
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(txtNoHojacControl.Text == "" || (chkEnvio.Checked && (txtTiempo.Text == "" || txtCliente.Text == "")) || txtNombreArchivo.Text == "" || txtUbicacion.Text == "")
            {
                MessageBox.Show("Llene todos los campos correctamente");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Al generar el documento, se modificara el almacen.\n¿Deseas continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.Yes)
            {
                CHoja CH = new CHoja();
                CH.RegistroSalida(tabla, ID_cliente);
                DocumentoHojaControl dhc = new DocumentoHojaControl();
                dhc.Generardocumento(tabla, this);
                this.Close();
            }
        }

        #endregion
    }
}
