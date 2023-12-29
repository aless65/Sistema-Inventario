using AcademiaFS.Proyecto.Inventario._Features.Estados.Dtos;
using Farsiman.Application.Core.Standard.DTOs;

namespace AcademiaFS.Proyecto.Inventario._Features.Estados
{
    public interface IEstadoService
    {
        Respuesta<List<EstadoDto>> ListarEstados();
        Respuesta<EstadoDto> InsertarEstados(EstadoDto empleadoDto);
        Respuesta<EstadoDto> EditarEstados(EstadoDto empleadoDto);
        Respuesta<string> EliminarEstados(int id);
    }
}
