using AcademiaFS.Proyecto.Inventario._Features.SalidasInventarios.Dtos;
using Farsiman.Application.Core.Standard.DTOs;

namespace AcademiaFS.Proyecto.Inventario._Features.SalidasInventarios
{
    public interface ISalidasInventarioService
    {
        Respuesta<List<SalidasInventarioListarDto>> ListarSalidas();
        Respuesta<SalidasInventarioListarDto> InsertarSalidas(SalidasInventarioInsertarDto salidasInventarioInsertarDto );
        Respuesta<List<SalidasInventarioFiltradasDto>> ListarSalidasFiltro(DateTime fechaInicio, DateTime fechaFin, int IdSucursal);
        Respuesta<SalidasInventarioListarDto> RecibirSalida(SalidasInventariosRecibirDto salidasInventariosRecibirDto);
    }
}
