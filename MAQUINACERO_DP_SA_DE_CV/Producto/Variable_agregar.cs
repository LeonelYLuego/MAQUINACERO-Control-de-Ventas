using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MAQUINACERO_DP_SA_DE_CV.Conexion;

namespace MAQUINACERO_DP_SA_DE_CV.Programa
{
    public partial class Variable_agregar : Form
    {
        String _entidad;
        int maxCarNue;
        int maxCarTip;
        public Variable_agregar(String entidad)
        {
            InitializeComponent();
            _entidad = entidad;
        }

        private void Variable_agregar_Load(object sender, EventArgs e)
        {
            switch (_entidad)
            {
                case "Forma":
                    checkBox.Text = "Sin forma";
                    lbTipo.Text = "Tipo:";
                    lbNuevo.Text = "Forma:";
                    checkBox1.Visible = false;
                    btnAgregarOtro.Visible = false;
                    lbPesoEspecifico.Visible = false;
                    lbGrupo.Visible = false;
                    cmbGrupo.Visible = false;
                    txtNuevo.Location = new Point(76, 61);
                    lbNuevo.Location = new Point(35, 63);
                    lbTipo.Location = new Point(43, 18);
                    btnAgregar.Location = new Point(102, 86);
                    btnCancelar.Location = new Point(183, 86);
                    this.Size = new Size(280, 154);
                    maxCarNue = 30;
                    maxCarTip = 30;
                    break;
                case "Material":
                    maxCarTip = 50;
                    checkBox.Visible = false;
                    checkBox1.Visible = false;
                    lbTipo.Text = "Material:";
                    lbNuevo.Text = "Peso esp:";
                    cmbGrupo.SelectedIndex = 0;
                    break;
                case "Medida":
                    maxCarTip = 10;
                    checkBox.Text = "Fraccion";
                    checkBox1.Text = "Cuenta con conversion a metros";
                    btnAgregarOtro.Visible = false;
                    txtNuevo.Enabled = false;
                    lbPesoEspecifico.Visible = false;
                    lbGrupo.Visible = false;
                    cmbGrupo.Visible = false;
                    break;
            }
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if(_entidad == "Forma")
                txtNuevo.Enabled = !checkBox.Checked;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Agregar();
            this.Close();
        }

        private void txtTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(txtTipo.TextLength >= maxCarTip && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void txtNuevo_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (_entidad == "Medida" || _entidad == "Material")
            {
                if ((c < '0' || c > '9') && c != '.' && c != '\b')
                    e.Handled = true;
            }
            else
            {
                if (txtNuevo.TextLength >= maxCarNue)
                    e.Handled = true;
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtNuevo.Enabled = checkBox1.Checked;
        }

        private void Agregar()
        {
            Consultas CN = new Consultas();
            DataTable aux;
            switch (_entidad)
            {
                case "Forma":
                    if (txtTipo.Text == "" || (txtNuevo.Text == "" && !checkBox.Checked))
                    {
                        MessageBox.Show("Error: Llene todos los campos");
                        return;
                    }
                    aux = CN.Consulta("SELECT COUNT(*) as Cantidad FROM Forma WHERE Tipo = '" + txtTipo.Text + "' AND Descripcion" + (checkBox.Checked ? (" is null") : (" = '" + txtNuevo.Text.ToUpper() + "'")) + ";");
                    if (aux.Rows.Count > 0)
                    {
                        DataRow row = aux.Rows[0];
                        if (row["Cantidad"].ToString() != "0")
                        {
                            MessageBox.Show("Error: Ya registrado");
                            return;
                        }
                    }
                    CN.Consulta("INSERT INTO Forma(ID_forma, Descripcion, Tipo) VALUES ((select max(ID_forma) from Forma) + 1, " + (checkBox.Checked ? ("null") : ("'" + txtNuevo.Text.ToUpper() + "'")) + ", '" + txtTipo.Text.ToUpper() + "');");
                    break;
                case "Material":
                    if (txtTipo.Text == "" || txtNuevo.Text == "")
                    {
                        MessageBox.Show("Error: Llene todos los campos");
                        return;
                    }
                    aux = CN.Consulta("SELECT COUNT(*) as Cantidad FROM Material WHERE Descripcion = '" + txtTipo.Text + "';");
                    if (aux.Rows.Count > 0)
                    {
                        DataRow row = aux.Rows[0];
                        if (row["Cantidad"].ToString() != "0")
                        {
                            MessageBox.Show("Error: Ya registrado");
                            return;
                        }
                    }
                    CN.Consulta("INSERT INTO Material(ID_material, Descripcion, Densidad, ID_grupo) VALUES ((select max(ID_material) from Material) + 1, '" + txtTipo.Text.ToUpper() + "', " + txtNuevo.Text + ", " + (cmbGrupo.SelectedIndex == 0 ? "null" : cmbGrupo.SelectedIndex.ToString()) + ");");
                    break;
                case "Medida":
                    if (txtTipo.Text == "" || (txtNuevo.Text == "" && checkBox1.Checked))
                    {
                        MessageBox.Show("Error: Llene todos los campos");
                        return;
                    }
                    aux = CN.Consulta("SELECT COUNT(*) as Cantidad FROM Medida WHERE Descripcion = '" + txtTipo.Text + "' AND Fraccion = " + (checkBox.Checked ? ("1") : ("0")) + ";");
                    if (aux.Rows.Count > 0)
                    {
                        DataRow row = aux.Rows[0];
                        if (row["Cantidad"].ToString() != "0")
                        {
                            MessageBox.Show("Error: Ya registrado");
                            return;
                        }
                    }
                    CN.Consulta("INSERT INTO Medida(ID_medida, Descripcion, Fraccion, Conversion) VALUES((select max(ID_medida) from Medida) + 1, '" + txtTipo.Text.ToUpper() + "', " + (checkBox.Checked ? ("1") : ("0")) + ", " + (checkBox1.Checked ? (txtNuevo.Text) : ("null")) + ");");
                    break;
            }
        }

        private void btnAgregarOtro_Click(object sender, EventArgs e)
        {
            Agregar();
            MessageBox.Show("Agregado exitosamente");
            txtNuevo.Text = "";
            txtTipo.Text = "";
            cmbGrupo.SelectedIndex = 0;
        }
    }
}
