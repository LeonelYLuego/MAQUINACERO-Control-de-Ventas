using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MAQUINACERO_DP_SA_DE_CV.SalidaAlmacen.Cotización;

namespace MAQUINACERO_DP_SA_DE_CV.SalidaAlmacen.Criterios
{
    public partial class ModificarCriterio : Form
    {
        private CotizacionSalida CS = new CotizacionSalida();
        public ModificarCriterio()
        {
            InitializeComponent();
        }

        private void ModificarCriterio_Load(object sender, EventArgs e)
        {
            cmbCriterio.SelectedIndex = 0;
            txtPorcentaje.Text = CS.obtenerPorcentaje(cmbCriterio.SelectedIndex).ToString();
        }

        private void cmbCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPorcentaje.Text = CS.obtenerPorcentaje(cmbCriterio.SelectedIndex).ToString();
        }

        private void txtPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = CS.validarFloat(e.KeyChar, txtPorcentaje);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(txtPorcentaje.Text == "")
            {
                MessageBox.Show("Llene todos los campos correctamente");
                return;
            }
            CS.modificarCriterios(cmbCriterio.SelectedIndex, float.Parse(txtPorcentaje.Text));
            this.Close();
        }
    }
}
