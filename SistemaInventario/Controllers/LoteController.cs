using AcademiaFS.Proyecto.Inventario._Features.Lotes.Dtos;
using AcademiaFS.Proyecto.Inventario._Features.Sucursales.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaInventario._Features.Lotes;

namespace AcademiaFS.Proyecto.Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoteController : ControllerBase
    {
        private readonly LoteService _loteService;

        public LoteController(LoteService loteService)
        {
            _loteService = loteService;
        }

        [HttpGet("Listar")]
        public IActionResult Index()
        {
            var respuesta = _loteService.ListarLotes();

            return Ok(respuesta);
        }

        [HttpPost("Insertar")]
        public IActionResult Create(LoteDto lote)
        {
            var respuesta = _loteService.InsertarLotes(lote);

            return Ok(respuesta);
        }

        [HttpPut("Editar")]
        public IActionResult Edit(LoteDto lote)
        {
            var respuesta = _loteService.EditarLotes(lote);

            return Ok(respuesta);
        }

        [HttpPut("Eliminar/{id}")]
        public IActionResult Delete(int id)
        {
            var respuesta = _loteService.EliminarLotes(id);

            return Ok(respuesta);
        }
    }
}
