using AcademiaFS.Proyecto.Inventario._Features.Lotes.Dtos;
using Farsiman.Application.Core.Standard.DTOs;

namespace AcademiaFS.Proyecto.Inventario._Features.Lotes
{
    public interface ILoteService
    {
        Respuesta<List<LoteListarDto>> ListarLotes();
        Respuesta<LoteDto> InsertarLotes(LoteDto loteDto);
        Respuesta<LoteDto> EditarLotes(LoteDto loteDto);
        Respuesta<string> EliminarLotes(int id);
    }
}
