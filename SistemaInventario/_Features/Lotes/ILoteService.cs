using AcademiaFS.Proyecto.Inventario._Features.Lotes.Dtos;
using Farsiman.Application.Core.Standard.DTOs;

namespace AcademiaFS.Proyecto.Inventario._Features.Lotes
{
    public interface ILoteService<T, U>
    {
        Respuesta<List<U>> ListarLotes();
        Respuesta<T> InsertarLotes(T loteDto);
        Respuesta<T> EditarLotes(T loteDto);
        Respuesta<string> EliminarLotes(int id);
    }
}
