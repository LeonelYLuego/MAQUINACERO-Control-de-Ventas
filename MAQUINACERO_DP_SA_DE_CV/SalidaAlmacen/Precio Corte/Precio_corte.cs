using MAQUINACERO_DP_SA_DE_CV.SalidaAlmacen.Precio_Corte;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAQUINACERO_DP_SA_DE_CV.SalidaAlmacen
{
    public partial class Precio_corte : Form
    {
        PrecioCorte PC = new PrecioCorte();
        public Precio_corte()
        {
            InitializeComponent();
        }

        private void Precio_corte_Load(object sender, EventArgs e)
        {
            visualizarTabla();
        }

        private void visualizarTabla()
        {
            tblPrecioCorte.DataSource = PrecioCorte.select();
            tblPrecioCorte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Agregar_precio_corte apc = new Agregar_precio_corte(false, 0);
            apc.StartPosition = FormStartPosition.CenterScreen;
            apc.ShowDialog();
            visualizarTabla();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if(tblPrecioCorte.SelectedRows.Count == 0)
            {
                MessageBox.Show("No se selecciono ninguna fila");
                return;
            }
            for(int i = (tblPrecioCorte.SelectedRows.Count - 1); i >= 0; i--)
            {
                int ID_precio = PC.buscarID_precio(tblPrecioCorte.Rows[tblPrecioCorte.SelectedRows[i].Index].Cells[0].Value.ToString(), 
                    tblPrecioCorte.Rows[tblPrecioCorte.SelectedRows[i].Index].Cells[1].Value.ToString(), 
                    int.Parse(tblPrecioCorte.Rows[tblPrecioCorte.SelectedRows[i].Index].Cells[2].Value.ToString()), 
                    tblPrecioCorte.Rows[tblPrecioCorte.SelectedRows[i].Index].Cells[3].Value.ToString(), 
                    float.Parse(tblPrecioCorte.Rows[tblPrecioCorte.SelectedRows[i].Index].Cells[4].Value.ToString()));
                if(ID_precio > 0)
                {
                    Agregar_precio_corte apc = new Agregar_precio_corte(true, ID_precio);
                    apc.StartPosition = FormStartPosition.CenterScreen;
                    apc.ShowDialog();
                }
            }
            visualizarTabla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (tblPrecioCorte.SelectedRows.Count == 0)
            {
                MessageBox.Show("No se selecciono ninguna fila");
                return;
            }
            for (int i = (tblPrecioCorte.SelectedRows.Count - 1); i >= 0; i--)
            {
                int ID_precio = PC.buscarID_precio(tblPrecioCorte.Rows[tblPrecioCorte.SelectedRows[i].Index].Cells[0].Value.ToString(),
                    tblPrecioCorte.Rows[tblPrecioCorte.SelectedRows[i].Index].Cells[1].Value.ToString(),
                    int.Parse(tblPrecioCorte.Rows[tblPrecioCorte.SelectedRows[i].Index].Cells[2].Value.ToString()),
                    tblPrecioCorte.Rows[tblPrecioCorte.SelectedRows[i].Index].Cells[3].Value.ToString(),
                    float.Parse(tblPrecioCorte.Rows[tblPrecioCorte.SelectedRows[i].Index].Cells[4].Value.ToString()));
                if (ID_precio > 0)
                {
                    PC.delete(ID_precio);
                }
            }
            visualizarTabla();
        }

        private void Precio_corte_Resize(object sender, EventArgs e)
        {
            Size siz = this.Size;
            btnEliminar.Location = new Point(siz.Width - 265, 9);
            btnEditar.Location = new Point(siz.Width - 184, 9);
            btnAgregar.Location = new Point(siz.Width - 103, 9);
            btnRegresar.Location = new Point(siz.Width - 103, siz.Height - 74);
            tblPrecioCorte.Size = new Size(siz.Width - 40, siz.Height - 124);
        }
    }
}
