using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MAQUINACERO_DP_SA_DE_CV.Clases;
using MAQUINACERO_DP_SA_DE_CV.Conexion;
using MAQUINACERO_DP_SA_DE_CV.Programa;

namespace MAQUINACERO_DP_SA_DE_CV.SalidaAlmacen.Cotización
{
    public partial class SalCotizacionAlmacen : Form
    {
        private Consultas CO = new Consultas();
        private DataTable SC;
        private CCotizacion CC = new CCotizacion();
        private CAlmacen _almacen = new CAlmacen();
        private ClaseBase CB = new ClaseBase();

        public SalCotizacionAlmacen(DataTable form)
        {
            InitializeComponent();
            SC = form;
        }

        private void SalCotizacionAlmacen_Load(object sender, EventArgs e)
        {
            visualizarAlmacen();
        }

        void visualizarAlmacen()
        {
            DataTable aux = CC.getProductos();
            aux.Columns.Add("Metros", typeof(float));
            aux.Columns.Add("Piezas", typeof(float));
            for (int fila = 0; fila < aux.Rows.Count; fila++)
            {
                DataRow row = aux.Rows[fila];
                if (!row.IsNull("Kilogramos"))
                {
                    String codigo = row["Codigo"].ToString();
                    int tipoMaterial = CB.obtenerTipoMaterial(codigo);
                    switch (tipoMaterial)
                    {
                        case 1:
                            row["Piezas"] = float.Parse(row["Kilogramos"].ToString()) / CB.obtenerKilogramosPorPieza(codigo);
                            break;
                        case 2:
                            row["Metros"] = float.Parse(row["Kilogramos"].ToString()) / CB.obtenerKilogramosPorMetro(codigo);
                            row["Piezas"] = float.Parse(row["Metros"].ToString()) / CB.obtenerCantidadPorMetros(codigo);
                            break;
                    }
                }
            }
            tblAlmacen.DataSource = aux;
            tblAlmacen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscar();
            txtBuscar.Focus();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtBuscar.Text == "")
            {
                buscar();
                txtBuscar.Focus();
            }

        }

        void buscar()
        {
            string buscar = txtBuscar.Text.ToUpper(); int espacios = 0;
            if (buscar == "")
            {
                visualizarAlmacen();
                return;
            }
            for (int i = 0; i < buscar.Length; i++)
                if (buscar[i] == ' ')
                    espacios++;
            for (int i = (buscar.Length - 1); i >= 0; i--)
                if (buscar[i] == ' ')
                    espacios--;
                else
                    break;
            String[] palabras = new string[espacios + 1];
            int j = 0;
            for (int i = 0; i <= espacios; i++)
            {
                for (; j < buscar.Length; j++)
                {
                    if (j > 0 && j < (buscar.Length - 1))
                    {
                        if ((buscar[j - 1] >= '0' && buscar[j - 1] <= '9') && (buscar[j + 1] >= '0' && buscar[j + 1] <= '9') && buscar[j] == ' ')
                        {
                            bool band = false;
                            for (int k = (j + 1); k < buscar.Length; k++)
                            {
                                if (buscar[k] == '/')
                                    band = true;
                                else if (buscar[k] == ' ')
                                    break;
                                else if (i == (buscar.Length - 1))
                                    band = false;
                            }
                            if (band)
                            {
                                palabras[i] += buscar[j];
                                continue;
                            }
                        }
                    }
                    if (buscar[j] == ' ')
                    {
                        j++;
                        break;
                    }
                    palabras[i] += buscar[j];
                }
            }
            String consult = "SELECT p.Codigo, f.Tipo, f.Descripcion as Forma, ma.Descripcion as Material, p.Medida, me.Descripcion as Unidad, p.meComercial as 'Comercial', me2.Descripcion as 'Unidad comercial', p.Precio, p.Ubicacion, a.Kilogramos FROM Almacen as a INNER JOIN Producto as p ON a.Codigo = p.Codigo INNER JOIN Forma as f ON f.ID_forma = p.ID_forma INNER JOIN Material as ma ON p.ID_material = ma.ID_material INNER JOIN Medida as me ON me.ID_medida = p.ID_medida INNER JOIN Medida as me2 ON me2.ID_medida = p.ID_medida2 WHERE (p.Codigo = '" + palabras[0] + "' or f.Tipo like '%" + palabras[0] + "%' or f.Descripcion like '%" + palabras[0] + "%' or ma.Descripcion like '%" + palabras[0] + "%' or p.Medida like '%" + palabras[0] + "%' or me.Descripcion like '%" + palabras[0] + "%' or p.Ubicacion like '%" + palabras[0] + "%' or a.Kilogramos like '%" + palabras[0] + "%' or p.meComercial like '%" + palabras[0] + "%' or me2.Descripcion like '%" + palabras[0] + "%' or p.Precio like '%" + palabras[0] + "%')";
            for (int i = 1; i <= espacios; i++)
            {
                consult += " AND (p.Codigo = '" + palabras[i] + "' or f.Tipo like '%" + palabras[i] + "%' or f.Descripcion like '%" + palabras[i] + "%' or ma.Descripcion like '%" + palabras[i] + "%' or p.Medida like '%" + palabras[i] + "%' or me.Descripcion like '%" + palabras[i] + "%' or p.Ubicacion like '%" + palabras[i] + "%' or a.Kilogramos like '%" + palabras[i] + "%' or p.meComercial like '%" + palabras[i] + "%' or me2.Descripcion like '%" + palabras[i] + "%' or p.Precio like '%" + palabras[i] + "%')";
            }
            consult += " ORDER BY f.Descripcion";
            DataTable aux = CO.Consulta(consult);
            if (aux.Rows.Count == 0)
            {
                for (int i = 0; i <= espacios; i++)
                    palabras[i] = null;
                j = 0;
                for (int i = 0; i <= espacios; i++)
                {
                    for (; j < buscar.Length; j++)
                    {
                        if (buscar[j] == ' ')
                        {
                            j++;
                            break;
                        }
                        palabras[i] += buscar[j];
                    }
                }
                consult = "SELECT p.Codigo, f.Tipo, f.Descripcion as Forma, ma.Descripcion as Material, p.Medida, me.Descripcion as Unidad, p.meComercial as 'Comercial', me2.Descripcion as 'Unidad comercial', p.Precio, p.Ubicacion, a.Kilogramos FROM Almacen as a INNER JOIN Producto as p ON a.Codigo = p.Codigo INNER JOIN Forma as f ON f.ID_forma = p.ID_forma INNER JOIN Material as ma ON p.ID_material = ma.ID_material INNER JOIN Medida as me ON me.ID_medida = p.ID_medida INNER JOIN Medida as me2 ON me2.ID_medida = p.ID_medida2 WHERE (p.Codigo = '" + palabras[0] + "' or f.Tipo like '%" + palabras[0] + "%' or f.Descripcion like '%" + palabras[0] + "%' or ma.Descripcion like '%" + palabras[0] + "%' or p.Medida like '%" + palabras[0] + "%' or me.Descripcion like '%" + palabras[0] + "%' or p.Ubicacion like '%" + palabras[0] + "%' or a.Kilogramos like '%" + palabras[0] + "%' or p.meComercial like '%" + palabras[0] + "%' or me2.Descripcion like '%" + palabras[0] + "%' or p.Precio like '%" + palabras[0] + "%')";
                for (int i = 1; i <= espacios; i++)
                {
                    consult += " AND (p.Codigo = '" + palabras[i] + "' or f.Tipo like '%" + palabras[i] + "%' or f.Descripcion like '%" + palabras[i] + "%' or ma.Descripcion like '%" + palabras[i] + "%' or p.Medida like '%" + palabras[i] + "%' or me.Descripcion like '%" + palabras[i] + "%' or p.Ubicacion like '%" + palabras[i] + "%' or a.Kilogramos like '%" + palabras[i] + "%' or p.meComercial like '%" + palabras[i] + "%' or me2.Descripcion like '%" + palabras[i] + "%' or p.Precio like '%" + palabras[i] + "%')";
                }
                consult += " ORDER BY f.Descripcion";
                aux = CO.Consulta(consult);
            }
            aux.Columns.Add("Metros", typeof(float));
            aux.Columns.Add("Cantidad", typeof(float));
            for (int fila = 0; fila < aux.Rows.Count; fila++)
            {
                DataRow row = aux.Rows[fila];
                float metros = _almacen.ObtenerMetros(row["Codigo"].ToString());
                row["Metros"] = metros;
                row["Cantidad"] = _almacen.barras(row["Codigo"].ToString(), metros);
            }
            tblAlmacen.DataSource = aux;
            tblAlmacen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = tblAlmacen.SelectedRows;
            if (rows.Count == 0)
            {
                MessageBox.Show("No se selecciono ninguna fila");
                return;
            }
            for (int i = (rows.Count - 1); i >= 0; i--)
            {
                String codigo = tblAlmacen.Rows[tblAlmacen.SelectedRows[i].Index].Cells[0].Value.ToString();
                SalCotizacionAgregar pro = new SalCotizacionAgregar(SC, codigo, false, 0);
                pro.StartPosition = FormStartPosition.CenterScreen;
                pro.ShowDialog();
            }
        }

        private void SalCotizacionAlmacen_Resize(object sender, EventArgs e)
        {
            Size size = this.Size;
            btnAgregar.Location = new Point(size.Width - 184, size.Height - 74);
            btnCerrar.Location = new Point(size.Width - 103, size.Height - 74);
            tblAlmacen.Size = new Size(size.Width - 40, size.Height - 118);
        }
    }
}
