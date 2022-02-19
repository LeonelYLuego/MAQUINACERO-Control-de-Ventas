using MAQUINACERO_DP_SA_DE_CV.Conexion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAQUINACERO_DP_SA_DE_CV.Programa.Dirreciones_archivo
{
    public partial class DireccionArchivo : Form
    {
        ClaseBase CB = new ClaseBase();
        Consultas CN = new Consultas();
        public DireccionArchivo()
        {
            InitializeComponent();
        }

        private void cmbUbicaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDireccion.Text = CB.obtenerUbicacionArchivo(cmbUbicaciones.Text);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnArchivo_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Word files (*.docx)|*.docx";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtDireccion.Text = openFileDialog.FileName.ToString();
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(txtDireccion.Text == "" || cmbUbicaciones.Text == "")
            {
                MessageBox.Show("Llene todos los campos correctamente");
                return;
            }
            CN.Consulta("UPDATE direccionCarpeta SET Direccion = '" + txtDireccion.Text + "' WHERE ID_direccion = '" + cmbUbicaciones.Text + "';");
            this.Close();
        }
    }
}
