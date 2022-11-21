using DescargaArchivo.Interface;
using PdfSharp.Pdf;
using PdfSharp;
using DescargarArchivo.Models;

namespace DescargaArchivo.Clase
{
    public class GenerarArchivo : IGenerarArchivo
    {


        public EDocumentoAdjunto CrearPdfDesdeHtml(string html)
        {
            var arregloDatos = GenerarArchivoEnArregloBytes(html);
            var archivo = GuardarArchivoLocal(arregloDatos, $"Contrato{DateTime.Now.Millisecond}.pdf");
            return archivo;
        }

        byte[] GenerarArchivoEnArregloBytes(string html)
        {
            byte[] pdfBinario = Array.Empty<byte>();
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerateConfig pdfGenerateConfig = new TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerateConfig
            {
                PageOrientation = PageOrientation.Portrait,
                PageSize = PageSize.A4
            };

			PdfDocument pdfDocument = TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf(html, pdfGenerateConfig);

            var pagina = 0;

            foreach (PdfPage page in pdfDocument.Pages)
            {
                PdfSharp.Drawing.XFont xFont = new PdfSharp.Drawing.XFont("Verdana", 8);
                PdfSharp.Drawing.XSolidBrush xSolidBrush = PdfSharp.Drawing.XBrushes.Black;
                PdfSharp.Drawing.XStringFormat xStringFormat = new PdfSharp.Drawing.XStringFormat
                {
                    Alignment = PdfSharp.Drawing.XStringAlignment.Far
                };

                PdfSharp.Drawing.XRect layoutRectangle = new PdfSharp.Drawing.XRect(-15, page.Height - xFont.Height - 10, page.Width, xFont.Height);

                pagina++;
                using (var xGraphics = PdfSharp.Drawing.XGraphics.FromPdfPage(page))
                {
                    xGraphics.DrawString("Página " + pagina + " de " + pdfDocument.Pages.Count, xFont, xSolidBrush, layoutRectangle, xStringFormat);
                }

            }

            using (var memoryStream = new MemoryStream())
            {
                pdfDocument.Save(memoryStream, false);
                pdfBinario = memoryStream.GetBuffer();
            }
            return pdfBinario;
        }

        EDocumentoAdjunto GuardarArchivoLocal(byte[] archivo, string nombre)
        {
            string rutaCarpeta = @"C:\Users\esanchez\source\repos\DescargarArchivo\DescargarArchivo\Template\";

            string rutaArchivo = Path.Combine(rutaCarpeta, nombre);
            File.WriteAllBytes(rutaArchivo, archivo);

            return new EDocumentoAdjunto(rutaArchivo, nombre);
        }
    }

   
}

