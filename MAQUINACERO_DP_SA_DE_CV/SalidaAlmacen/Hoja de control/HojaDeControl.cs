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

namespace MAQUINACERO_DP_SA_DE_CV.Hoja_de_control
{
    public partial class HojaDeControl : SalCotizacion
    {
        public HojaDeControl()
        {
            InitializeComponent();
        }

        private void HojaDeControl_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(255, 185, 100);
            base.btnOrdenCompra.Visible = false;
        }

        private void btnHojaControl_Click(object sender, EventArgs e)
        {
            HojaDeControlExtra hdce = new HojaDeControlExtra(tabla);
            hdce.StartPosition = FormStartPosition.CenterScreen;
            hdce.ShowDialog();
        }

        private void HojaDeControl_Resize(object sender, EventArgs e)
        {
            Size siz = this.Size;
            btnHojaControl.Location = new Point(siz.Width - 265, siz.Height - 103);
        }
    }
}
