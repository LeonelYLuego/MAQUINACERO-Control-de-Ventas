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
using MAQUINACERO_DP_SA_DE_CV.Clases;
using MAQUINACERO_DP_SA_DE_CV.Conexion;
using MAQUINACERO_DP_SA_DE_CV.EntradaAlmacen;
using MAQUINACERO_DP_SA_DE_CV.SalidaAlmacen.Cotización;

namespace MAQUINACERO_DP_SA_DE_CV.Programa
{
    public partial class Cotizacion : Form
    {
        private CCotizacion CC = new CCotizacion();
        private Consultas CN = new Consultas();
        public DataTable tabla;
        private bool importar;
        private bool funcion;
        public Cotizacion(bool _funcion)
        {
            InitializeComponent();
            importar = false;
            funcion = _funcion;
        }

        private void Cotizacion_Load(object sender, EventArgs e)
        {
            tabla = CC.getSetCotizacion();
            tabla.Columns.Add("Metros", typeof(float));
            tabla.Columns.Add("Piezas", typeof(float));
            tblCotizacion.DataSource = tabla;
            tblCotizacion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (funcion)
            {
                btnTxt.Visible = false;
                this.Text = "Entrada de material";
                this.BackColor = Color.White;
            }
            else
            {
                btnAgregar.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            Cotizacion_almacen pro = new Cotizacion_almacen(this, funcion);
            this.AddOwnedForm(pro);
            pro.StartPosition = FormStartPosition.CenterScreen;
            pro.Show();
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
                String codigo = tblCotizacion.Rows[tblCotizacion.SelectedRows[i].Index].Cells[0].Value.ToString();
                Agregar_cotizacion pro = new Agregar_cotizacion(this, codigo, funcion);
                pro.StartPosition = FormStartPosition.CenterScreen;
                pro.ShowDialog();
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

        private void btnTxt_Click(object sender, EventArgs e)
        {
            string rutaCompleta, texto;
            using (var fd = new FolderBrowserDialog())
            {
                if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fd.SelectedPath))
                {
                    DateTime dateTime = new DateTime();
                    dateTime = DateTime.Now;
                    string strDate = Convert.ToDateTime(dateTime).ToString("_dd_MM_yy_h_mm_ss");

                    rutaCompleta = @" " + fd.SelectedPath + "\\OrdenDeCompra" + strDate + ".txt";
                    Console.WriteLine(rutaCompleta);
                    using (StreamWriter mylogs = File.AppendText(rutaCompleta))
                    {
                        strDate = Convert.ToDateTime(dateTime).ToString("dd/MM/yy h:mm:ss tt");
                        mylogs.WriteLine(strDate);
                        mylogs.WriteLine("Codigo\tTipo\tForma\tMaterial\tMedida\tUnidad\tComercial\tUnidad\tKilogramos\tMetros\tPiezas");
                        for (int i = 0; i < tabla.Rows.Count; i++)
                        {
                            texto = tabla.Rows[i]["Codigo"].ToString() + '\t';
                            texto += tabla.Rows[i]["Tipo"].ToString() + '\t';
                            texto += tabla.Rows[i]["Forma"].ToString() + '\t';
                            texto += tabla.Rows[i]["Material"].ToString() + '\t';
                            texto += tabla.Rows[i]["Medida"].ToString() + '\t';
                            texto += tabla.Rows[i]["Unidad"].ToString() + '\t';
                            texto += tabla.Rows[i]["Comercial"].ToString() + '\t';
                            texto += tabla.Rows[i]["Unidad comercial"].ToString() + '\t';
                            texto += tabla.Rows[i]["Kilogramos"].ToString() + '\t';
                            texto += tabla.Rows[i]["Metros"].ToString() + '\t';
                            texto += tabla.Rows[i]["Piezas"].ToString();
                            mylogs.WriteLine(texto);
                        }
                        mylogs.Close();
                    }
                }
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            if(importar || tabla.Rows.Count != 0)
            {
                MessageBox.Show("No se puede importar");
                return;
            }
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
                            if (line == "Codigo\tTipo\tForma\tMaterial\tMedida\tUnidad\tComercial\tUnidad\tKilogramos\tMetros\tPiezas")
                                continue;
                            int cont = 0;
                            for (int letra = 0; letra < line.Length; letra++)
                                if (line[letra] == '\t')
                                    cont++;
                            if (cont != 10)
                                continue;
                            cont = 0; int letra2 = 0, letrai = 0;
                            String[] palabras = new String[11];
                            for(int palabra = 0; palabra < 11; palabra++)
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
                            for(int i = 0; i < 8; i++)
                            {
                                row[i] = palabras[i];
                            }
                            DataTable TablaAux = CN.Consulta("select Precio, Ubicacion FROM Producto WHERE Codigo = '" + row[0].ToString() + "';");
                            if (TablaAux.Rows.Count > 0)
                            {
                                row["Precio"] = TablaAux.Rows[0]["Precio"];
                                row["Ubicacion"] = TablaAux.Rows[0]["Ubicacion"];
                            }
                            else
                            {
                                row["Precio"] = 0;
                                row["Ubicacion"] = "-";
                            }
                            if(palabras[8] != "")
                                row["Kilogramos"] = float.Parse(palabras[8]);
                            if (palabras[9] != "")
                                row["Metros"] = float.Parse(palabras[9]);
                            if (palabras[10] != "")
                                row["Piezas"] = float.Parse(palabras[10]);
                            tabla.Rows.Add(row);
                        }
                    }
                }
            }
            importar = true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("El almacen se modificara\n¿Desesas continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.No)
            {
                return;
            }
            for (int fila = 0; fila < tabla.Rows.Count; fila++)
            {
                String codigo = tabla.Rows[fila][0].ToString();
                DataTable datos = CN.Consulta("SELECT Precio FROM Producto WHERE Codigo = '"+ codigo + "';");
                if(datos.Rows.Count <= 0)
                {
                    if (MessageBox.Show("El producto " + codigo + " no se encontro\n¿Desesas agregarlo?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        Agregar_producto ap = new Agregar_producto(false, "");
                        ap.StartPosition = FormStartPosition.CenterScreen;
                        ap.ShowDialog();
                        datos = CN.Consulta("SELECT Precio FROM Producto WHERE Codigo = '" + codigo + "';");
                        if (datos.Rows.Count <= 0)
                        {
                            MessageBox.Show(codigo + " no se pudo agregegar al Almacen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }
                    }
                    else
                    {
                        MessageBox.Show(codigo + " no se pudo agregegar al Almacen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }
                }
                datos = CN.Consulta("SELECT * FROM Almacen WHERE Codigo = '" + codigo + "';");
                if (datos.Rows.Count <= 0)
                    CN.Consulta("INSERT INTO Almacen(ID_almacen, Codigo, Kilogramos) VALUES ((select max(ID_almacen) from Almacen) + 1, '" + codigo + "', 0);");
                DateTime dateTime = new DateTime();
                dateTime = DateTime.Now;
                String dia = Convert.ToDateTime(dateTime).ToString("yyyy-MM-dd");
                CN.Consulta("INSERT INTO Entrada(ID_entrada, ID_almacen, Kilogramos, Fecha) VALUES ((select max(ID_entrada) from Entrada) + 1, (select max(ID_almacen) from Almacen where Codigo = '" + codigo + "'), " + tabla.Rows[fila]["Kilogramos"].ToString() + ", '" + dia + "');");
                CN.Consulta("UPDATE Almacen SET Kilogramos = (select isnull(sum(e.kilogramos),0) from almacen as a inner join entrada as e on a.ID_almacen = e.ID_almacen where a.Codigo = '" + codigo + "')-(select isnull(sum(s.Kilogramos),0) from almacen as a inner join salida as s on a.ID_almacen = s.ID_almacen where a.Codigo = '" + codigo + "') WHERE Codigo= '" + codigo + "';");
                CN.Consulta("UPDATE Producto SET Precio = " + tabla.Rows[fila]["Precio"] + " WHERE Codigo = '" + codigo + "';");
            }
            MessageBox.Show("Actualizacion del almacen exitosa");
            this.Close();
        }

        private void Cotizacion_Resize(object sender, EventArgs e)
        {
            Size size = this.Size;
            btnEliminar.Location = new Point(size.Width - 294, 12);
            btnModificar.Location = new Point(size.Width - 213, 12);
            btnAgregarProducto.Location = new Point(size.Width - 132, 12);
            btnRegresar.Location = new Point(size.Width - 103, size.Height - 71);
            btnImportar.Location = new Point(size.Width - 184, size.Height - 71);
            btnAgregar.Location = new Point(size.Width - 307, size.Height - 71);
            btnTxt.Location = new Point(size.Width - 329, size.Height - 71);
            tblCotizacion.Size = new Size(size.Width - 40, size.Height - 118);
            Console.WriteLine(size);
        }
    }
}
