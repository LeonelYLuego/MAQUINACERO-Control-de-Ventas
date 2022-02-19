using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAQUINACERO_DP_SA_DE_CV.Usuarios
{
    public partial class Usuario : Form
    {
        CUsuarios CU = new CUsuarios();
        public Usuario()
        {
            InitializeComponent();
        }

        private void Usuario_Load(object sender, EventArgs e)
        {
            VisualizarUsuarios();
        }

        private void VisualizarUsuarios()
        {
            tblUsuarios.DataSource = CU.ObtenerUsuarios();
            tblUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarUsuario agu = new AgregarUsuario();
            agu.StartPosition = FormStartPosition.CenterScreen;
            agu.ShowDialog();
            VisualizarUsuarios();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(tblUsuarios.SelectedRows.Count != 1)
            {
                MessageBox.Show("No se selecciono ninguna fila");
                return;
            }
            String nombre = tblUsuarios.Rows[tblUsuarios.SelectedRows[0].Index].Cells["Nombre"].Value.ToString();
            CU.EliminarUsuario(nombre);
            VisualizarUsuarios();
        }
    }
}
