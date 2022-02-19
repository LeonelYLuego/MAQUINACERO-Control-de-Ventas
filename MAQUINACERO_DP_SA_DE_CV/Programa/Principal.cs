using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MAQUINACERO_DP_SA_DE_CV.Cliente;
using MAQUINACERO_DP_SA_DE_CV.Conexion;
using MAQUINACERO_DP_SA_DE_CV.EntradaAlmacen;
using MAQUINACERO_DP_SA_DE_CV.Hoja_de_control;
using MAQUINACERO_DP_SA_DE_CV.Programa.Dirreciones_archivo;
using MAQUINACERO_DP_SA_DE_CV.SalidaAlmacen;
using MAQUINACERO_DP_SA_DE_CV.SalidaAlmacen.Cotización;
using MAQUINACERO_DP_SA_DE_CV.SalidaAlmacen.Criterios;
using MAQUINACERO_DP_SA_DE_CV.SalidaAlmacen.Dolar;
using MAQUINACERO_DP_SA_DE_CV.Informes;
using MAQUINACERO_DP_SA_DE_CV.Usuarios;

namespace MAQUINACERO_DP_SA_DE_CV.Programa
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            ClaseBase CB = new ClaseBase();
            lbADolar.Visible = !CB.comprobarDolar();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            Productos pro = new Productos(0);
            pro.ShowInTaskbar = false;
            pro.StartPosition = FormStartPosition.CenterScreen;
            pro.ShowDialog();
        }

        private void btnFormaAgregar_Click(object sender, EventArgs e)
        {
            Variable_agregar vag = new Variable_agregar("Forma");
            vag.StartPosition = FormStartPosition.CenterScreen;
            vag.ShowDialog();
        }

        private void agregarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Variable_agregar vag = new Variable_agregar("Material");
            vag.StartPosition = FormStartPosition.CenterScreen;
            vag.ShowDialog();
        }

        private void agregarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Variable_agregar vag = new Variable_agregar("Medida");
            vag.StartPosition = FormStartPosition.CenterScreen;
            vag.ShowDialog();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Variable_eliminar vae = new Variable_eliminar("Forma");
            vae.StartPosition = FormStartPosition.CenterScreen;
            vae.ShowDialog();
        }

        private void eliminarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Variable_eliminar vae = new Variable_eliminar("Material");
            vae.StartPosition = FormStartPosition.CenterScreen;
            vae.ShowDialog();
        }

        private void eliminarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Variable_eliminar vae = new Variable_eliminar("Medida");
            vae.StartPosition = FormStartPosition.CenterScreen;
            vae.ShowDialog();
        }

        private void btnAlmacen_Click(object sender, EventArgs e)
        {
            Almacen pro = new Almacen();
            pro.StartPosition = FormStartPosition.CenterScreen;
            pro.ShowDialog();
        }

        private void cotizacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cotizacion ecot = new Cotizacion(false);
            ecot.StartPosition = FormStartPosition.CenterScreen;
            ecot.ShowDialog();
        }

        private void entradaDeMaterialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cotizacion ecot = new Cotizacion(true);
            ecot.StartPosition = FormStartPosition.CenterScreen;
            ecot.ShowDialog();
        }

        private void precioDeCorteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Precio_corte prco = new Precio_corte();
            prco.StartPosition = FormStartPosition.CenterScreen;
            prco.ShowDialog();
        }

        private void btnCotizacion_Click(object sender, EventArgs e)
        {
            SalCotizacion sc = new SalCotizacion();
            sc.StartPosition = FormStartPosition.CenterScreen;
            sc.ShowDialog();
        }

        private void porcentajeDeCriterioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarCriterio mc = new ModificarCriterio();
            mc.StartPosition = FormStartPosition.CenterScreen;
            mc.ShowDialog();
        }

        private void precioDolarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarDolar md = new ModificarDolar(lbADolar);
            md.StartPosition = FormStartPosition.CenterScreen;
            md.ShowDialog();
        }

        private void direccionDePlantillasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DireccionArchivo da = new DireccionArchivo();
            da.StartPosition = FormStartPosition.CenterScreen;
            da.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HojaDeControl hdc = new HojaDeControl();
            hdc.StartPosition = FormStartPosition.CenterScreen;
            hdc.ShowDialog();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            DatosCliente dc = new DatosCliente();
            dc.StartPosition = FormStartPosition.CenterScreen;
            dc.ShowDialog();
        }

        private void btnInfrome_Click(object sender, EventArgs e)
        {
            Informe inf = new Informe();
            inf.StartPosition = FormStartPosition.CenterScreen;
            inf.ShowDialog();
        }

        private void Principal_Resize(object sender, EventArgs e)
        {
            Size size = this.Size;
            lbADolar.Location = new Point(size.Width - 279, 44);
            if (size.Height > 721)
            {
                btnInfrome.Location = new Point(12, 464);
                btnClientes.Location = new Point(12, 569);
            }
            else if (size.Height > 616)
            {
                btnInfrome.Location = new Point(12, 464);
                btnClientes.Location = new Point(195, 44); //195, 149
            }
            else
            {
                btnInfrome.Location = new Point(195, 44);
                btnClientes.Location = new Point(195, 149);
            }
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuario us = new Usuario();
            us.StartPosition = FormStartPosition.CenterScreen;
            us.ShowDialog();
        }
    }
}
