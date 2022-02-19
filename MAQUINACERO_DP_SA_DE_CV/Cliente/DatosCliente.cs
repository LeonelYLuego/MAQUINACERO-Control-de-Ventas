using MAQUINACERO_DP_SA_DE_CV.Hoja_de_control;
using MAQUINACERO_DP_SA_DE_CV.SalidaAlmacen.Cotización;
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
    public partial class DatosCliente : Form
    {
        private CCliente CC = new CCliente();
        private CotizacioExtras CE;
        private HojaDeControlExtra HDCE;
        private int funcionVentana = 0;
        public DatosCliente()
        {
            InitializeComponent();
            btnSeleccionar.Visible = false;
        }

        public DatosCliente(CotizacioExtras _CE)
        {
            InitializeComponent();
            CE = _CE;
            funcionVentana = 1;
        }

        public DatosCliente(HojaDeControlExtra _HDCE)
        {
            InitializeComponent();
            HDCE = _HDCE;
            funcionVentana = 2;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DatosCliente_Load(object sender, EventArgs e)
        {
            VisualizarTabla();
        }

        private void VisualizarTabla()
        {
            tblClientes.DataSource = CC.obtenerClientes();
            tblClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarCliente AC = new AgregarCliente(0);
            AC.StartPosition = FormStartPosition.CenterScreen;
            AC.ShowDialog();
            VisualizarTabla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(tblClientes.SelectedRows.Count <= 0)
            {
                MessageBox.Show("No se selecciono ninguna fila");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Se eliminara el cliente con todas sus compras.\n¿Estas seguro de eliminar este cliente?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.Yes)
            {
                for (int i = 0; i < tblClientes.SelectedRows.Count; i++)
                {
                    DataGridViewRow row = tblClientes.Rows[tblClientes.SelectedRows[i].Index];
                    int ID_cliente = CC.obtenerID_cliente(row.Cells["Nombre"].Value.ToString(), row.Cells["Telefono"].Value.ToString(), row.Cells["CorreoElectronico"].Value.ToString(), row.Cells["Calle"].Value.ToString(), int.Parse(row.Cells["Numero"].Value.ToString()), row.Cells["Colonia"].Value.ToString(), row.Cells["Estado"].Value.ToString(), row.Cells["Municipio"].Value.ToString(), int.Parse(row.Cells["CodigoPostal"].Value.ToString()), row.Cells["RFC"].Value.ToString());
                    CC.eliminarCliente(ID_cliente);
                }
                VisualizarTabla();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if(tblClientes.SelectedRows.Count != 1)
            {
                MessageBox.Show("No se selecciono ninguna fila");
                return;
            }
            DataGridViewRow row = tblClientes.Rows[tblClientes.SelectedRows[0].Index];
            int ID_cliente = CC.obtenerID_cliente(row.Cells["Nombre"].Value.ToString(), row.Cells["Telefono"].Value.ToString(), row.Cells["CorreoElectronico"].Value.ToString(), row.Cells["Calle"].Value.ToString(), int.Parse(row.Cells["Numero"].Value.ToString()), row.Cells["Colonia"].Value.ToString(), row.Cells["Estado"].Value.ToString(), row.Cells["Municipio"].Value.ToString(), int.Parse(row.Cells["CodigoPostal"].Value.ToString()), row.Cells["RFC"].Value.ToString());
            AgregarCliente AC = new AgregarCliente(ID_cliente);
            AC.StartPosition = FormStartPosition.CenterScreen;
            AC.ShowDialog();
            VisualizarTabla();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if(tblClientes.SelectedRows.Count != 1)
            {
                MessageBox.Show("No se selecciono ninguna fila");
                return;
            }
            DataGridViewRow row = tblClientes.Rows[tblClientes.SelectedRows[0].Index];
            int ID_cliente = CC.obtenerID_cliente(row.Cells["Nombre"].Value.ToString(), row.Cells["Telefono"].Value.ToString(), row.Cells["CorreoElectronico"].Value.ToString(), row.Cells["Calle"].Value.ToString(), int.Parse(row.Cells["Numero"].Value.ToString()), row.Cells["Colonia"].Value.ToString(), row.Cells["Estado"].Value.ToString(), row.Cells["Municipio"].Value.ToString(), int.Parse(row.Cells["CodigoPostal"].Value.ToString()), row.Cells["RFC"].Value.ToString());
            string cliente = tblClientes.Rows[tblClientes.SelectedRows[0].Index].Cells["Nombre"].Value.ToString();
            switch (funcionVentana)
            {
                case 1:
                    CE.ID_cliente = ID_cliente;
                    CE.txtCliente.Text = cliente;
                    break;
                case 2:
                    HDCE.txtCliente.Text = cliente;
                    HDCE.ID_cliente = ID_cliente;
                    break;
            }
            
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            tblClientes.DataSource = CC.buscarCliente(txtBuscar.Text);
        }

        private void DatosCliente_Resize(object sender, EventArgs e)
        {
            Size size = this.Size;
            btnEditar.Location = new Point(size.Width - 265, 12);
            btnEliminar.Location = new Point(size.Width - 184, 12);
            btnAgregar.Location = new Point(size.Width - 103, 12);
            btnRegresar.Location = new Point(size.Width - 103, size.Height - 74);
            btnSeleccionar.Location = new Point(size.Width - 184, size.Height - 74);
            tblClientes.Size = new Size(size.Width - 40, size.Height - 121);
        }
    }
}
