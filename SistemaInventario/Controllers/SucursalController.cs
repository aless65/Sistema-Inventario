using AcademiaFS.Proyecto.Inventario._Features.Sucursales.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaInventario._Features.Lotes;

namespace AcademiaFS.Proyecto.Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalController : ControllerBase
    {
        private readonly SucursalService _sucursalService;

        public SucursalController(SucursalService sucursalService)
        {
            _sucursalService = sucursalService;
        }

        [HttpGet("Listar")]
        public IActionResult Index()
        {
            var respuesta = _sucursalService.ListarSucursales();

            return Ok(respuesta);
        }

        [HttpPost("Insertar")]
        public IActionResult Create(SucursalDto sucursal)
        {
            var respuesta = _sucursalService.InsertarSucursales(sucursal);

            return Ok(respuesta);
        }
    }
}
