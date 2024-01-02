using AcademiaFS.Proyecto.Inventario._Features.Empleados.Dtos;
using AcademiaFS.Proyecto.Inventario.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaInventario._Features.Empleados;

namespace AcademiaFS.Proyecto.Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomAuthorization]
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

        [HttpPut("Editar")]
        public IActionResult Edit(EmpleadoDto empleadoDto)
        {
            var respuesta = _empleadoService.EditarEmpleados(empleadoDto);

            return Ok(respuesta);
        }

        [HttpPut("Eliminar/{id}")]
        public IActionResult Delete(int id)
        {
            var respuesta = _empleadoService.EliminarEmpleados(id);

            return Ok(respuesta);
        }

    }
}
