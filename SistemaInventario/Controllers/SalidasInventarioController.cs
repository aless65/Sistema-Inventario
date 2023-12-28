using AcademiaFS.Proyecto.Inventario._Features.Empleados;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaInventario._Features.Empleados;
using SistemaInventario._Features.Lotes;

namespace AcademiaFS.Proyecto.Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalidasInventarioController : ControllerBase
    {
        private readonly SalidasInventarioService _salidasInventarioService;

        public SalidasInventarioController(SalidasInventarioService salidasInventarioService)
        {
            _salidasInventarioService = salidasInventarioService;
        }

        [HttpGet("Listar")]
        public IActionResult Index()
        {
            var respuesta = _salidasInventarioService.ListarSalidas();

            return Ok(respuesta);
        }
    }
}
