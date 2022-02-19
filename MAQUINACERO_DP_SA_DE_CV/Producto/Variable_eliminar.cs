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

namespace MAQUINACERO_DP_SA_DE_CV.Programa
{
    public partial class Variable_eliminar : Form
    {
        String _entidad;
        int maxCarDes;
        int maxCarTip;
        public Variable_eliminar(String entidad)
        {
            InitializeComponent();
            _entidad = entidad;
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (_entidad == "Forma")
                txtDescripcion.Enabled = !checkBox.Checked;
        }

        private void txtTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtTipo.TextLength >= maxCarTip && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtDescripcion.TextLength >= maxCarDes && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Consultas CN = new Consultas();
            DataTable aux;
            switch (_entidad)
            {
                case "Forma":
                    if (txtTipo.Text == "" || (txtDescripcion.Text == "" && !checkBox.Checked))
                    {
                        MessageBox.Show("Error: Llene todos los campos");
                        return;
                    }
                    aux = CN.Consulta("SELECT COUNT(*) as Cantidad FROM Forma WHERE Tipo = '" + txtTipo.Text + "' AND Descripcion " + (checkBox.Checked ? ("is null") : ("= '" + txtDescripcion.Text.ToUpper() + "'")) + ";");
                    if (aux.Rows.Count > 0)
                    {
                        DataRow row = aux.Rows[0];
                        if (row["Cantidad"].ToString() == "0")
                        {
                            MessageBox.Show("Error: No se encontro ninguna concidencia");
                            return;
                        }
                    }
                    aux = CN.Consulta("SELECT COUNT(*) as Cantidad FROM Producto as p INNER JOIN Forma as f ON p.ID_forma = f.ID_forma WHERE f.Tipo = '" + txtTipo.Text + "' AND f.Descripcion " + (checkBox.Checked ? ("is null") : ("= '" + txtDescripcion.Text.ToUpper() + "'")) + ";");
                    if (aux.Rows.Count > 0)
                    {
                        DataRow row = aux.Rows[0];
                        if (row["Cantidad"].ToString() != "0")
                        {
                            MessageBox.Show("Error: Variable utilizada en productos");
                            return;
                        }
                    }
                    aux = CN.Consulta("SELECT COUNT(*) as Cantidad FROM PrecioCorte as p INNER JOIN Forma as f ON p.ID_forma = f.ID_forma WHERE f.Tipo = '" + txtTipo.Text + "' AND f.Descripcion " + (checkBox.Checked ? ("is null") : ("= '" + txtDescripcion.Text.ToUpper() + "'")) + ";");
                    if (aux.Rows.Count > 0)
                    {
                        DataRow row = aux.Rows[0];
                        if (row["Cantidad"].ToString() != "0")
                        {
                            MessageBox.Show("Error: Variable utilizada en precio del corte");
                            return;
                        }
                    }
                    CN.Consulta("DELETE FROM Forma WHERE Tipo = '" + txtTipo.Text.ToUpper() + "' AND Descripcion " + (checkBox.Checked ? ("is null") : ("= '" + txtDescripcion.Text.ToUpper() + "'")) + ";");
                    break;
                case "Material":
                    if (txtDescripcion.Text == "")
                    {
                        MessageBox.Show("Error: Llene todos los campos");
                        return;
                    }
                    aux = CN.Consulta("SELECT COUNT(*) as Cantidad FROM Material WHERE Descripcion = '" + txtDescripcion.Text + "';");
                    if (aux.Rows.Count > 0)
                    {
                        DataRow row = aux.Rows[0];
                        if (row["Cantidad"].ToString() == "0")
                        {
                            MessageBox.Show("Error: No se encontro ninguna concidencia");
                            return;
                        }
                    }
                    aux = CN.Consulta("SELECT COUNT(*) as Cantidad FROM Producto as p INNER JOIN Material as ma ON p.ID_material = ma.ID_material WHERE ma.Descripcion = '" + txtDescripcion.Text + "';");
                    if (aux.Rows.Count > 0)
                    {
                        DataRow row = aux.Rows[0];
                        if (row["Cantidad"].ToString() != "0")
                        {
                            MessageBox.Show("Error: Variable utilizada en productos");
                            return;
                        }
                    }
                    CN.Consulta("DELETE FROM Material WHERE Descripcion = '" + txtDescripcion.Text.ToUpper() + "';");
                    break;
                case "Medida":
                    if (txtDescripcion.Text == "")
                    {
                        MessageBox.Show("Error: Llene todos los campos");
                        return;
                    }
                    aux = CN.Consulta("SELECT COUNT(*) as Cantidad FROM Medida WHERE Descripcion = '" + txtDescripcion.Text + "' AND Fraccion = " + (checkBox.Checked ? ("1") : ("0")) + ";");
                    if (aux.Rows.Count > 0)
                    {
                        DataRow row = aux.Rows[0];
                        if (row["Cantidad"].ToString() == "0")
                        {
                            MessageBox.Show("Error: No se encontro ninguna concidencia");
                            return;
                        }
                    }
                    aux = CN.Consulta("SELECT COUNT(*) as Cantidad FROM Producto as p INNER JOIN Medida as me ON p.ID_medida = me.ID_medida WHERE me.Descripcion = '" + txtDescripcion.Text + "' and me.Fraccion = " + (checkBox.Checked ? ("1") : ("0")) + ";");
                    if (aux.Rows.Count > 0)
                    {
                        DataRow row = aux.Rows[0];
                        if (row["Cantidad"].ToString() != "0")
                        {
                            MessageBox.Show("Error: Variable utilizada en productos");
                            return;
                        }
                    }
                    aux = CN.Consulta("SELECT COUNT(*) as Cantidad FROM Producto as p INNER JOIN Medida as me ON p.ID_medida2 = me.ID_medida WHERE me.Descripcion = '" + txtDescripcion.Text + "' and me.Fraccion = " + (checkBox.Checked ? ("1") : ("0")) + ";");
                    if (aux.Rows.Count > 0)
                    {
                        DataRow row = aux.Rows[0];
                        if (row["Cantidad"].ToString() != "0")
                        {
                            MessageBox.Show("Error: Variable utilizada en productos");
                            return;
                        }
                    }
                    CN.Consulta("DELETE FROM Medida WHERE Descripcion = '" + txtDescripcion.Text.ToUpper() + "' AND Fraccion = " + (checkBox.Checked ? ("1") : ("0")) + ";");
                    break;
            }
            this.Close();
        }

        private void Variable_eliminar_Load(object sender, EventArgs e)
        {
            switch (_entidad)
            {
                case "Forma":
                    checkBox.Text = "Sin forma";
                    checkBox.Checked = false;
                    maxCarDes = 30;
                    maxCarTip = 30;
                    break;
                case "Material":
                    maxCarDes = 50;
                    checkBox.Visible = false;
                    txtTipo.Visible = false;
                    lbTipo.Visible = false;
                    lbDescripcion.Location = new Point(12, 15);
                    txtDescripcion.Location = new Point(82, 12);
                    btnEliminar.Location = new Point(113, 38);
                    btnCancelar.Location = new Point(193, 38);
                    this.Size = new Size(292, 110);
                    break;
                case "Medida":
                    maxCarDes = 10;
                    checkBox.Text = "Fraccion";
                    checkBox.Visible = true;
                    txtTipo.Visible = false;
                    lbTipo.Visible = false;
                    lbDescripcion.Location = new Point(12, 15);
                    txtDescripcion.Location = new Point(82, 12);
                    btnEliminar.Location = new Point(113, 58);
                    btnCancelar.Location = new Point(193, 58);
                    this.Size = new Size(292, 127);
                    break;
            }
        }
    }
}
