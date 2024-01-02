using AcademiaFS.Proyecto.Inventario._Features.Usuarios.Dtos;
using AcademiaFS.Proyecto.Inventario.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaInventario._Features.Lotes;

namespace AcademiaFS.Proyecto.Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomAuthorization]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("Listar")]
        public IActionResult Index()
        {
            var respuesta = _usuarioService.ListarUsuarios();

            return Ok(respuesta);
        }

        [HttpPost("Insertar")]
        public IActionResult Create(UsuarioDto usuarioDto)
        {
            var respuesta = _usuarioService.InsertarUsuarios(usuarioDto);

            return Ok(respuesta);
        }

        [HttpPut("Desactivar/{id}")]
        public IActionResult Desactivar(int id)
        {
            var respuesta = _usuarioService.DesactivarUsuario(id);

            return Ok(respuesta);
        }

        [HttpPut("Activar/{id}")]
        public IActionResult Activar(int id)
        {
            var respuesta = _usuarioService.ActivarUsuario(id);

            return Ok(respuesta);
        }
    }
}
