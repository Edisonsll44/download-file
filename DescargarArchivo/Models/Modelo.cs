using System.Text.Json.Serialization;

namespace DescargarArchivo.Models
{
	public class Modelo
	{
		[JsonPropertyName("header") ]
		public Header Header { get; set; }

		[JsonPropertyName("data")]
		public IEnumerable<Data> Data { get; set; }
	}
}
