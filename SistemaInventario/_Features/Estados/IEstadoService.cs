using Farsiman.Application.Core.Standard.DTOs;

namespace AcademiaFS.Proyecto.Inventario._Features.Estados
{
    public interface IEstadoService<T>
    {
        Respuesta<List<T>> ListarEstados();
        Respuesta<T> InsertarEstados(T empleadoDto);
        Respuesta<T> EditarEstados(T empleadoDto);
        Respuesta<string> EliminarEstados(int id);
    }
}
