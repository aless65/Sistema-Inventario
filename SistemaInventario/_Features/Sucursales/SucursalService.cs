using AcademiaFS.Proyecto.Inventario._Features.Sucursales.Dtos;
using AcademiaFS.Proyecto.Inventario.Infrastructure.Inventario_AJM.Entities;
using AcademiaFS.Proyecto.Inventario.Utility;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;
using SistemaInventario._Common;

namespace SistemaInventario._Features.Lotes
{
    public class SucursalService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SucursalService(UnitOfWorkBuilder unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork.BuilderInventarioAjm();
            _mapper = mapper;
        }

        public Respuesta<List<SucursalDto>> ListarSucursales()
        {
            try
            {
                var listado = (from sucu in _unitOfWork.Repository<Sucursal>().AsQueryable()
                               where sucu.Activo == true
                               select new SucursalDto
                               {
                                   IdSucursal = sucu.IdSucursal,
                                   Nombre = sucu.Nombre
                               }).ToList();

                return Respuesta.Success(listado, Codigos.Success, Mensajes.PROCESO_EXITOSO);
            } catch 
            {
                return Respuesta.Fault<List<SucursalDto>>(Codigos.Error, Mensajes.PROCESO_FALLIDO);
            }
        }

        public Respuesta<SucursalDto> InsertarSucursales(SucursalDto sucursalDto)
        {
            try
            {
                var sucursal = _mapper.Map<Sucursal>(sucursalDto);

                sucursal.FechaCreacion = DateTime.Now;
                sucursal.IdUsuarioCreacion = 1;

                _unitOfWork.Repository<Sucursal>().Add(sucursal);
                _unitOfWork.SaveChanges();

                return Respuesta.Success(_mapper.Map<SucursalDto>(sucursal), Codigos.Success, Mensajes.OPERACION_EXITOSA("insertado"));
            }
            catch
            {
                return Respuesta.Fault<SucursalDto>(Codigos.Error, Mensajes.PROCESO_FALLIDO);
            }
        }

        public Respuesta<SucursalDto> EditarSucursales(SucursalDto sucursalDto)
        {
            try
            {
                var sucursal = _unitOfWork.Repository<Sucursal>().Where(x => x.IdSucursal == sucursalDto.IdSucursal).FirstOrDefault();

                if(sucursal != null)
                {
                    sucursal.Nombre = sucursalDto.Nombre;
                    sucursal.FechaModificacion = DateTime.Now;
                    sucursal.IdUsuarioModificacion = 1;

                    _unitOfWork.SaveChanges();
                }

                return Respuesta.Success(_mapper.Map<SucursalDto>(sucursal), Codigos.Success, Mensajes.OPERACION_EXITOSA("editado"));
            }
            catch
            {
                return Respuesta.Fault<SucursalDto>(Codigos.Error, Mensajes.PROCESO_FALLIDO);
            }
        }

        public Respuesta<string> EliminarSucursales(int id)
        {
            try
            {
                var sucursal = _unitOfWork.Repository<Sucursal>().Where(x => x.IdSucursal == id).FirstOrDefault();

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
