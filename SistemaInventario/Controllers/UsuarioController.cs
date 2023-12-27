using AcademiaFS.Proyecto.Inventario._Features.Usuarios.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaInventario._Features.Lotes;

namespace AcademiaFS.Proyecto.Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
    }
}
