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
    public partial class AgregarUsuario : Form
    {
        private CUsuarios CU = new CUsuarios();
        public AgregarUsuario()
        {
            InitializeComponent();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtNombre.TextLength >= 20 && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == ' ' || txtUsuario.TextLength >= 50) && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == ' ' || txtContraseña.TextLength >= 50) && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void txtContraseñaConf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == ' ' || txtContraseñaConf.TextLength >= 50) && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || txtUsuario.Text == "" || txtContraseña.Text == "" || txtContraseñaConf.Text == "")
            {
                MessageBox.Show("Llene todos los campos correctamente");
                return;
            }
            else if (CU.ValidarNombre(txtNombre.Text))
            {
                MessageBox.Show("Error: Nombre ya registrado");
                return;
            }
            else if(txtContraseña.Text != txtContraseñaConf.Text)
            {
                MessageBox.Show("Error: las contraseñas no conciden");
                return;
            }
            CU.AgregarUsuario(txtNombre.Text, txtUsuario.Text, txtContraseña.Text);
            this.Close();
        }
    }
}
