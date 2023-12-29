using AcademiaFS.Proyecto.Inventario._Features.Productos.Dtos;
using Farsiman.Application.Core.Standard.DTOs;

namespace AcademiaFS.Proyecto.Inventario._Features.Productos
{
    public interface IProductoService
    {
        Respuesta<List<ProductoDto>> ListarProductos();
        Respuesta<ProductoDto> InsertarProductos(ProductoDto productoDto);
        Respuesta<ProductoDto> EditarProductos(ProductoDto productoDto);
        Respuesta<string> EliminarProductos(int id);
    }
}
