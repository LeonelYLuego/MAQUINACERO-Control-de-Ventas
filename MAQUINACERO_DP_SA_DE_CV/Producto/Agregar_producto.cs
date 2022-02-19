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

    public partial class Agregar_producto : Form
    {
        private bool fracciones, fracciones1, conversion, conversion1;
        private bool funcion;
        private string codigo;
        Consultas CN = new Consultas();
        ClaseBase CB = new ClaseBase();
        public Agregar_producto(bool _funcion, string _codigo)
        {
            InitializeComponent();
            codigo = _codigo;
            funcion = _funcion;
        }

        private void Agregar_producto_Load(object sender, EventArgs e)
        {
            fracciones = false;
            ListarTipo();
            ListarFormas();
            ListarMaterial();
            ListarUnidad();

            if (funcion)
            {
                btnAgregar.Visible = false;
                btnAgregarOtro.Visible = false;
                txtCodigo.Enabled = false;
                txtCodigo.Text = codigo;
                DataTable aux = CN.Consulta("SELECT p.Codigo, f.Tipo, f.Descripcion as Forma, ma.Descripcion as Material, p.Medida, me.Descripcion as Unidad, p.meComercial as'Medida comercial', me2.Descripcion as 'Unidad comercial', p.Precio, p.Ubicacion FROM Producto as p inner join Forma as f on p.ID_forma = f.ID_forma inner join Material as ma on ma.ID_material = p.ID_material inner join Medida as me on p.ID_medida = me.ID_medida inner join Medida as me2 on me2.ID_medida = p.ID_medida2 WHERE p.Codigo = '" + codigo + "';");
                if (aux.Rows.Count > 0)
                {
                    DataRow row = aux.Rows[0];
                    cmbTipo.Text = row["Tipo"].ToString();
                    ListarFormas();
                    if(cmbForma.Enabled == true)
                        cmbForma.Text = row["Forma"].ToString();
                    cmbMaterial.Text = row["Material"].ToString();
                    cmbUnidad.Text = row["Unidad"].ToString();
                    cmbUnidadComercial.Text = row["Unidad comercial"].ToString();
                    txtMedida.Text = row["Medida"].ToString();
                    txtMedComercial.Text = row["Medida comercial"].ToString();
                    txtPrecio.Text = row["Precio"].ToString();
                    txtUbicacion.Text = row["Ubicacion"].ToString();
                }
            }
            else
            {
                btnModificar.Visible = false;
            }
        }

        #region Eventos

        #region Key press

        private void txtMedida_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (cmbTipo.Text == "BARRA" && (cmbForma.Text == "SOLERA" || cmbForma.Text == "REDONDO HUECO"))
            {
                if ((c < '0' || c > '9') && c != '/' && c != ' ' && c != '\b' && c != '.' && c != 'x' && c != 'X')
                {
                    e.Handled = true;
                    return;
                }
                int esp = 0, punt = 0, x = 0, dia = 0;
                for (int i = 0; i < txtMedida.TextLength; i++)
                {
                    if (txtMedida.Text[i] == ' ')
                        esp++;
                    else if (txtMedida.Text[i] == 'x' || txtMedida.Text[i] == 'X')
                        x++;
                    else if (txtMedida.Text[i] == '.')
                        punt++;
                    else if (txtMedida.Text[i] == '/')
                        dia++;
                }
                if (c == ' ' && (esp >= 4 || esp >= (3 + dia)))
                    e.Handled = true;
                else if ((c == 'x' || c == 'X') && x >= 1)
                    e.Handled = true;
                else if (c == '.' && punt >= 2)
                    e.Handled = true;
                else if (c == '/' && dia >= 2)
                    e.Handled = true;
            }
            else if (fracciones)
            {
                e.Handled = CB.validarFraccion(e.KeyChar, txtMedida);
            }
            else if (conversion)
            {
                e.Handled = CB.validarFloat(e.KeyChar, txtMedida);
            }
            if (txtMedida.TextLength >= 30 && c != '\b')
                e.Handled = true;
        }

        private void txtUbicacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (txtUbicacion.TextLength >= 10 && c != '\b')
                e.Handled = true;
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = CB.validarFloat(e.KeyChar, txtPrecio);
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (c == ' ')
                e.Handled = true;
            if (txtCodigo.TextLength >= 15 && c != '\b')
                e.Handled = true;
        }

        private void txtMedComercial_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (fracciones1)
            {
                e.Handled = CB.validarFraccion(e.KeyChar, txtMedComercial);
            }
            else if (conversion1)
            {
                e.Handled = CB.validarFloat(e.KeyChar, txtMedComercial);
            }
            if (txtMedComercial.TextLength >= 30 && c != '\b')
                e.Handled = true;
        }

        #endregion

        #region Click

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (agregar())
                this.Close();
        }

        private void btnAgregarOtro_Click(object sender, EventArgs e)
        {
            if (agregar())
            {
                txtCodigo.Text = "";
                MessageBox.Show("Producto agregado");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            bool v = false;
            if (txtCodigo.Text == "") v = true;
            if (txtMedida.Text == "") v = true;
            if (txtUbicacion.Text == "") v = true;
            if (txtMedComercial.Text == "") v = true;
            if (txtPrecio.Text == "") v = true;
            if (txtMedida.TextLength == 0 || txtMedComercial.TextLength == 0)
            {
                v = true;
            }
            else
            {
                if (!fracciones && conversion && txtMedida.Text[txtMedida.TextLength - 1] == '.') v = true;
                if (!fracciones1 && conversion1 && txtMedComercial.Text[txtMedComercial.TextLength - 1] == '.') v = true;
                if (fracciones && (txtMedida.Text[txtMedida.TextLength - 1] == ' ' || txtMedida.Text[txtMedida.TextLength - 1] == '/')) v = true;
                if (fracciones1 && (txtMedComercial.Text[txtMedComercial.TextLength - 1] == ' ' || txtMedComercial.Text[txtMedComercial.TextLength - 1] == '/')) v = true;
            }
            if (v)
            {
                MessageBox.Show("Error: llene todos los campos correctamente");
                return;
            }
            String con = "UPDATE Producto SET ID_forma = (select ID_forma from Forma where Descripcion " + (cmbForma.Enabled ? (" = '" + cmbForma.Text + '\'') : ("is null")) + " " + " and Tipo = '" + cmbTipo.Text + "'), ID_material = (select ID_material from Material where Descripcion = '" + cmbMaterial.Text + "'), Medida = '" + txtMedida.Text.ToUpper() + "', ID_medida = (select ID_medida from Medida where Descripcion = '" + cmbUnidad.Text + "'), Ubicacion = '" + txtUbicacion.Text.ToUpper() + "', meComercial = '" + txtMedComercial.Text.ToUpper() + "', ID_medida2 = (select ID_medida from Medida where Descripcion = '" + cmbUnidadComercial.Text + "'), Precio = '" + txtPrecio.Text + "' WHERE Codigo = '" + codigo + "';";
            CN.Consulta(con);
            this.Close();
        }

        #endregion

        #region Index cahnge

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarFormas();
        }

        private void cmbUnidadComercial_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMedComercial.Text = "";
            ListarFracciones();
        }

        private void cmbUnidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMedida.Text = "";
            ListarFracciones();
        }

        #endregion

        #endregion

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

        private void ListarMaterial()
        {
            cmbMaterial.DataSource = CN.Consulta("SELECT Descripcion FROM Material ORDER BY Descripcion;");
            cmbMaterial.DisplayMember = "Descripcion";
        }

        private void ListarUnidad()
        {
            cmbUnidad.DataSource = CN.Consulta("SELECT Descripcion FROM Medida ORDER BY Descripcion;");
            cmbUnidad.DisplayMember = "Descripcion";
            cmbUnidadComercial.DataSource = CN.Consulta("SELECT Descripcion FROM Medida ORDER BY Descripcion;");
            cmbUnidadComercial.DisplayMember = "Descripcion";
            ListarFracciones();
        }

        private void ListarFracciones()
        {
            DataTable aux = CN.Consulta("SELECT Fraccion FROM Medida WHERE Descripcion = '" + cmbUnidad.Text + "';");
            if (aux.Rows.Count > 0)
            {
                DataRow row = aux.Rows[0];
                if (row["Fraccion"].ToString() == "False")
                    fracciones = false;
                else if (row["Fraccion"].ToString() == "True")
                    fracciones = true;
            }

            aux = CN.Consulta("SELECT COUNT(*) as Cantidad FROM Medida	WHERE Descripcion = '" + cmbUnidad.Text + "' AND Conversion IS NOT NUll;");
            if (aux.Rows.Count > 0)
            {
                DataRow row = aux.Rows[0];
                if (row["Cantidad"].ToString() == "0")
                    conversion = false;
                if (row["Cantidad"].ToString() == "1")
                    conversion = true;
            }

            aux = CN.Consulta("SELECT Fraccion FROM Medida WHERE Descripcion = '" + cmbUnidadComercial.Text + "';");
            if (aux.Rows.Count > 0)
            {
                DataRow row = aux.Rows[0];
                if (row["Fraccion"].ToString() == "False")
                    fracciones1 = false;
                else if (row["Fraccion"].ToString() == "True")
                    fracciones1 = true;
            }

            aux = CN.Consulta("SELECT COUNT(*) as Cantidad FROM Medida	WHERE Descripcion = '" + cmbUnidadComercial.Text + "' AND Conversion IS NOT NUll;");
            if (aux.Rows.Count > 0)
            {
                DataRow row = aux.Rows[0];
                if (row["Cantidad"].ToString() == "0")
                    conversion1 = false;
                if (row["Cantidad"].ToString() == "1")
                    conversion1 = true;
            }
        }
        

        private bool agregar()
        {
            bool v = false;
            if (txtCodigo.Text == "") v = true;
            if (txtMedida.Text == "") v = true;
            if (txtUbicacion.Text == "") v = true;
            if (txtMedComercial.Text == "") v = true;
            if (txtPrecio.Text == "") v = true;
            if (txtMedida.TextLength == 0 || txtMedComercial.TextLength == 0)
            {
                v = true;
            }
            else
            {
                if (!fracciones && conversion && txtMedida.Text[txtMedida.TextLength - 1] == '.') v = true;
                if (!fracciones1 && conversion1 && txtMedComercial.Text[txtMedComercial.TextLength - 1] == '.') v = true;
                if (fracciones && (txtMedida.Text[txtMedida.TextLength - 1] == ' ' || txtMedida.Text[txtMedida.TextLength - 1] == '/')) v = true;
                if (fracciones1 && (txtMedComercial.Text[txtMedComercial.TextLength - 1] == ' ' || txtMedComercial.Text[txtMedComercial.TextLength - 1] == '/')) v = true;
            }
            if (v)
            {
                MessageBox.Show("Error: llene todos los campos correctamente");
                return false;
            }

            DataTable aux = CN.Consulta("SELECT COUNT(*) as Cantidad FROM Producto WHERE Codigo = '" + txtCodigo.Text + "';");
            if (aux.Rows.Count > 0)
            {
                DataRow row = aux.Rows[0];
                if (row["Cantidad"].ToString() != "0")
                {
                    MessageBox.Show("Error: Codigo ya registrado");
                    return false;
                }
            }
            String con = "INSERT INTO Producto(Codigo, ID_forma, ID_material, Medida, ID_medida, Ubicacion, meComercial, ID_medida2, Precio) VALUES ('" + txtCodigo.Text.ToUpper() + "', (select ID_forma from Forma where Descripcion " + (cmbForma.Enabled ? (" = '" + cmbForma.Text + '\'') : ("is null")) + " " + "and Tipo = '" + cmbTipo.Text + "'), (select ID_material from Material where Descripcion = '" + cmbMaterial.Text + "'), '" + txtMedida.Text.ToUpper() + "', (select ID_medida from Medida where Descripcion = '" + cmbUnidad.Text + "'), '" + txtUbicacion.Text.ToUpper() + "', '" + txtMedComercial.Text.ToUpper() + "', (select ID_medida from Medida where Descripcion = '" + cmbUnidadComercial.Text + "'), '" + txtPrecio.Text + "');";
            CN.Consulta(con);
            return true;
        }
    }
}
