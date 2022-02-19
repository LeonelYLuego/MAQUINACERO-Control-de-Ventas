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
    class Documento
    {
        private CotizacioExtras CE;
        private CotizacionSalida CS = new CotizacionSalida();

        public Documento()
        {

        }

        public void Generardocumento(DataTable tabla, CotizacioExtras _CE)
        {
            CE = _CE;
            Word.Application objWord;
            Word.Document ObjDocument;
            try
            {
                objWord = (Word.Application)Activator.CreateInstance(Type.GetTypeFromProgID("Word.Application"));
                object missing = System.Reflection.Missing.Value;
                object abrirDoc = CE.txtUbicacion.Text + '\\' + CE.txtNombreArchivo.Text + ".docx";
                object readOnly = false;
                object isVisible = true;
                if (File.Exists(CS.obtenerUbicacionArchivo("Cotizacion")))
                {
                    File.Copy(CS.obtenerUbicacionArchivo("Cotizacion"), abrirDoc.ToString());
                    ObjDocument = objWord.Documents.Open(ref abrirDoc, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible, ref missing, ref missing, ref missing, ref missing);
                    Exportar(CE.txtUbicacion.Text + '\\' + CE.txtNombreArchivo.Text, tabla);
                }
                else
                {
                    MessageBox.Show("No se pudo generar el archivo");
                    return;
                }
            } catch(Exception)
            {
                MessageBox.Show("No se pudo generar el archivo");
                return;
            }
            ReplaceBookmarkText(ObjDocument, "fecha", FechaLetras());
            ReplaceBookmarkText(ObjDocument, "numCotizacion", CE.txtNoCompra.Text);
            CreateTable(ObjDocument, "tabla", tabla.Rows.Count + 1, tabla);
            ColocarTablaTotales(ObjDocument, "totales", tabla);
            ColocarCliente(ObjDocument, "cliente");
            objWord.Selection.Collapse();
            objWord.Visible = true;
        }

        private void ColocarCliente(Word.Document doc, String bookmarkName)
        {
            if (doc.Bookmarks.Exists(bookmarkName))
            {
                Object name = bookmarkName;
                Word.Range range = doc.Bookmarks.get_Item(ref name).Range;
                if (CE.txtCliente.Text != "") {
                    range.Font.Size = 8;
                    Cliente.CCliente CC = new Cliente.CCliente();
                    DataTable tabla = CC.obtenerCliente(CE.ID_cliente);
                    if(tabla.Rows.Count > 0)
                    {
                        range.Text = tabla.Rows[0]["Nombre"].ToString();
                    }
                }
                object newRange = range;
                doc.Bookmarks.Add(bookmarkName, ref newRange);
            }
        }

        private void ColocarTituloTabla(Word.Document doc)
        {
            String[] titulos = new string[9] { "CODIGO", "DESCRIPCION", "T.E.", "PRECIO X KILO DLS", "PRECIO CORTE DLS", "PZAS", "MEDIDA DE PIEZA", "IMPORTE DLS", "TOTAL KGS" };
            Word.Table tabla = doc.Tables[1];
            for(int i = 1; i <= 9; i++)
            {
                tabla.Cell(1, i).Range.Font.Size = 8;
                tabla.Cell(1, i).Range.Text = titulos[i - 1];
            }
        }

        private void CreateTable(Word.Document doc, string bookmarkName, int rows, DataTable tabla)
        {
            if (doc.Bookmarks.Exists(bookmarkName))
            {
                Object name = bookmarkName;
                Microsoft.Office.Interop.Word.Range range = doc.Bookmarks.get_Item(ref name).Range;
                doc.Tables.Add(range, rows, 9);
                doc.Tables[1].Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                doc.Tables[1].Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                object newRange = range;
                doc.Bookmarks.Add(bookmarkName, ref newRange);
                ColocarTituloTabla(doc);
                ColocarDatosTabla(doc, tabla);
            }
        }

        private void ColocarDatosTabla(Word.Document doc, DataTable tablaCot)
        {
            Word.Table docTabla = doc.Tables[1];
            for (int i = 0; i < tablaCot.Rows.Count; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    docTabla.Cell(i + 2, j).Range.Font.Size = 8;
                    docTabla.Cell(i + 2, j).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                }
                String codigo = tablaCot.Rows[i]["Codigo"].ToString();
                docTabla.Cell(i + 2, 1).Range.Text = codigo;
                docTabla.Cell(i + 2, 2).Range.Text = CS.obtenerDescripcion(codigo);
                docTabla.Cell(i + 2, 3).Range.Text = ColocarTiempoEnvio();
                if (CS.obtenerGrupoPrecio(tablaCot.Rows[i]["Criterio"].ToString()) != 3)
                    docTabla.Cell(i + 2, 4).Range.Text = "$ " + CS.obtenerPrecio(codigo, CS.obtenerGrupoPrecio(tablaCot.Rows[i]["Criterio"].ToString())).ToString();
                else
                    docTabla.Cell(i + 2, 4).Range.Text = "$ " + (float.Parse(tablaCot.Rows[i]["Precio Cotizacion"].ToString()) / float.Parse(tablaCot.Rows[i]["Kilogramos Cotizacion"].ToString())).ToString("0.00");
                docTabla.Cell(i + 2, 5).Range.Text = "$ " + tablaCot.Rows[i]["Precio Total Corte"].ToString();
                docTabla.Cell(i + 2, 6).Range.Text = tablaCot.Rows[i]["Piezas"].ToString();
                if (tablaCot.Rows[i]["Piezas"].ToString() == "1")
                {
                    if (tablaCot.Rows[i].IsNull("Metros Cotizacion"))
                        docTabla.Cell(i + 2, 7).Range.Text = float.Parse(tablaCot.Rows[i]["Kilogramos Cotizacion"].ToString()).ToString("0.00") + " KG";
                    else
                        docTabla.Cell(i + 2, 7).Range.Text = float.Parse(tablaCot.Rows[i]["Metros Cotizacion"].ToString()).ToString("0.00") + " M";
                }
                else
                    docTabla.Cell(i + 2, 7).Range.Text = float.Parse(tablaCot.Rows[i]["Medida Pieza"].ToString()).ToString() + ' ' + tablaCot.Rows[i]["Unidad Pieza"].ToString();
                docTabla.Cell(i + 2, 8).Range.Text = "$ " + float.Parse(tablaCot.Rows[i]["Precio Cotizacion"].ToString()).ToString("0.00");
                docTabla.Cell(i + 2, 9).Range.Text = float.Parse(tablaCot.Rows[i]["Kilogramos Cotizacion"].ToString()).ToString("0.00");

                /*String forma = tablaCot.Rows[i]["Tipo"].ToString() + ' ' + tablaCot.Rows[i]["Forma"].ToString();
                docTabla.Cell(i + 2, 3).Range.Text = forma;
                String medida = tablaCot.Rows[i]["Medida"].ToString() + ' ' + tablaCot.Rows[i]["Unidad"].ToString() + " x " + tablaCot.Rows[i]["Comercial"].ToString() + ' ' + tablaCot.Rows[i]["Unidad comercial"].ToString();
                docTabla.Cell(i + 2, 4).Range.Text = medida;
                float kgsPza = CS.obtenerKilogramosPieza(tablaCot.Rows[i]["Codigo"].ToString());
                docTabla.Cell(i + 2, 6).Range.Text = kgsPza.ToString("0.00");
                int grupoPrecio = CS.obtenerGrupoPrecio(tablaCot.Rows[i]["Criterio"].ToString());
                docTabla.Cell(i + 2, 9).Range.Text = CS.obtenerPrecio(tablaCot.Rows[i]["Codigo"].ToString(), grupoPrecio).ToString("0.00");*/
            }
            docTabla.AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitContent);
        }

        private void ReplaceBookmarkText(Word.Document doc, string bookmarkName, string text)
        {
            if (doc.Bookmarks.Exists(bookmarkName))
            {
                Object name = bookmarkName;
                Microsoft.Office.Interop.Word.Range range = doc.Bookmarks.get_Item(ref name).Range;
                range.Text = text;
                range.Select();
                range.Font.Size = 10;
                object newRange = range;
                doc.Bookmarks.Add(bookmarkName, ref newRange);
            }
        }

        private String FechaLetras()
        {
            DateTime dateTime = new DateTime();
            dateTime = DateTime.Now;
            return dateTime.ToString("D", CultureInfo.CreateSpecificCulture("es-ES"));
        }

        private string ColocarTiempoEnvio()
        {
            if (CE.chkEnvio.Checked)
                return CE.txtTiempo.Text + " HRS";
            return "-";
        }

        private void ColocarTablaTotales(Word.Document doc, string bookmarkName, DataTable tablaCot)
        {
            if (doc.Bookmarks.Exists(bookmarkName))
            {
                Object name = bookmarkName;
                Microsoft.Office.Interop.Word.Range range = doc.Bookmarks.get_Item(ref name).Range;
                doc.Tables.Add(range, 5, 3);
                Word.Table docTabla = doc.Tables[2];
                String[] titulos = new String[5] { "SUB", "IVA", "ENVIO", "OTRO", "TOTAL" };
                for(int i = 1; i <= 5; i++)
                {
                    docTabla.Cell(i, 1).Range.Text = titulos[i - 1];
                    for(int j = 1; j <= 3; j++)
                        docTabla.Cell(i, j).Range.Font.Size = 8;
                    docTabla.Cell(i, 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    if (i == 5)
                        docTabla.Cell(i, 1).Range.Borders[Word.WdBorderType.wdBorderTop].LineStyle = Word.WdLineStyle.wdLineStyleDouble;
                    else
                    {
                        docTabla.Cell(i, 2).Range.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleDashSmallGap;
                    }
                    docTabla.Cell(i, 2).Shading.BackgroundPatternColor = Word.WdColor.wdColorGray10;
                    if(i == 1)
                        docTabla.Cell(i, 3).Shading.BackgroundPatternColor = Word.WdColor.wdColorGray10;
                }
                ColocarDatosTotales(docTabla, tablaCot);
                ColocarTamañoTotales(doc.Tables[1], doc.Tables[2]);
                object newRange = range;
                doc.Bookmarks.Add(bookmarkName, ref newRange);
            }
        }

        private void ColocarDatosTotales(Word.Table docTabla, DataTable tablaCot)
        {
            double sub = 0;
            for (int i = 0; i < tablaCot.Rows.Count; i++)
                sub += float.Parse(tablaCot.Rows[i]["Precio Cotizacion"].ToString());
            docTabla.Cell(1, 2).Range.Text = "$ " + sub.ToString("0.00");
            docTabla.Cell(2, 2).Range.Text = "$ " + (sub * 0.16).ToString("0.00");
            sub += sub * 0.16;
            if (CE.chkEnvio.Checked)
            {
                docTabla.Cell(3, 2).Range.Text = "$ " + CE.txtCostoEnvio.Text;
                sub += float.Parse(CE.txtCostoEnvio.Text);
            }
            else
                docTabla.Cell(3, 2).Range.Text = "-";
            if (CE.chkOtro.Checked)
            {
                docTabla.Cell(4, 2).Range.Text = "$ " + CE.txtCosto.Text;
                sub += float.Parse(CE.txtCosto.Text);
            }
            else
                docTabla.Cell(4, 2).Range.Text = "-";
            docTabla.Cell(5, 2).Range.Text = "$ " + sub.ToString("0.00");
            sub = 0;
            for (int i = 0; i < tablaCot.Rows.Count; i++)
                sub += float.Parse(tablaCot.Rows[i]["Kilogramos Cotizacion"].ToString());
            docTabla.Cell(1, 3).Range.Text = sub.ToString("0.00");
        }

        private void ColocarTamañoTotales(Word.Table docTabla, Word.Table docTablaTotales)
        {
            for (int i = 1; i <= 5; i++)
            {
                docTablaTotales.Cell(i, 3).Width = docTabla.Cell(1, 9).Width;
                docTablaTotales.Cell(i, 2).Width = docTabla.Cell(1, 8).Width;
                docTablaTotales.Cell(i, 1).Width = docTabla.Cell(1, 7).Width;
            }
            docTablaTotales.Rows.Alignment = Word.WdRowAlignment.wdAlignRowRight;
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
                mylogs.WriteLine(CE.txtNoCompra.Text);
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
