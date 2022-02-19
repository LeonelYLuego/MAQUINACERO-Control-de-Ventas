using MAQUINACERO_DP_SA_DE_CV.Conexion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAQUINACERO_DP_SA_DE_CV.SalidaAlmacen.Cotización
{
    public partial class SalCotizacion : Form
    {
        public DataTable tabla;
        private Consultas CN = new Consultas();
        private CotizacionSalida CS = new CotizacionSalida();
        public SalCotizacion()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void SalCotizacion_Load(object sender, EventArgs e)
        {
            tabla = CN.Consulta("SELECT p.Codigo, f.Tipo, f.Descripcion as Forma, ma.Descripcion as Material, p.Medida, me.Descripcion as Unidad, p.meComercial as 'Comercial', me2.Descripcion as 'Unidad comercial', p.Precio, p.Ubicacion FROM Producto as p inner join Forma as f on p.ID_forma = f.ID_forma inner join Material as ma on ma.ID_material = p.ID_material inner join Medida as me on p.ID_medida = me.ID_medida inner join Medida as me2 on me2.ID_medida = p.ID_medida2 WHERE p.Codigo = '';");
            tabla.Columns.Add("Kilogramos Almacen", typeof(float));
            tabla.Columns.Add("Metros Almacen", typeof(float));
            tabla.Columns.Add("Tramos Completos Almacen", typeof(float));
            tabla.Columns.Add("Kilogramos Cotizacion", typeof(float));
            tabla.Columns.Add("Metros Cotizacion", typeof(float));
            tabla.Columns.Add("Tramos Completos Cotizacion", typeof(float));
            tabla.Columns.Add("Piezas", typeof(int));
            tabla.Columns.Add("Medida Pieza", typeof(String));
            tabla.Columns.Add("Unidad Pieza", typeof(String));
            tabla.Columns.Add("Num. Cortes", typeof(int));
            tabla.Columns.Add("Precio Por Corte", typeof(float));
            tabla.Columns.Add("Precio Total Corte", typeof(float));
            tabla.Columns.Add("Criterio", typeof(String));
            tabla.Columns.Add("Precio Cotizacion", typeof(float));
            tabla.Columns.Add("Precio Cotizacion MXN", typeof(float));
            tblCotizacion.DataSource = tabla;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            SalCotizacionAlmacen sca = new SalCotizacionAlmacen(tabla);
            this.AddOwnedForm(sca);
            sca.StartPosition = FormStartPosition.CenterScreen;
            sca.Show();
        }

        private void SalCotizacion_Resize(object sender, EventArgs e)
        {
            Size siz = this.Size;
            tblCotizacion.Size = new Size(siz.Width - 40, siz.Height - 149);
            btnAgregarProducto.Location = new Point(siz.Width - 130, btnAgregarProducto.Location.Y);
            btnModificar.Location = new Point(siz.Width - 292, btnModificar.Location.Y);
            btnEliminar.Location = new Point(siz.Width - 211, btnEliminar.Location.Y);
            btnImportar.Location = new Point(siz.Width - 265, siz.Height - 74);
            btnRegresar.Location = new Point(siz.Width - 103, siz.Height - 74);
            btnOrdenCompra.Location = new Point(siz.Width - 265, siz.Height - 103);
            txtPrecioTotalMXN.Location = new Point(siz.Width - 455, siz.Height - 100);
            txtPrecioTotal.Location = new Point(siz.Width - 713, siz.Height - 100);
            lbPrecioTotal.Location = new Point(siz.Width - 804, siz.Height - 97);
            lbPrecioMXN.Location = new Point(siz.Width - 543, siz.Height - 97);
            if(Size.Width < 816)
            {
                lbPrecioMXN.Visible = false;
                txtPrecioTotalMXN.Visible = false;
                txtPrecioTotal.Location = new Point(siz.Width - 455, siz.Height - 100);
                lbPrecioTotal.Location = new Point(siz.Width - 543, siz.Height - 97);
            }
            else
            {
                lbPrecioMXN.Visible = true;
                txtPrecioTotalMXN.Visible = true;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = tblCotizacion.SelectedRows;
            if (rows.Count == 0)
            {
                MessageBox.Show("No se selecciono ninguna fila");
                return;
            }
            for (int i = (rows.Count - 1); i >= 0; i--)
            {
                tabla.Rows.RemoveAt(tblCotizacion.SelectedRows[i].Index);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = tblCotizacion.SelectedRows;
            if (rows.Count == 0)
            {
                MessageBox.Show("No se selecciono ninguna fila");
                return;
            }
            for (int i = (rows.Count - 1); i >= 0; i--)
            {
                SalCotizacionAgregar SCA = new SalCotizacionAgregar(tabla, tblCotizacion.Rows[tblCotizacion.SelectedRows[i].Index].Cells["Codigo"].Value.ToString(), true, tblCotizacion.SelectedRows[i].Index);
                SCA.StartPosition = FormStartPosition.CenterScreen;
                SCA.ShowDialog();
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                string line = "";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader file = new StreamReader(openFileDialog.FileName.ToString()))
                    {
                        while ((line = file.ReadLine()) != null)
                        {
                            if (line == "Codigo\tTipo\tForma\tMaterial\tMedida\tUnidad\tComercial\tUnidad Comercial\tPrecio\tUbicacion\tKilogramos Almacen\tMetros Almacen\tTramos Completos Almacen\tKilogramos Cotizacion\tMetros Cotizacion\tTramos Completos Cotizacion\tPiezas\tMedida Pieza\tUnidad Pieza\tNum. Cortes\tPrecio Por Corte\tPrecio Total Corte\tCriterio\tPrecio Cotizacion\tPrecio Cotizacion MXN")
                                continue;
                            int cont = 0;
                            for (int letra = 0; letra < line.Length; letra++)
                                if (line[letra] == '\t')
                                    cont++;
                            if (cont != 25)
                                continue;
                            cont = 0; int letra2 = 0, letrai = 0;
                            String[] palabras = new String[25];
                            for (int palabra = 0; palabra < 25; palabra++)
                            {
                                string aux = "";
                                for (; letra2 < line.Length; letra2++)
                                {
                                    aux = "";
                                    if (line[letra2] == '\t' || letra2 == (line.Length - 1))
                                    {
                                        for (int letra3 = letrai; letra3 <= letra2; letra3++)
                                        {
                                            if (line[letra3] == '\t')
                                                break;
                                            aux += line[letra3];
                                        }
                                        letrai = letra2 + 1;
                                        break;
                                    }
                                }
                                letra2++;
                                palabras[palabra] = aux;
                            }
                            DataRow row = tabla.NewRow();
                            for (int i = 0; i < 25; i++)
                            {
                                if (palabras[i] == "")
                                    continue;
                                row[i] = palabras[i];
                            }
                            if (CS.comprobarDolar())
                            {
                                row[24] = (CS.obtenerPrecioDolar() * float.Parse(palabras[23])).ToString();
                            }
                            else
                            {
                                row[24] = DBNull.Value;
                            }
                            tabla.Rows.Add(row);
                        }
                    }
                }
            }
        }

        private void tblCotizacion_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            float cuenta = 0;
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                cuenta += float.Parse(tabla.Rows[i]["Precio Cotizacion"].ToString());
            }
            txtPrecioTotal.Text = cuenta.ToString();
            if (CS.comprobarDolar())
            {
                txtPrecioTotalMXN.Text = (cuenta * CS.obtenerPrecioDolar()).ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CotizacioExtras CE = new CotizacioExtras(tabla);
            CE.StartPosition = FormStartPosition.CenterScreen;
            CE.ShowDialog();
        }
    }
}
