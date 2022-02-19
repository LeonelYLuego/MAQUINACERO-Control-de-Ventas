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
using MAQUINACERO_DP_SA_DE_CV.Clases;

namespace MAQUINACERO_DP_SA_DE_CV.Programa
{
    public partial class Almacen : Form
    {
        Consultas CO = new Consultas();
        CAlmacen CA = new CAlmacen();
        public Almacen()
        {
            InitializeComponent();
        }

        private void Almacen_Load(object sender, EventArgs e)
        {
            visualizarAlmacen();
        }

        void visualizarAlmacen()
        {
            DataTable aux = CA.VisualizarAlmacen();
            aux.Columns.Add("Metros", typeof(float));
            aux.Columns.Add("Piezas", typeof(float));
            for (int fila = 0; fila < aux.Rows.Count; fila++)
            {
                DataRow row = aux.Rows[fila];
                String codigo = row["Codigo"].ToString();
                switch (CA.obtenerTipoMaterial(codigo))
                {
                    case 1:
                        float kilogramos = float.Parse(row["Kilogramos"].ToString());
                        row["Piezas"] = CA.obtenerKilogramosPorPieza(codigo) * kilogramos;
                        break;
                    case 2:
                        kilogramos = float.Parse(row["Kilogramos"].ToString());
                        kilogramos = kilogramos / CA.obtenerKilogramosPorMetro(codigo);
                        row["Metros"] = kilogramos;
                        row["Piezas"] = kilogramos / CA.obtenerCantidadPorMetros(codigo);
                        break;
                }
            }
            tblAlmacen.DataSource = aux;
            tblAlmacen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscar();
            txtBuscar.Focus();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtBuscar.Text == "")
                buscar();
        }

        private void Almacen_Resize(object sender, EventArgs e)
        {
            Size tm = this.Size;
            btnRegresar.Location = new Point(tm.Width - 103, tm.Height - 74);
            btnEliminar.Location = new Point(tm.Width - 184, tm.Height - 74);
            tblAlmacen.Size = new Size(tm.Width - 40, tm.Height - 147);
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
            aux.Columns.Add("Piezas", typeof(float));
            for (int fila = 0; fila < aux.Rows.Count; fila++)
            {
                DataRow row = aux.Rows[fila];
                String codigo = row["Codigo"].ToString();
                switch (CA.obtenerTipoMaterial(codigo))
                {
                    case 1:
                        float kilogramos = float.Parse(row["Kilogramos"].ToString());
                        row["Piezas"] = CA.obtenerKilogramosPorPieza(codigo) * kilogramos;
                        break;
                    case 2:
                        kilogramos = float.Parse(row["Kilogramos"].ToString());
                        kilogramos = kilogramos / CA.obtenerKilogramosPorMetro(codigo);
                        row["Metros"] = kilogramos;
                        row["Piezas"] = kilogramos / CA.obtenerCantidadPorMetros(codigo);
                        break;
                }
            }
            tblAlmacen.DataSource = aux;
            tblAlmacen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Elimiar de entrada y salida de material
            if (tblAlmacen.SelectedRows.Count != 1)
            {
                MessageBox.Show("No se selecciono ninguna fila");
                return;
            }
            int fila = tblAlmacen.CurrentRow.Index;
            DialogResult dialogResult = MessageBox.Show("Se eliminaran todos los registros de este producto\n¿Estas seguro de eliminar este producto?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.Yes)
            {
                Consultas CN = new Consultas();
                String consult = "DELETE FROM Entrada WHERE ID_almacen = (select max(id_almacen) from Almacen where Codigo = '" + tblAlmacen.Rows[fila].Cells[0].Value.ToString() + "');";
                CN.Consulta(consult);
                consult = "DELETE FROM Salida WHERE ID_almacen = (select max(id_almacen) from Almacen where Codigo = '" + tblAlmacen.Rows[fila].Cells[0].Value.ToString() + "');";
                CN.Consulta(consult);
                consult = "DELETE FROM Almacen WHERE Codigo = '" + tblAlmacen.Rows[fila].Cells[0].Value.ToString() + "';";
                CN.Consulta(consult);
                visualizarAlmacen();
            }
        }
    }
}
