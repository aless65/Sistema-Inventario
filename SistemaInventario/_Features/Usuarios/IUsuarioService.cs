using AcademiaFS.Proyecto.Inventario._Features.Usuarios.Dtos;
using Farsiman.Application.Core.Standard.DTOs;

namespace AcademiaFS.Proyecto.Inventario._Features.Usuarios
{
    public interface IUsuarioService<T, U>
    {
        Respuesta<List<U>> ListarUsuarios();
        Respuesta<T> InsertarUsuarios(T usuarioDto);
        Respuesta<string> DesactivarUsuario(int id);
        Respuesta<string> ActivarUsuario(int id);
    }
}
