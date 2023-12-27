using AcademiaFS.Proyecto.Inventario._Features.Empleados.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaInventario._Features.Empleados;

namespace AcademiaFS.Proyecto.Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly EmpleadoService _empleadoService;

        public EmpleadoController(EmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        [HttpGet("Listar")]
        public IActionResult Index()
        {
            var respuesta = _empleadoService.ListarEmpleados();

            return Ok(respuesta);
        }

        [HttpPost("Insertar")]
        public IActionResult Create(EmpleadoDto empleadoDto)
        {
            var respuesta = _empleadoService.InsertarEmpleados(empleadoDto);

            return Ok(respuesta);
        }

    }
}
