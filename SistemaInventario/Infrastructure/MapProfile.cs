using AcademiaFS.Proyecto.Inventario._Features.Lotes.Dtos;
using AcademiaFS.Proyecto.Inventario._Features.Productos.Dtos;
using AcademiaFS.Proyecto.Inventario._Features.Sucursales.Dtos;
using AcademiaFS.Proyecto.Inventario._Features.Usuarios.Dtos;
using AcademiaFS.Proyecto.Inventario.Infrastructure.Inventario_AJM.Entities;
using AutoMapper;

namespace SistemaInventario.Infrastructure
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Lote, LoteDto>().ReverseMap();
            CreateMap<Lote, LoteListarDto>().ReverseMap();
            CreateMap<Producto, ProductoDto>().ReverseMap();
            CreateMap<Sucursal, SucursalDto>().ReverseMap();
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
            CreateMap<Usuario, UsuarioListarDto>().ReverseMap();
        }
    }
}
