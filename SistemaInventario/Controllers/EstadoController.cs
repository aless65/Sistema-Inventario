using AcademiaFS.Proyecto.Inventario._Features.Estados;
using AcademiaFS.Proyecto.Inventario._Features.Estados.Dtos;
using AcademiaFS.Proyecto.Inventario._Features.Lotes.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaFS.Proyecto.Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private readonly EstadoService _estadoService;

        public EstadoController(EstadoService estadoService)
        {
            _estadoService = estadoService;
        }

        [HttpGet("Listar")]
        public IActionResult Index()
        {
            var respuesta = _estadoService.ListarEstados();

            return Ok(respuesta);
        }

        [HttpPost("Insertar")]
        public IActionResult Create(EstadoDto estado)
        {
            var respuesta = _estadoService.InsertarEstados(estado);

            return Ok(respuesta);
        }

        [HttpPut("Editar")]
        public IActionResult Edit(EstadoDto estado)
        {
            var respuesta = _estadoService.EditarEstados(estado);

            return Ok(respuesta);
        }

        [HttpPut("Eliminar/{id}")]
        public IActionResult Delete(int id)
        {
            var respuesta = _estadoService.EliminarEstados(id);

            return Ok(respuesta);
        }
    }
}
