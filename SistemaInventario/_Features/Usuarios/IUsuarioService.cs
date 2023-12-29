using AcademiaFS.Proyecto.Inventario._Features.Usuarios.Dtos;
using Farsiman.Application.Core.Standard.DTOs;

namespace AcademiaFS.Proyecto.Inventario._Features.Usuarios
{
    public interface IUsuarioService
    {
        Respuesta<List<UsuarioListarDto>> ListarUsuarios();
        Respuesta<UsuarioDto> InsertarUsuarios(UsuarioDto usuarioDto);
        Respuesta<string> DesactivarUsuario(int id);
        Respuesta<string> ActivarUsuario(int id);
    }
}
