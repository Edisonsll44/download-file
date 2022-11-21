using DescargaArchivo.Interface;
using DescargarArchivo.Logica.Util;
using DescargarArchivo.Models;
using Microsoft.AspNetCore.Mvc;

namespace DescargarArchivo.Controllers
{
	[Route("v1/[controller]")]
	[ApiController]
	public class DownloadController : ControllerBase
	{
		private IWebHostEnvironment _hostingEnvironment;
		private IGenerarArchivo _generarArchivo;
		public DownloadController(IWebHostEnvironment environment, IGenerarArchivo generarArchivo)
		{
			_hostingEnvironment = environment;
			_generarArchivo = generarArchivo;
		}

		[HttpPost("DownloadFile")]
		public async Task<IActionResult> DownloadFileAsync([FromBody] Modelo modelo)
		{
			string html = await ViewToStringRenderer.RenderViewToStringAsync(HttpContext.RequestServices, $"~/Template/TemplateR.cshtml", modelo);
			var respuesta = _generarArchivo.CrearPdfDesdeHtml(html);
			var fs = new FileStream(respuesta.Ruta, FileMode.Open);
			return File(fs, "application/pdf", respuesta.Nombre);
		}
	}
}


