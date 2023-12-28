using AcademiaFS.Proyecto.Inventario._Features.Usuarios.Dtos;
using Farsiman.Application.Core.Standard.DTOs;

namespace AcademiaFS.Proyecto.Inventario._Features.Auth
{
    public interface IAuthService<T>
    {
        Respuesta<T> Login(string nombre, string contrasena);
    }
}
