namespace DescargarArchivo.Models
{
    /// <summary>
    /// Crear Documento Adjunto
    /// </summary>
    /// <param name="ruta">Ruta</param>
    /// <param name="nombre">Nombre incluido la extensión Ejemplo Contrato.pdf</param>
    public class EDocumentoAdjunto
    {
        public string Ruta { get; set; }
        /// <summary>
        /// Nombre del documento
        /// </summary>
        public string Nombre { get; set; }
        public EDocumentoAdjunto(string ruta, string nombre)
        {
            Ruta = ruta;
            Nombre = nombre;
        }
    }
}
