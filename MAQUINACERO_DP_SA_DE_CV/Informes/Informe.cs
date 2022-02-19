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

namespace MAQUINACERO_DP_SA_DE_CV.Informes
{
    public partial class Informe : Form
    {
        private DataTable tabla;
        private Consultas CN = new Consultas();
        public Informe()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            int caso = 0;
            String fechaInicio = dateInicio.Value.ToString("yyyy-MM-dd");
            String fechaFin = dateFin.Value.ToString("yyyy-MM-dd");
            if (rbtnEntrada.Checked)
                caso = 1;
            else
                caso = 3;
            if (rbtnPorProducto.Checked)
                caso += 1;
            switch (caso)
            {
                case 1:
                    tabla = CN.Consulta("SELECT p.Codigo, f.Tipo, f.Descripcion as Forma, ma.Descripcion as Material, p.Medida, me.Descripcion as Unidad, e.Kilogramos, e.Fecha FROM Entrada as e INNER JOIN Almacen as a ON e.ID_almacen = a.ID_almacen INNER JOIN Producto as p ON p.Codigo = a.Codigo INNER JOIN Forma as f ON f.ID_forma = p.ID_forma INNER JOIN Material as ma ON p.ID_material = ma.ID_material INNER JOIN Medida as me ON me.ID_medida = p.ID_medida WHERE e.Fecha BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "' ORDER BY e.Fecha, p.ID_forma;");
                    break;
                case 2:
                    tabla = EntradaPorProducto(fechaInicio, fechaFin);
                    break;
                case 3:
                    tabla = CN.Consulta("SELECT p.Codigo, f.Tipo, f.Descripcion as Forma, ma.Descripcion as Material, p.Medida, me.Descripcion as Unidad, s.Kilogramos, s.Fecha, c.Nombre FROM Salida as s INNER JOIN Almacen as a ON s.ID_almacen = a.ID_almacen INNER JOIN Producto as p ON p.Codigo = a.Codigo INNER JOIN Forma as f ON f.ID_forma = p.ID_forma INNER JOIN Material as ma ON p.ID_material = ma.ID_material INNER JOIN Medida as me ON me.ID_medida = p.ID_medida LEFT JOIN Cliente as c ON c.ID_cliente = s.ID_cliente WHERE s.Fecha BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "' ORDER BY s.Fecha, p.ID_forma;");
                    break;
                case 4:
                    tabla = SalidaPorProducto(fechaInicio, fechaFin);
                    break;
            }
            tblInforme.DataSource = tabla;
            tblInforme.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private DataTable EntradaPorProducto(String FechaIni, String FechaFin)
        {
            DataTable aux, tabla1 = null;
            DataTable distinto = CN.Consulta("SELECT DISTINCT ID_almacen FROM Entrada WHERE Fecha BETWEEN '" + FechaIni + "' AND '" + FechaFin + "';");
            for(int i = 0; i < distinto.Rows.Count; i++)
            {
                aux = CN.Consulta("SELECT p.Codigo, f.Tipo, f.Descripcion as Forma, ma.Descripcion as Material, p.Medida, me.Descripcion as Unidad, SUM(e.Kilogramos) as Kilogramos FROM Entrada as e INNER JOIN Almacen as a ON e.ID_almacen = a.ID_almacen INNER JOIN Producto as p ON p.Codigo = a.Codigo INNER JOIN Forma as f ON f.ID_forma = p.ID_forma INNER JOIN Material as ma ON p.ID_material = ma.ID_material INNER JOIN Medida as me ON me.ID_medida = p.ID_medida WHERE (e.Fecha BETWEEN '" + FechaIni + "' AND '" + FechaFin + "') AND a.ID_almacen = " + distinto.Rows[i]["ID_almacen"] + " GROUP BY p.codigo, f.Tipo, f.Descripcion, ma.Descripcion, p.Medida, me.Descripcion, a.ID_almacen ORDER BY a.ID_almacen;");
                if (i == 0)
                    tabla1 = aux;
                else
                    if (aux.Rows.Count > 0)
                        tabla1.ImportRow(aux.Rows[0]);
            }
            return tabla1;
        }

        private DataTable SalidaPorProducto(String FechaIni, String FechaFin)
        {
            DataTable aux, tabla1 = null;
            DataTable distinto = CN.Consulta("SELECT DISTINCT ID_almacen FROM Salida WHERE Fecha BETWEEN '" + FechaIni + "' AND '" + FechaFin + "';");
            for (int i = 0; i < distinto.Rows.Count; i++)
            {
                aux = CN.Consulta("SELECT p.Codigo, f.Tipo, f.Descripcion as Forma, ma.Descripcion as Material, p.Medida, me.Descripcion as Unidad, SUM(s.Kilogramos) as Kilogramos FROM Salida as s INNER JOIN Almacen as a ON s.ID_almacen = a.ID_almacen INNER JOIN Producto as p ON p.Codigo = a.Codigo INNER JOIN Forma as f ON f.ID_forma = p.ID_forma INNER JOIN Material as ma ON p.ID_material = ma.ID_material INNER JOIN Medida as me ON me.ID_medida = p.ID_medida WHERE (s.Fecha BETWEEN '" + FechaIni + "' AND '" + FechaFin + "') AND a.ID_almacen = " + distinto.Rows[i]["ID_almacen"] + " GROUP BY p.codigo, f.Tipo, f.Descripcion, ma.Descripcion, p.Medida, me.Descripcion, a.ID_almacen ORDER BY a.ID_almacen;");
                if (i == 0)
                    tabla1 = aux;
                else
                    if (aux.Rows.Count > 0)
                    tabla1.ImportRow(aux.Rows[0]);
            }
            return tabla1;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (tabla == null)
            {
                MessageBox.Show("No hay ningun dato que exportar");
                return;
            }
            string rutaCompleta, texto = "";
            using (var fd = new FolderBrowserDialog())
            {
                if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fd.SelectedPath))
                {
                    DateTime dateTime = new DateTime();
                    dateTime = DateTime.Now;
                    string strDate = Convert.ToDateTime(dateTime).ToString("_dd_MM_yy_h_mm_ss");

                    rutaCompleta = @" " + fd.SelectedPath + "\\Informe" + strDate + ".txt";
                    Console.WriteLine(rutaCompleta);
                    using (StreamWriter mylogs = File.AppendText(rutaCompleta))
                    {
                        strDate = Convert.ToDateTime(dateTime).ToString("dd/MM/yy h:mm:ss tt");
                        mylogs.WriteLine(strDate);
                        for(int i = 0; i < tabla.Columns.Count; i++)
                        {
                            texto += tabla.Columns[i].Caption + '\t';
                        }
                        mylogs.WriteLine(texto);
                        for (int i = 0; i < tabla.Rows.Count; i++)
                        {
                            texto = "";
                            for (int j = 0; j < tabla.Columns.Count; j++)
                            {
                                if (tabla.Rows[i][j].GetType() == typeof(DateTime))
                                {
                                    DateTime dt;
                                    if (DateTime.TryParse(tabla.Rows[i][j].ToString(), out dt))
                                        texto += dt.ToString("dd/MM/yyyy") + '\t';
                                }
                                else
                                {
                                    texto += tabla.Rows[i][j].ToString() + '\t';
                                }
                            }
                            mylogs.WriteLine(texto);
                        }
                        mylogs.Close();
                    }
                }
            }
        }

        private void Informe_Resize(object sender, EventArgs e)
        {
            Size size = this.Size;
            btnExportar.Location = new Point(size.Width - 184, size.Height - 74);
            btnRegresar.Location = new Point(size.Width - 103, size.Height - 74);
            tblInforme.Size = new Size(size.Width - 40, size.Height - 140);
            Console.WriteLine(size);
        }
    }
}
