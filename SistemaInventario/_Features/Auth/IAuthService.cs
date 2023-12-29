using AcademiaFS.Proyecto.Inventario._Features.Usuarios.Dtos;
using Farsiman.Application.Core.Standard.DTOs;

namespace AcademiaFS.Proyecto.Inventario._Features.Auth
{
    public interface IAuthService
    {
        Respuesta<UsuarioListarDto> Login(string nombre, string contrasena);
    }
}
