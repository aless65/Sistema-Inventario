using AcademiaFS.Proyecto.Inventario._Features.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaFS.Proyecto.Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _loginService;

        public AuthController(AuthService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet("Login/{username}/{password}")]
        public IActionResult Login(string username, string password)
        {
            var respuesta = _loginService.Login(username, password);

            return Ok(respuesta);
        }
    }
}
