using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAQUINACERO_DP_SA_DE_CV.SalidaAlmacen.Cotización
{
    public partial class SalCotizacionAgregar : Form
    {
        private CotizacionSalida CS = new CotizacionSalida();
        private String codigo;
        private int tipoMaterial, index;
        private float metros, cantidad, kilogramos, divisa;
        private bool fraccion, funcionVentana;
        private DataTable tabla;

        public SalCotizacionAgregar(DataTable SC, String _codigo, bool funcion, int _index)
        {
            InitializeComponent();
            index = _index;
            codigo = _codigo;
            tabla = SC;
            funcionVentana = funcion;
        }

        #region Eventos
        private void SalCotizacionAgregar_Load(object sender, EventArgs e)
        {
            txtDescripcion.Enabled = false;
            txtDescripcion.Text = CS.obtenerDescripcion(codigo);
            tipoMaterial = CS.obtenerTipoMaterial(codigo);
            switch (tipoMaterial)
            {
                case 0:
                    txtCantidad.Enabled = false;
                    txtMetros.Enabled = false;
                    break;
                case 1:
                    txtMetros.Enabled = false;
                    cantidad = CS.obtenerKilogramosPorPieza(codigo);
                    break;
                case 2:
                    cantidad = CS.obtenerCantidadPorMetros(codigo);
                    metros = CS.obtenerKilogramosPorMetro(codigo);
                    break;
            }
            kilogramos = CS.obtenerKilogramos(codigo);
            txtKilogramosAlmacen.Text = kilogramos.ToString();
            txtKilogramosAlmacenRestantes.Text = kilogramos.ToString();
            lbAKilogramosAlmacen.Visible = false;
            cmbCriterio.SelectedIndex = 0;
            txtPrecioCorte.Text = "0";
            txtPrecioCorteTotal.Text = "0";

            checkPiezas.Enabled = txtMetros.Enabled;
            numPiezas.Enabled = false;
            txtMedidaPieza.Enabled = false;
            cmbUnidadMedida.Enabled = false;
            cmbUnidadMedida.DataSource = CS.obtenerUnidadSinConversion();
            cmbUnidadMedida.DisplayMember = "Descripcion";
            fraccion = CS.obtenerUnidadFracciones(cmbUnidadMedida.Text);

            if (CS.obtenerPrecioCorte(codigo) != 0)
                txtPrecioCorte.Text = CS.obtenerPrecioCorte(codigo).ToString();
            divisa = CS.obtenerPrecioDolar();
            if (divisa == 0)
            {
                txtPrecioMXN.Text = "Precio del dolar no actualizado.";
            }
            limpiarValores();
            if (funcionVentana)
            {
                btnAgregar.Visible = false;
                if (tabla.Rows[index]["Piezas"].ToString() == "1")
                {
                    txtKilogramos.Text = tabla.Rows[index]["Kilogramos Cotizacion"].ToString();
                    if ((txtKilogramos.Text == "") || (txtKilogramos.TextLength <= 0))
                    {
                        limpiarValores();
                        return;
                    }
                    if (txtKilogramos.Text[txtKilogramos.TextLength - 1] == '.')
                        return;
                    switch (tipoMaterial)
                    {
                        case 1:
                            float aux = float.Parse(txtKilogramos.Text);
                            aux = aux / cantidad;
                            txtCantidad.Text = aux.ToString();
                            break;
                        case 2:
                            aux = float.Parse(txtKilogramos.Text);
                            txtMetros.Text = (aux / metros).ToString();
                            txtCantidad.Text = (float.Parse(txtMetros.Text) / cantidad).ToString();
                            break;
                    }
                    calPrecio();
                }
                else
                {
                    checkPiezas.Checked = true;
                    numPiezas.Value = decimal.Parse(tabla.Rows[index]["Piezas"].ToString());
                    numCortes.Value = decimal.Parse(tabla.Rows[index]["Num. Cortes"].ToString());
                    txtMedidaPieza.Text = tabla.Rows[index]["Medida Pieza"].ToString();
                    cmbUnidadMedida.Text = tabla.Rows[index]["Unidad Pieza"].ToString();
                    txtPrecioCorte.Text = tabla.Rows[index]["Precio Por Corte"].ToString();
                }
                txtPrecioCorteTotal.Text = tabla.Rows[index]["Precio Total Corte"].ToString();
                cmbCriterio.Text = tabla.Rows[index]["Criterio"].ToString();
                txtPrecio.Text = tabla.Rows[index]["Precio Cotizacion"].ToString();
                if (txtPrecioMXN.Text == "")
                    txtPrecioMXN.Text = tabla.Rows[index]["Precio MXN"].ToString();
            }
            else
                btnEditar.Visible = false;
        }

        //KeyPress

        private void txtMetros_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = CS.validarFloat(e.KeyChar, txtMetros);
        }

        private void txtKilogramos_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = CS.validarFloat(e.KeyChar, txtKilogramos);
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = CS.validarFloat(e.KeyChar, txtCantidad);
        }

        private void txtMedidaPieza_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (fraccion)
                e.Handled = CS.validarFraccion(e.KeyChar, txtMedidaPieza);
            else
                e.Handled = CS.validarFloat(e.KeyChar, txtMedidaPieza);
        }

        private void txtPrecioCorteTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = CS.validarFloat(e.KeyChar, txtPrecioCorteTotal);
        }

        private void txtPrecioCorte_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = CS.validarFloat(e.KeyChar, txtPrecioCorte);
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = CS.validarFloat(e.KeyChar, txtPrecio);
        }

        private void txtPrecioMXN_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = CS.validarFloat(e.KeyChar, txtPrecioMXN);
        }

        //TextChange

        private void txtKilogramos_TextChanged(object sender, EventArgs e)
        {
            if (!txtKilogramos.Focused)
                return;
            if ((txtKilogramos.Text == "") || (txtKilogramos.TextLength <= 0))
            {
                limpiarValores();
                return;
            }
            if (txtKilogramos.Text[txtKilogramos.TextLength - 1] == '.')
                return;
            switch (tipoMaterial)
            {
                case 1:
                    float aux = float.Parse(txtKilogramos.Text);
                    aux = aux / cantidad;
                    txtCantidad.Text = aux.ToString();
                    break;
                case 2:
                    aux = float.Parse(txtKilogramos.Text);
                    txtMetros.Text = (aux / metros).ToString();
                    txtCantidad.Text = (float.Parse(txtMetros.Text) / cantidad).ToString();
                    break;
            }
            calPrecio();
        }

        private void txtMetros_TextChanged(object sender, EventArgs e)
        {
            if (!txtMetros.Focused)
                return;
            if ((txtMetros.Text == "") || (txtMetros.TextLength <= 0))
            {
                limpiarValores();
                return;
            }
            if (txtMetros.Text[txtMetros.TextLength - 1] == '.')
                return;
            switch (tipoMaterial)
            {
                case 2:
                    float aux = float.Parse(txtMetros.Text);
                    txtKilogramos.Text = (aux * metros).ToString();
                    txtCantidad.Text = (float.Parse(txtMetros.Text) / cantidad).ToString();
                    break;
            }
            txtKilogramosAlmacenRestantes.Text = (kilogramos - float.Parse(txtKilogramos.Text)).ToString();
            calPrecio();
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            if (!txtCantidad.Focused)
                return;
            if ((txtCantidad.Text == "") || (txtCantidad.TextLength <= 0))
            {
                limpiarValores();
                return;
            }
            if (txtCantidad.Text[txtCantidad.TextLength - 1] == '.')
                return;
            switch (tipoMaterial)
            {
                case 1:
                    float aux = float.Parse(txtCantidad.Text);
                    aux = aux * cantidad;
                    txtKilogramos.Text = aux.ToString();
                    break;
                case 2:
                    aux = float.Parse(txtCantidad.Text);
                    txtKilogramos.Text = (aux * metros * cantidad).ToString();
                    txtMetros.Text = (aux * cantidad).ToString();
                    break;
            }
            calPrecio();
        }

        private void txtPrecioCorte_TextChanged(object sender, EventArgs e)
        {
            calPrecio();
        }

        private void txtMedidaPieza_TextChanged(object sender, EventArgs e)
        {
            if (txtMedidaPieza.Text == "")
            {
                limpiarValores();
                return;
            }
            calPrecio();
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            if (!txtPrecio.Focused)
                return;
            if (cmbCriterio.SelectedIndex == 3)
                if (txtPrecio.Text != "")
                    txtPrecioMXN.Text = (float.Parse(txtPrecio.Text) * divisa).ToString();
                else
                    txtPrecioMXN.Text = "0";
        }

        private void txtPrecioMXN_TextChanged(object sender, EventArgs e)
        {
            if (!txtPrecioMXN.Focused)
                return;
            if (cmbCriterio.SelectedIndex == 3)
                if (txtPrecioMXN.Text != "")
                    txtPrecio.Text = (float.Parse(txtPrecioMXN.Text) / divisa).ToString();
                else
                    txtPrecio.Text = "0";
        }

        //Change y leave

        private void cmbCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCriterio.SelectedIndex == 3)
            {
                txtPrecio.Enabled = true;
                if(CS.obtenerPrecioDolar() != 0)
                    txtPrecioMXN.Enabled = true;
            }
            else
            {
                txtPrecio.Enabled = false;
                txtPrecioMXN.Enabled = false;
            }
            calPrecio();
        }

        private void cmbUnidadMedida_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fraccion != CS.obtenerUnidadFracciones(cmbUnidadMedida.Text))
                txtMedidaPieza.Text = "";
            fraccion = CS.obtenerUnidadFracciones(cmbUnidadMedida.Text);
            calPrecio();
        }

        private void numCortes_Leave(object sender, EventArgs e)
        {
            numPiezas.Value = numPiezas.Value + 1;
            numPiezas.Value = numPiezas.Value - 1;
        }

        private void checkPiezas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPiezas.Checked)
            {
                txtKilogramos.Enabled = false;
                txtMetros.Enabled = false;
                txtCantidad.Enabled = false;
                txtMedidaPieza.Enabled = true;
                numPiezas.Enabled = true;
                cmbUnidadMedida.Enabled = true;
            }
            else
            {
                txtKilogramos.Enabled = true;
                txtMetros.Enabled = true;
                txtCantidad.Enabled = true;
                switch (tipoMaterial)
                {
                    case 0:
                        txtCantidad.Enabled = false;
                        txtMetros.Enabled = false;
                        break;
                    case 1:
                        txtMetros.Enabled = false;
                        break;
                }
                cmbUnidadMedida.Enabled = false;
                txtMedidaPieza.Enabled = false;
                numPiezas.Enabled = false;
                txtMedidaPieza.Text = "";
                numPiezas.Value = 1;
            }
            limpiarValores();
        }

        private void numCortes_ValueChanged(object sender, EventArgs e)
        {
            calPrecio();
        }

        private void txtPrecioCorteTotal_TextChanged(object sender, EventArgs e)
        {
            calPrecio();
        }

        private void numCortes_Leave_1(object sender, EventArgs e)
        {
            numCortes.Value = numCortes.Value + 1;
            numCortes.Value = numCortes.Value - 1;
        }

        //Click


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(txtKilogramos.Text == "" || txtPrecio.Text == "" || txtPrecio.Text == "0" || (checkPiezas.Checked && txtPrecioCorte.Text == "" || txtPrecioCorteTotal.Text == ""))
            {
                MessageBox.Show("Llene los campos correctamente");
                return;
            }

            bool result = CS.agregarCotizacionSalida(tabla, codigo, tipoMaterial, txtKilogramos, checkPiezas, numPiezas, txtMedidaPieza, cmbUnidadMedida, txtPrecioCorte, txtPrecioCorteTotal, cmbCriterio, txtPrecio, txtPrecioMXN, numCortes);
            if (result)
                this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtKilogramos.Text == "" || txtPrecio.Text == "" || txtPrecio.Text == "0" || (checkPiezas.Checked && txtPrecioCorte.Text == "" || txtPrecioCorteTotal.Text == ""))
            {
                MessageBox.Show("Llene los campos correctamente");
                return;
            }
            bool result = CS.agregarCotizacionSalida(tabla, codigo, tipoMaterial, txtKilogramos, checkPiezas, numPiezas, txtMedidaPieza, cmbUnidadMedida, txtPrecioCorte, txtPrecioCorteTotal, cmbCriterio, txtPrecio, txtPrecioMXN, numCortes);
            if (result)
            {
                tabla.Rows.RemoveAt(index);
                this.Close();
            }
        }

        #endregion

        private void calPrecio()
        {
            float medida = 0;
            if (!checkPiezas.Checked)
            {
                if (txtKilogramos.Text != "")
                {
                    txtKilogramosAlmacenRestantes.Text = (kilogramos - float.Parse(txtKilogramos.Text)).ToString();
                    if (kilogramos - float.Parse(txtKilogramos.Text) >= 0)
                        lbAKilogramosAlmacen.Visible = false;
                    else
                        lbAKilogramosAlmacen.Visible = true;
                }
            }
            else
            {
                if (txtMedidaPieza.Text == "")
                    return;
                if (fraccion)
                    medida = CS.obtenerFraccion(txtMedidaPieza.Text);
                else
                    medida = float.Parse(txtMedidaPieza.Text);
                medida *= (CS.obtenerConversionAMetros(cmbUnidadMedida.Text) * (int)numPiezas.Value);
                txtMetros.Text = medida.ToString();
                txtKilogramos.Text = (medida * metros).ToString();
                txtCantidad.Text = (float.Parse(txtMetros.Text) / cantidad).ToString();
                txtKilogramosAlmacenRestantes.Text = (kilogramos - float.Parse(txtKilogramos.Text)).ToString();
                if (kilogramos - float.Parse(txtKilogramos.Text) >= 0)
                    lbAKilogramosAlmacen.Visible = false;
                else
                    lbAKilogramosAlmacen.Visible = true;
                if (txtPrecioCorte.Text != "")
                    txtPrecioCorteTotal.Text = (((int)numCortes.Value) * float.Parse(txtPrecioCorte.Text)).ToString();
                else
                    txtPrecioCorteTotal.Text = "0";
            }
            if (txtPrecioCorte.Text == ".")
                return;
            if (txtPrecioCorte.Text != "")
                txtPrecioCorteTotal.Text = (((int)numCortes.Value) * float.Parse(txtPrecioCorte.Text)).ToString();
            if (txtKilogramos.Text == "")
            {
                txtPrecio.Text = "0";
                return;
            }
            float varPrecioCorte = 0;
            if (txtPrecioCorteTotal.Text != "")
                varPrecioCorte = float.Parse(txtPrecioCorteTotal.Text);
            float porcentaje = CS.obtenerPorcentaje(cmbCriterio.SelectedIndex);
            varPrecioCorte = float.Parse(txtKilogramos.Text) * CS.obtenerPrecioPorKilogramos(codigo);
            varPrecioCorte += varPrecioCorte * porcentaje / 100;
            if (cmbCriterio.SelectedIndex != 3)
                if (txtPrecioCorteTotal.Text != "")
                    txtPrecio.Text = (varPrecioCorte + float.Parse(txtPrecioCorteTotal.Text)).ToString();
                else
                    txtPrecio.Text = "0";
            if (divisa != 0)
            {
                if (txtPrecio.Text != "")
                {
                    txtPrecioMXN.Text = (float.Parse(txtPrecio.Text) * divisa).ToString();
                }
            }
        }

        private void limpiarValores()
        {
            txtKilogramos.Text = "";
            txtMetros.Text = "";
            txtCantidad.Text = "";
            txtPrecio.Text = "0";
            txtPrecioMXN.Text = "0";
            txtKilogramosAlmacenRestantes.Text = kilogramos.ToString();
            lbAKilogramosAlmacen.Visible = false;
        }
    }
}
