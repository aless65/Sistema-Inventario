using Farsiman.Application.Core.Standard.DTOs;

namespace AcademiaFS.Proyecto.Inventario._Features.SalidasInventarios
{
    public interface ISalidasInventarioService<T, U>
    {
        Respuesta<List<U>> ListarSalidas();
        Respuesta<T> InsertarSalidas(T salidasInventarioDto);
    }
}
