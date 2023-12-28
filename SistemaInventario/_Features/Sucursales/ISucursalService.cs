using AcademiaFS.Proyecto.Inventario._Features.Sucursales.Dtos;
using Farsiman.Application.Core.Standard.DTOs;

namespace AcademiaFS.Proyecto.Inventario._Features.Sucursales
{
    public interface ISucursalService<T>
    {
        Respuesta<List<T>> ListarSucursales();
        Respuesta<T> InsertarSucursales(T sucursalDto);
        Respuesta<T> EditarSucursales(T sucursalDto);
        Respuesta<string> EliminarSucursales(int id);
    }
}
