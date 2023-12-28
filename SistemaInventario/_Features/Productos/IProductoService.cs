using AcademiaFS.Proyecto.Inventario._Features.Productos.Dtos;
using Farsiman.Application.Core.Standard.DTOs;

namespace AcademiaFS.Proyecto.Inventario._Features.Productos
{
    public interface IProductoService<T>
    {
        Respuesta<List<T>> ListarProductos();
        Respuesta<T> InsertarProductos(T productoDto);
        Respuesta<T> EditarProductos(T productoDto);
        Respuesta<string> EliminarProductos(int id);
    }
}
