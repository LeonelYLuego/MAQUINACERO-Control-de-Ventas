using MAQUINACERO_DP_SA_DE_CV.Hoja_de_control;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace MAQUINACERO_DP_SA_DE_CV.SalidaAlmacen.Cotización
{
    class DocumentoHojaControl
    {
        private HojaDeControlExtra HDCE;
        private CotizacionSalida CS = new CotizacionSalida();
        private DataTable Tabla;

        public DocumentoHojaControl()
        {

        }

        public void Generardocumento(DataTable _tabla, HojaDeControlExtra _HDCE)
        {
            HDCE = _HDCE;
            Tabla = _tabla;
            Word.Application objWord;
            Word.Document ObjDocument;
            try
            {
                objWord = (Word.Application)Activator.CreateInstance(Type.GetTypeFromProgID("Word.Application"));
                object missing = System.Reflection.Missing.Value;
                object abrirDoc = HDCE.txtUbicacion.Text + '\\' + HDCE.txtNombreArchivo.Text + ".docx";
                object readOnly = false;
                object isVisible = true;
                if (File.Exists(CS.obtenerUbicacionArchivo("Hoja de control")))
                {
                    File.Copy(CS.obtenerUbicacionArchivo("Hoja de control"), abrirDoc.ToString());
                    ObjDocument = objWord.Documents.Open(ref abrirDoc, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible, ref missing, ref missing, ref missing, ref missing);
                    Exportar(HDCE.txtUbicacion.Text + '\\' + HDCE.txtNombreArchivo.Text, _tabla);
                }
                else
                {
                    MessageBox.Show("No se pudo generar el archivo");
                    return;
                }
            } catch(Exception e)
            {
                MessageBox.Show("No se pudo generar el archivo, " + e);
                return;
            }
            DocumentoDatos(ObjDocument);
            objWord.Selection.Collapse();
            objWord.Visible = true;
        }

        private void DocumentoDatos(Word.Document doc)
        {
            RemplazarMarcaTexto(doc, "fecha", FechaLetras());
            RemplazarMarcaTexto(doc, "noHojaControl", HDCE.txtNoHojacControl.Text);
            if(HDCE.txtNumCotizacion.Text != "")
                RemplazarMarcaTexto(doc, "noCotizacion", "No. Cotizacion: " + HDCE.txtNumCotizacion.Text);
            RemplazarMarcaTexto(doc, "nombreCliente", HDCE.txtCliente.Text);
            if(HDCE.txtCliente.Text != "")
            {
                Cliente.CCliente CC = new Cliente.CCliente();
                DataTable datos = CC.obtenerCliente(HDCE.ID_cliente);
                if(datos.Rows.Count > 0)
                    RemplazarMarcaTexto(doc, "telefonoCliente", "Telefono: " + datos.Rows[0]["Telefono"].ToString());
            }
            if(CrearTabla(doc, "tabla", 5, Tabla.Rows.Count + 1))
            {
                String[] titulos = new string[5] { "Codigo", "Descripción", "Piezas", "Medida", "Ubicacion" };
                ColocarTitulosTabla(doc.Tables[1], titulos);
                ColocarDatosTabla(doc.Tables[1]);
            }
            if (HDCE.chkEnvio.Checked)
                RemplazarMarcaTexto(doc, "direccionCliente", ObtenerDireccion());
        }

        private String ObtenerDireccion()
        {
            Cliente.CCliente CC = new Cliente.CCliente();
            DataTable cliente = CC.obtenerCliente(HDCE.ID_cliente);
            if(cliente.Rows.Count > 0)
            {
                DataRow datos = cliente.Rows[0];
                String aux = datos["Calle"].ToString() + ", #" + datos["Numero"].ToString() + ", " + datos["Colonia"] + '\n';
                aux += datos["Estado"].ToString() + ", " + datos["Municipio"].ToString() + '\n';
                aux += "Tiempo de envío: " + HDCE.txtTiempo.Text + " Hrs.";
                return aux;
            }
            return "";
        }

        private void ColocarDatosTabla(Word.Table docTabla)
        {
            for(int i = 0; i < Tabla.Rows.Count; i++)
            {
                String codigo = Tabla.Rows[i]["Codigo"].ToString();
                docTabla.Cell(i + 2, 1).Range.Text = codigo;
                docTabla.Cell(i + 2, 2).Range.Text = CS.obtenerDescripcion(codigo);
                docTabla.Cell(i + 2, 3).Range.Text = Tabla.Rows[i]["Piezas"].ToString();
                docTabla.Cell(i + 2, 4).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                if (Tabla.Rows[i]["Metros Cotizacion"].ToString() != "")
                    docTabla.Cell(i + 2, 4).Range.Text = float.Parse(Tabla.Rows[i]["Metros Cotizacion"].ToString()).ToString("0.00") + " M";
                else
                {
                    if (Tabla.Rows[i]["Medida Pieza"].ToString() != "")
                        docTabla.Cell(i + 2, 4).Range.Text = float.Parse(Tabla.Rows[i]["Medida Pieza"].ToString()).ToString("0.00") + ' ' + Tabla.Rows[i]["Unidad Pieza"].ToString();
                }
                docTabla.Cell(i + 2, 5).Range.Text = Tabla.Rows[i]["Ubicacion"].ToString();
            }
            docTabla.AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitContent);
        }

        private void ColocarTitulosTabla(Word.Table docTabla, String[] titulos)
        {
            for(int i = 1; i <= titulos.Length; i++)
            {
                docTabla.Cell(1, i).Range.Text = titulos[i - 1];
            }
        }

        private bool CrearTabla(Word.Document doc, String nombreMarca, int columnas, int filas)
        {
            if (doc.Bookmarks.Exists(nombreMarca))
            {
                Object name = nombreMarca;
                Microsoft.Office.Interop.Word.Range range = doc.Bookmarks.get_Item(ref name).Range;
                doc.Tables.Add(range, filas, columnas);
                doc.Tables[1].Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                doc.Tables[1].Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                object newRange = range;
                doc.Bookmarks.Add(nombreMarca, ref newRange);
                return true;
            }
            return false;
        }

        private void RemplazarMarcaTexto(Word.Document doc, String nombreMarca, String texto)
        {
            if (doc.Bookmarks.Exists(nombreMarca))
            {
                Object name = nombreMarca;
                Microsoft.Office.Interop.Word.Range range = doc.Bookmarks.get_Item(ref name).Range;
                range.Text = texto;
                object newRange = range;
                doc.Bookmarks.Add(nombreMarca, ref newRange);
            }
        }

        private String FechaLetras()
        {
            DateTime dateTime = new DateTime();
            dateTime = DateTime.Now;
            return dateTime.ToString("D", CultureInfo.CreateSpecificCulture("es-ES"));
        }

        private void Exportar(String rutaCompleta, DataTable tabla)
        {
            rutaCompleta += ".txt";
            using (StreamWriter mylogs = File.AppendText(rutaCompleta))
            {
                DateTime dateTime = new DateTime();
                dateTime = DateTime.Now;
                string strDate = Convert.ToDateTime(dateTime).ToString("dd/MM/yy h:mm:ss tt");
                mylogs.WriteLine(strDate);
                mylogs.WriteLine(HDCE.txtNoHojacControl.Text);
                mylogs.WriteLine("Codigo\tTipo\tForma\tMaterial\tMedida\tUnidad\tComercial\tUnidad Comercial\tPrecio\tUbicacion\tKilogramos Almacen\tMetros Almacen\tTramos Completos Almacen\tKilogramos Cotizacion\tMetros Cotizacion\tTramos Completos Cotizacion\tPiezas\tMedida Pieza\tUnidad Pieza\tNum. Cortes\tPrecio Por Corte\tPrecio Total Corte\tCriterio\tPrecio Cotizacion\tPrecio Cotizacion MXN");
                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    String texto = "";
                    for (int j = 0; j < 25; j++)
                    {
                        texto += tabla.Rows[i][j].ToString() + '\t';
                    }
                    mylogs.WriteLine(texto);
                }
                mylogs.Close();
            }
        }
    }
}
