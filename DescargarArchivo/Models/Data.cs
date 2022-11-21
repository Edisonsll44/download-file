using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DescargarArchivo.Models
{
	public class Data
	{
		[JsonPropertyName("destino")]
		public string Destino { get; set; }

		[JsonPropertyName("fecha")]
		public string Fecha { get; set; }

		[JsonPropertyName("monto")]
		public string Monto { get; set; }

		[JsonPropertyName("acciones")]
		public string? Acciones { get; set; }
	}
}