using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAQUINACERO_DP_SA_DE_CV.Cliente
{
    public partial class AgregarCliente : Form
    {
        CCliente CC = new CCliente();
        private int ID;
        public AgregarCliente(int ID_cliente)
        {
            InitializeComponent();
            ID = ID_cliente;
        }

        private void AgregarCliente_Load(object sender, EventArgs e)
        {
            if(ID != 0)
            {
                DataTable tabla = CC.obtenerCliente(ID);
                if (tabla.Rows.Count > 0) {
                    txtNombre.Text = tabla.Rows[0]["Nombre"].ToString();
                    txtTelefono.Text = tabla.Rows[0]["Telefono"].ToString();
                    txtCorreoElectronico.Text = tabla.Rows[0]["CorreoElectronico"].ToString();
                    txtCalle.Text = tabla.Rows[0]["Calle"].ToString();
                    txtNumero.Text = tabla.Rows[0]["Numero"].ToString();
                    txtColonia.Text = tabla.Rows[0]["Colonia"].ToString();
                    txtEstado.Text = tabla.Rows[0]["Estado"].ToString();
                    txtMunicipio.Text = tabla.Rows[0]["Municipio"].ToString();
                    txtCodifoPostal.Text = tabla.Rows[0]["CodigoPostal"].ToString();
                    if (!tabla.Rows[0].IsNull("RFC"))
                        txtRFC.Text = tabla.Rows[0]["RFC"].ToString();
                    btnAgregar.Visible = false;
                    return;
                }
            }
            btnModificar.Visible = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region keyPress

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = CC.validarLetras(e.KeyChar, txtNombre, 100);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = CC.validarFloat(e.KeyChar, txtTelefono);
            if (e.KeyChar == '.')
                e.Handled = true;
            else if (txtTelefono.TextLength >= 20 && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void txtCorreoElectronico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == ' ')
                e.Handled = true;
        }

        private void txtCalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = CC.validarLetras(e.KeyChar, txtCalle, 50);
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = CC.validarFloat(e.KeyChar, txtNumero);
            if (e.KeyChar == '.')
                e.Handled = true;
        }

        private void txtColonia_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = CC.validarLetras(e.KeyChar, txtColonia, 50);
        }

        private void txtEstado_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = CC.validarLetras(e.KeyChar, txtEstado, 30);
        }

        private void txtMunicipio_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = CC.validarLetras(e.KeyChar, txtMunicipio, 30);
        }

        private void txtCodifoPostal_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = CC.validarFloat(e.KeyChar, txtCodifoPostal);
            if (e.KeyChar == '.')
                e.Handled = true;
            if (txtCodifoPostal.TextLength >= 5 && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void txtRFC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
                e.Handled = true;
            else if (txtRFC.TextLength >= 13 && e.KeyChar != '\b')
                e.Handled = true;
        }


        #endregion

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            bool v = false;
            if (txtNombre.Text == "") v = true;
            else if (txtTelefono.Text == "") v = true;
            else if (txtCorreoElectronico.Text == "") v = true;
            else if (txtCalle.Text == "") v = true;
            else if (txtNumero.Text == "") v = true;
            else if (txtColonia.Text == "") v = true;
            else if (txtEstado.Text == "") v = true;
            else if (txtMunicipio.Text == "") v = true;
            else if (txtCodifoPostal.Text == "") v = true;
            if (v)
            {
                MessageBox.Show("Llene todos los campos correctamente");
                return;
            }
            CC.agregarCliente(txtNombre.Text, txtTelefono.Text, txtCorreoElectronico.Text, txtCalle.Text, int.Parse(txtNumero.Text), txtColonia.Text, txtEstado.Text, txtMunicipio.Text, int.Parse(txtCodifoPostal.Text), txtRFC.Text);
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            CC.modificarCliente(ID, txtNombre.Text, txtTelefono.Text, txtCorreoElectronico.Text, txtCalle.Text, int.Parse(txtNumero.Text), txtColonia.Text, txtEstado.Text, txtMunicipio.Text, int.Parse(txtCodifoPostal.Text), txtRFC.Text);
            this.Close();
        }
    }
}
