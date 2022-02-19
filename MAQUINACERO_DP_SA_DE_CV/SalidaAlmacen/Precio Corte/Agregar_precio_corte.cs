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

namespace MAQUINACERO_DP_SA_DE_CV.SalidaAlmacen.Precio_Corte
{
    public partial class Agregar_precio_corte : Form
    {
        private Consultas CN = new Consultas();
        private bool funcioVentana;
        private int ID_precio;
        public Agregar_precio_corte(bool _funcion, int _ID_precio)
        {
            InitializeComponent();
            funcioVentana = _funcion;
            ID_precio = _ID_precio;
        }

        private void Agregar_precio_corte_Load(object sender, EventArgs e)
        {
            ListarTipo();
            ListarFormas();
            cmbGrupo.SelectedIndex = 0;
            if (funcioVentana)
            {
                PrecioCorte PC = new PrecioCorte();
                DataTable aux = PC.selectDatosConID(ID_precio);
                if(aux.Rows.Count > 0)
                {
                    cmbTipo.Text = aux.Rows[0]["Tipo"].ToString();
                    ListarFormas();
                    if (cmbForma.Enabled)
                    {
                        cmbForma.Text = aux.Rows[0]["Forma"].ToString();
                    }
                    cmbGrupo.Text = aux.Rows[0]["Grupo corte"].ToString();
                    txtMedida.Text = aux.Rows[0]["Medida"].ToString();
                    txtPrecio.Text = aux.Rows[0]["Precio"].ToString();
                    cmbTipo.Enabled = false;
                    cmbForma.Enabled = false;
                    cmbGrupo.Enabled = false;
                    txtMedida.Enabled = false;
                    btnAgregar.Visible = false;
                    btnAgregarOtro.Visible = false;
                    btnCancelar.Text = "Siguiente";
                    return;
                }
            }
            btnActualizar.Visible = false;
        }

        private void ListarTipo()
        {
            cmbTipo.DataSource = CN.Consulta("SELECT DISTINCT Tipo FROM Forma ORDER BY Tipo;");
            cmbTipo.DisplayMember = "Tipo";
        }

        private void ListarFormas()
        {
            DataTable aux = CN.Consulta("SELECT DISTINCT Descripcion FROM Forma WHERE Tipo = '" + cmbTipo.Text + "' ORDER BY Descripcion;");
            if (aux.Rows.Count > 0)
            {
                DataRow row = aux.Rows[0];
                if (row.IsNull("Descripcion"))
                    cmbForma.Enabled = false;
                else
                    cmbForma.Enabled = true;
            }
            cmbForma.DataSource = aux;
            cmbForma.DisplayMember = "Descripcion";
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarFormas();
        }

        private void txtMedida_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if ((c < '0' || c > '9') && c != '/' && c != ' ' && c != '\b')
            {
                e.Handled = true;
                return;
            }
            bool esp = false, dia = false;
            for (int i = 0; i < txtMedida.TextLength; i++)
            {
                if (txtMedida.Text[i] == ' ')
                    esp = true;
                else if (txtMedida.Text[i] == '/')
                    dia = true;
            }
            if (e.KeyChar == ' ' && esp)
                e.Handled = true;
            if (e.KeyChar == ' ' && dia)
                e.Handled = true;
            if (e.KeyChar == '/' && dia)
                e.Handled = true;
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if ((c < '0' || c > '9') && c != '.' && c != '\b')
                e.Handled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(agregar())
                this.Close();
        }

        private void btnAgregarOtro_Click(object sender, EventArgs e)
        {
            if (agregar())
            {
                MessageBox.Show("Registro exitoso");
                txtPrecio.Text = "";
            }
        }

        private bool agregar()
        {
            bool v = false;
            if (txtMedida.Text == "") v = true;
            if (txtPrecio.Text == "") v = true;
            if (txtMedida.TextLength == 0 || txtPrecio.TextLength == 0)
                v = true;
            else
            {
                if (txtPrecio.Text[txtPrecio.TextLength - 1] == '.') v = true;
                if (txtMedida.Text[txtMedida.TextLength - 1] == ' ' || txtMedida.Text[txtMedida.TextLength - 1] == '/') v = true;
            }
            if (v)
            {
                MessageBox.Show("Error: llene todos los campos correctamente");
                return false;
            }
            PrecioCorte PC = new PrecioCorte();
            return PC.insert(cmbTipo.Text.ToUpper(), cmbForma.Text.ToUpper(), txtMedida.Text, cmbGrupo.SelectedIndex + 1, float.Parse(txtPrecio.Text));
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            bool v = false;
            if (txtPrecio.Text == "") v = true;
            if (txtPrecio.TextLength == 0) v = true;
            else
            {
                if (txtPrecio.Text[txtPrecio.TextLength - 1] == '.') v = true;
            }
            if (v)
            {
                MessageBox.Show("Error: llene todos los campos correctamente");
                return;
            }
            PrecioCorte PC = new PrecioCorte();
            PC.update(ID_precio, float.Parse(txtPrecio.Text));
            this.Close();
        }
    }
}
