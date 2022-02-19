using MAQUINACERO_DP_SA_DE_CV.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAQUINACERO_DP_SA_DE_CV.Programa
{
    public partial class Pantalla_bloqueo : Form
    {
        CUsuarios CU = new CUsuarios();
        public Pantalla_bloqueo()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (CU.ValidarContraseña(txtUsuario.Text, txtContraseña.Text)){
                Principal pr = new Principal();
                this.Hide();
                pr.StartPosition = FormStartPosition.CenterScreen;
                pr.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Contraseña incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContraseña.Text = "";
                txtUsuario.Focus();
            }
        }
    }
}