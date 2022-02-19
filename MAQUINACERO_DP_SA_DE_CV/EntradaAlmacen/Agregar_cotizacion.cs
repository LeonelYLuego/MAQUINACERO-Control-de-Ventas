using MAQUINACERO_DP_SA_DE_CV.Clases;
using MAQUINACERO_DP_SA_DE_CV.Conexion;
using MAQUINACERO_DP_SA_DE_CV.Programa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAQUINACERO_DP_SA_DE_CV.EntradaAlmacen
{
    public partial class Agregar_cotizacion : Form
    {
        private Cotizacion Coti;
        private int Funcion;
        private Consultas CN = new Consultas();
        private ClaseBase CB = new ClaseBase();
        private String codigo;
        private float medida, meComercial;
        private bool funcionVentana;

        public Agregar_cotizacion(Cotizacion mfrm, String Codigo, bool Funcion)
        {
            InitializeComponent();
            Coti = mfrm;
            codigo = Codigo;
            funcionVentana = Funcion;
        }

        private void Agregar_cotizacion_Load(object sender, EventArgs e)
        {
            if (!funcionVentana)
            {
                btnAgregar.Location = new Point(294, 71);
                btnNoAgregar.Location = new Point(377, 71);
                lbCantidad.Location = new Point(246, 44);
                txtCantidad.Location = new Point(294, 41);
                lbCanatidadBarra.Location = new Point(27, 74);
                txtCantidadBarra.Location = new Point(85, 71);
                this.Size = new Size(480, 142);
                lbPrecio.Visible = false;
                txtPrecio.Visible = false;
            }
            txtDescripcion.Enabled = false;
            DataTable datos = CN.Consulta("SELECT f.Tipo, f.Descripcion as Forma, ma.Descripcion as Material, p.Medida, me.Descripcion as Unidad, p.Precio FROM Producto as p inner join Forma as f on p.ID_forma = f.ID_forma inner join Material as ma on ma.ID_material = p.ID_material inner join Medida as me on p.ID_medida = me.ID_medida inner join Medida as me2 on me2.ID_medida = p.ID_medida2 WHERE p.Codigo = '" + codigo + "';");
            if (datos.Rows.Count > 0)
            {
                DataRow row = datos.Rows[0];
                //txtDescripcion.Text = row["Tipo"].ToString() + ' ' + row["Forma"].ToString() + ' ' + row["Medida"] + ' ' + row["Unidad"];
                txtPrecio.Text = row["Precio"].ToString();
                txtDescripcion.Text = CB.obtenerDescripcion(codigo);
            }
            else
            {
                if (MessageBox.Show("Producto no encontrado\n¿Desesas agregarlo?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    Agregar_producto ap = new Agregar_producto(false, "");
                    ap.StartPosition = FormStartPosition.CenterScreen;
                    ap.ShowDialog();
                    datos = CN.Consulta("SELECT f.Tipo, f.Descripcion as Forma, ma.Descripcion as Material, p.Medida, me.Descripcion as Unidad, p.Precio FROM Producto as p inner join Forma as f on p.ID_forma = f.ID_forma inner join Material as ma on ma.ID_material = p.ID_material inner join Medida as me on p.ID_medida = me.ID_medida inner join Medida as me2 on me2.ID_medida = p.ID_medida2 WHERE p.Codigo = '" + codigo + "';");
                    if (datos.Rows.Count > 0)
                    {
                        DataRow row = datos.Rows[0];
                        txtDescripcion.Text = row["Tipo"].ToString() + ' ' + row["Forma"].ToString() + ' ' + row["Medida"] + ' ' + row["Unidad"];
                        txtPrecio.Text = row["Precio"].ToString();
                    }
                    else
                        this.Close();
                }
                else
                {
                    this.Close();
                }
            }
            Funcion = CB.obtenerTipoMaterial(codigo);
            switch (Funcion)
            {
                case 1:
                    medida = CB.obtenerKilogramosPorPieza(codigo);
                    break;
                case 2:
                    medida = CB.obtenerKilogramosPorMetro(codigo);
                    meComercial = CB.obtenerCantidadPorMetros(codigo);
                    break;
            }
            setEnabled();
        }

        private void btnNoAgregar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void setEnabled()
        {
            switch (Funcion)
            {
                case 0:
                    lbCantidad.Visible = false;
                    txtCantidad.Visible = false;
                    lbCanatidadBarra.Visible = false;
                    txtCantidadBarra.Visible = false;
                    break;
                case 1:
                    lbCantidad.Text = "Piezas:";
                    lbCanatidadBarra.Visible = false;
                    txtCantidadBarra.Visible = false;
                    break;
                case 2:
                    if(meComercial == 0)
                    {
                        lbCanatidadBarra.Visible = false;
                        txtCantidadBarra.Visible = false;
                    }
                    break;
            }
            for (int i = 0; i < Coti.tabla.Rows.Count; i++)
            {
                if (codigo == Coti.tabla.Rows[i]["Codigo"].ToString())
                {
                    txtKilogramos.Text = Coti.tabla.Rows[i]["Kilogramos"].ToString();
                    switch (Funcion)
                    {
                        case 1:
                            float aux = float.Parse(txtKilogramos.Text);
                            aux = aux / medida;
                            txtCantidad.Text = aux.ToString();
                            break;
                        case 2:
                            aux = float.Parse(txtKilogramos.Text);
                            txtCantidad.Text = (aux / medida).ToString();
                            if (txtCantidadBarra.Visible)
                                txtCantidadBarra.Text = (float.Parse(txtCantidad.Text) / meComercial).ToString();
                            break;
                    }
                    btnAgregar.Text = "Modificar";
                }
            }
        }

        private void txtKilogramos_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if ((c < '0' || c > '9') && c != '.' & c != '\b')
                e.Handled = true;
        }

        private void txtCantidad_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if ((c < '0' || c > '9') && c != '.' & c != '\b')
                e.Handled = true;
        }

        private void txtCantidadBarra_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if ((c < '0' || c > '9') && c != '.' & c != '\b')
                e.Handled = true;
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if ((c < '0' || c > '9') && c != '.' & c != '\b')
                e.Handled = true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtKilogramos.Text == "")
            {
                MessageBox.Show("Llene correctamente los campos");
                return;
            }
            bool band = true;
            for (int i = 0; i < Coti.tabla.Rows.Count; i++)
            {
                if (codigo == Coti.tabla.Rows[i]["Codigo"].ToString())
                {
                    Coti.tabla.Rows[i]["Kilogramos"] = txtKilogramos.Text;
                    switch (Funcion)
                    {
                        case 1:
                            float aux = float.Parse(txtKilogramos.Text);
                            aux = aux / medida;
                            Coti.tabla.Rows[i]["Piezas"] = aux.ToString();
                            break;
                        case 2:
                            aux = float.Parse(txtKilogramos.Text);
                            Coti.tabla.Rows[i]["Metros"] = (aux / medida).ToString();
                            if (txtCantidadBarra.Visible)
                                Coti.tabla.Rows[i]["Piezas"] = (float.Parse(txtCantidad.Text) / meComercial).ToString();
                            break;
                    }
                    if (funcionVentana)
                        if (txtPrecio.Text != "")
                            Coti.tabla.Rows[i]["Precio"] = txtPrecio.Text;
                    band = false;
                }
            }
            if (band)
            {
                DataTable aux = CN.Consulta("SELECT p.Codigo, f.Tipo, f.Descripcion as Forma, ma.Descripcion as Material, p.Medida, me.Descripcion as Unidad, p.meComercial as'Comercial', me2.Descripcion as 'Unidad comercial', p.Precio, p.Ubicacion FROM Producto as p INNER JOIN Forma as f ON f.ID_forma = p.ID_forma INNER JOIN Material as ma ON p.ID_material = ma.ID_material INNER JOIN Medida as me ON me.ID_medida = p.ID_medida INNER JOIN Medida as me2 ON me2.ID_medida = p.ID_medida2 WHERE p.Codigo = '" + codigo + "' ORDER BY f.Descripcion;");
                if (aux.Rows.Count > 0)
                {
                    aux.Columns.Add("Kilogramos", typeof(float));
                    aux.Columns.Add("Metros", typeof(float));
                    aux.Columns.Add("Piezas", typeof(float));
                    DataRow row = aux.Rows[0];
                    row["Kilogramos"] = txtKilogramos.Text;
                    if (Funcion == 1)
                    {
                        row["Piezas"] = txtCantidad.Text;
                    }
                    else if (Funcion == 2)
                    {
                        row["Metros"] = txtCantidad.Text;
                        CAlmacen CA = new CAlmacen();
                        row["Piezas"] = CA.barras(codigo, float.Parse(txtCantidad.Text));
                    }
                    if (funcionVentana)
                        if(txtPrecio.Text != "")
                            row["Precio"] = txtPrecio.Text;
                    Coti.tabla.ImportRow(row);
                }
            }
            this.Close();
        }

        private void txtKilogramos_TextChanged(object sender, EventArgs e)
        {
            if (!txtKilogramos.Focused)
                return;
            if ((txtKilogramos.Text == "") || (txtKilogramos.TextLength <= 0))
            {
                txtCantidad.Text = "";
                txtCantidadBarra.Text = "";
                return;
            }
            if (txtKilogramos.Text[txtKilogramos.TextLength - 1] == '.')
                return;
            switch (Funcion)
            {
                case 1:
                    float aux = float.Parse(txtKilogramos.Text);
                    aux = aux / medida;
                    txtCantidad.Text = aux.ToString();
                    break;
                case 2:
                    aux = float.Parse(txtKilogramos.Text);
                    txtCantidad.Text = (aux / medida).ToString();
                    if (txtCantidadBarra.Visible)
                        txtCantidadBarra.Text = (float.Parse(txtCantidad.Text) / meComercial).ToString();
                    break;
            }
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            if (!txtCantidad.Focused)
                return;
            if ((txtCantidad.Text == "") || (txtCantidad.TextLength <= 0))
            {
                txtKilogramos.Text = "";
                txtCantidadBarra.Text = "";
                return;
            }
            if (txtCantidad.Text[txtCantidad.TextLength - 1] == '.')
                return;
            switch (Funcion)
            {
                case 1:
                    float aux = float.Parse(txtCantidad.Text);
                    aux = aux * medida;
                    txtKilogramos.Text = aux.ToString();
                    break;
                case 2:
                    aux = float.Parse(txtCantidad.Text);
                    txtKilogramos.Text = (aux * medida).ToString();
                    if (txtCantidadBarra.Visible)
                        txtCantidadBarra.Text = (float.Parse(txtCantidad.Text) / meComercial).ToString();
                    break;
            }
        }

        private void txtCantidadBarra_TextChanged(object sender, EventArgs e)
        {
            if (!txtCantidadBarra.Focused)
                return;
            if ((txtCantidadBarra.Text == "") || (txtCantidadBarra.TextLength <= 0))
            {
                txtKilogramos.Text = "";
                txtCantidad.Text = "";
                return;
            }
            if (txtCantidadBarra.Text[txtCantidadBarra.TextLength - 1] == '.')
                return;
            switch (Funcion)
            {
                case 2:
                    float aux = float.Parse(txtCantidadBarra.Text);
                    txtKilogramos.Text = (aux * medida * meComercial).ToString();
                    txtCantidad.Text = (aux * meComercial).ToString();
                    break;
            }
        }
    }
}
