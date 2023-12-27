using AcademiaFS.Proyecto.Inventario._Features.Productos.Dtos;
using AcademiaFS.Proyecto.Inventario._Features.Sucursales.Dtos;
using AcademiaFS.Proyecto.Inventario.Infrastructure.Inventario_AJM.Entities;
using AcademiaFS.Proyecto.Inventario.Utility;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;
using Microsoft.EntityFrameworkCore;
using SistemaInventario._Common;

namespace SistemaInventario._Features.Lotes
{
    public class ProductoService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly CommonService _commonService;

        public ProductoService(UnitOfWorkBuilder unitOfWork, IMapper mapper, CommonService commonService)
        {
            _unitOfWork = unitOfWork.BuilderInventarioAjm();
            _mapper = mapper;
            _commonService = commonService;
        }

        public Respuesta<List<ProductoDto>> ListarProductos()
        {
            try
            {
                var listado = (from prod in _unitOfWork.Repository<Producto>().AsQueryable()
                               where prod.Activo == true
                               select new ProductoDto
                               {
                                   IdProducto = prod.IdProducto,
                                   Nombre = prod.Nombre
                               }).ToList();

                return Respuesta.Success(listado, Codigos.Success, Mensajes.PROCESO_EXITOSO);
            }
            catch
            {
                return Respuesta.Fault<List<ProductoDto>>(Codigos.Error, Mensajes.PROCESO_FALLIDO);
            }
        }

        public Respuesta<ProductoDto> InsertarProductos(ProductoDto productoDto)
        {
            try
            {
                var producto = _mapper.Map<Producto>(productoDto);

                producto.FechaCreacion = DateTime.Now;
                producto.IdUsuarioCreacion = 1;

                _unitOfWork.Repository<Producto>().Add(producto);
                _unitOfWork.SaveChanges();

                return Respuesta.Success(_mapper.Map<ProductoDto>(producto), Codigos.Success, Mensajes.OPERACION_EXITOSA("insertado"));
            }
            catch (DbUpdateException ex)
            {
                return _commonService.RespuestasCatch<ProductoDto>(ex, "producto");

            }
        }

        public Respuesta<ProductoDto> EditarProductos(ProductoDto productoDto)
        {
            try
            {
                var producto = _unitOfWork.Repository<Producto>().Where(x => x.IdProducto == productoDto.IdProducto).FirstOrDefault();

                if (producto != null)
                {
                    producto.Nombre = productoDto.Nombre;
                    producto.FechaModificacion = DateTime.Now;
                    producto.IdUsuarioModificacion = 1;

                    _unitOfWork.SaveChanges();
                }

                return Respuesta.Success(_mapper.Map<ProductoDto>(producto), Codigos.Success, Mensajes.OPERACION_EXITOSA("editado"));
            }
            catch (DbUpdateException ex)
            {

                return _commonService.RespuestasCatch<ProductoDto>(ex, "producto");
            }
        }

        public Respuesta<string> EliminarProductos(int id)
        {
            try
            {
                var sucursal = _unitOfWork.Repository<Producto>().Where(x => x.IdProducto == id).FirstOrDefault();

                if (sucursal != null)
                {
                    sucursal.Activo = false;

                    _unitOfWork.SaveChanges();
                }

                return Respuesta.Success("", Codigos.Success, Mensajes.OPERACION_EXITOSA("eliminado"));
            }
            catch
            {
                return Respuesta.Fault<string>(Codigos.Error, Mensajes.PROCESO_FALLIDO);
            }
        }
    }
}
