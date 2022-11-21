using DescargarArchivo.Models;

namespace DescargaArchivo.Interface
{
    public interface IGenerarArchivo
    {
        EDocumentoAdjunto CrearPdfDesdeHtml(string html);
    }
}
