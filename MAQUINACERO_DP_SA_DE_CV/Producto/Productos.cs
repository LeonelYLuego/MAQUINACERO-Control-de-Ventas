using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MAQUINACERO_DP_SA_DE_CV.Conexion;

namespace MAQUINACERO_DP_SA_DE_CV.Programa
{
    public partial class Productos : Form
    {
        private Consultas CO = new Consultas();
        int _aplicacion;
        public Productos(int aplicacion)
        {
            InitializeComponent();
            _aplicacion = aplicacion;
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            visualizarProductos();
            if (_aplicacion == 1)
            {
                btnAgregar.Visible = false;
                btnEliminar.Visible = false;
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Productos_Resize(object sender, EventArgs e)
        {
            Size tm = this.Size;
            btnRegresar.Location = new Point(tm.Width - 103, tm.Height - 74);
            btnEliminar.Location = new Point(tm.Width - 184, tm.Height - 74);
            btnAgregar.Location = new Point(tm.Width - 103, 23);
            btnEditar.Location = new Point(tm.Width - 184, 23);
            tblProductos.Size = new Size(tm.Width - 40, tm.Height - 147);
        }

        private void visualizarProductos()
        {
            tblProductos.DataSource = CO.selectProducto();
            tblProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Agregar_producto ap = new Agregar_producto(false, null);
            ap.StartPosition = FormStartPosition.CenterScreen;
            ap.ShowDialog();
            visualizarProductos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (tblProductos.SelectedRows.Count != 1)
            {
                MessageBox.Show("No se selecciono ninguna fila");
                return;
            }
            int fila = tblProductos.CurrentRow.Index;
            DialogResult dialogResult = MessageBox.Show("¿Estas seguro de eliminar este producto?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.Yes)
            {
                Consultas CN = new Consultas();
                DataTable aux = CN.Consulta("SELECT COUNT(*) as Cantidad FROM Almacen WHERE Codigo = '" + tblProductos.Rows[fila].Cells[0].Value.ToString() + "';");
                if (aux.Rows.Count > 0)
                {
                    DataRow row = aux.Rows[0];
                    if (row["Cantidad"].ToString() != "0")
                    {
                        MessageBox.Show("Error: Producto registrado en almacen, no se puede eliminar");
                        return;
                    }
                }
                String consult = "DELETE FROM Producto WHERE Codigo = '" + tblProductos.Rows[fila].Cells[0].Value.ToString() + "';";
                CN.Consulta(consult);
                visualizarProductos();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscar();
            txtBuscar.Focus();
        }

        void buscar()
        {
            string buscar = txtBuscar.Text.ToUpper(); int espacios = 0;
            if (buscar == "")
            {
                visualizarProductos();
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
            String consult = "SELECT p.Codigo, f.Tipo, f.Descripcion as Forma, ma.Descripcion as Material, p.Medida, me.Descripcion as Unidad, p.meComercial as'Comercial', me2.Descripcion as 'Unidad comercial', p.Precio, p.Ubicacion FROM Producto as p inner join Forma as f on p.ID_forma = f.ID_forma inner join Material as ma on ma.ID_material = p.ID_material inner join Medida as me on p.ID_medida = me.ID_medida inner join Medida as me2 on me2.ID_medida = p.ID_medida2 WHERE (p.Codigo = '" + palabras[0] + "' or f.Tipo like '%" + palabras[0] + "%' or f.Descripcion like '%" + palabras[0] + "%' or ma.Descripcion like '%" + palabras[0] + "%' or p.Medida like '%" + palabras[0] + "%' or me.Descripcion like '%" + palabras[0] + "%' or p.Ubicacion like '%" + palabras[0] + "%' or p.meComercial like '%" + palabras[0] + "%' or me2.Descripcion like '%" + palabras[0] + "%' or p.Precio like '%" + palabras[0] + "%')";
            for (int i = 1; i <= espacios; i++)
            {
                consult += " AND (p.Codigo = '" + palabras[i] + "' or f.Tipo like '%" + palabras[i] + "%' or f.Descripcion like '%" + palabras[i] + "%' or ma.Descripcion like '%" + palabras[i] + "%' or p.Medida like '%" + palabras[i] + "%' or me.Descripcion like '%" + palabras[i] + "%' or p.Ubicacion like '%" + palabras[i] + "%' or p.meComercial like '%" + palabras[i] + "%' or me2.Descripcion like '%" + palabras[i] + "%' or p.Precio like '%" + palabras[i] + "%')";
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
                consult = "SELECT p.Codigo, f.Tipo, f.Descripcion as Forma, ma.Descripcion as Material, p.Medida, me.Descripcion as Unidad, p.meComercial as'Comercial', me2.Descripcion as 'Unidad comercial', p.Precio, p.Ubicacion FROM Producto as p inner join Forma as f on p.ID_forma = f.ID_forma inner join Material as ma on ma.ID_material = p.ID_material inner join Medida as me on p.ID_medida = me.ID_medida inner join Medida as me2 on me2.ID_medida = p.ID_medida2 WHERE (p.Codigo = '" + palabras[0] + "' or f.Tipo like '%" + palabras[0] + "%' or f.Descripcion like '%" + palabras[0] + "%' or ma.Descripcion like '%" + palabras[0] + "%' or p.Medida like '%" + palabras[0] + "%' or me.Descripcion like '%" + palabras[0] + "%' or p.Ubicacion like '%" + palabras[0] + "%' or p.meComercial like '%" + palabras[0] + "%' or me2.Descripcion like '%" + palabras[0] + "%' or p.Precio like '%" + palabras[0] + "%')";
                for (int i = 1; i <= espacios; i++)
                {
                    consult += " AND (p.Codigo = '" + palabras[i] + "' or f.Tipo like '%" + palabras[i] + "%' or f.Descripcion like '%" + palabras[i] + "%' or ma.Descripcion like '%" + palabras[i] + "%' or p.Medida like '%" + palabras[i] + "%' or me.Descripcion like '%" + palabras[i] + "%' or p.Ubicacion like '%" + palabras[i] + "%' or p.meComercial like '%" + palabras[i] + "%' or me2.Descripcion like '%" + palabras[i] + "%' or p.Precio like '%" + palabras[i] + "%')";
                }
                consult += " ORDER BY f.Descripcion";
                aux = CO.Consulta(consult);
            }
            tblProductos.DataSource = aux;
            tblProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtBuscar.Text == "")
                buscar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (tblProductos.SelectedRows.Count != 1)
            {
                MessageBox.Show("No se selecciono ninguna fila");
                return;
            }
            Agregar_producto ap = new Agregar_producto(true, tblProductos.Rows[tblProductos.CurrentRow.Index].Cells[0].Value.ToString());
            ap.StartPosition = FormStartPosition.CenterScreen;
            ap.ShowDialog();
            visualizarProductos();
        }
    }
}
