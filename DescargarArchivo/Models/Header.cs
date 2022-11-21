using System.Text.Json.Serialization;

namespace DescargarArchivo.Models
{
	public class Header
	{
		[JsonPropertyName("etiqueta1")]
		public string Etiqueta1 { get; set; }
		
		[JsonPropertyName("etiqueta2")]
		public string Etiqueta2 { get; set; }
		
		[JsonPropertyName("etiqueta3")]
		public string Etiqueta3 { get; set; }
		
		[JsonPropertyName("etiqueta4")]
		public string? Etiqueta4 { get; set; }
		
	}
}