using AcademiaFS.Proyecto.Inventario._Features.Estados.Dtos;
using AcademiaFS.Proyecto.Inventario._Features.Sucursales.Dtos;
using AcademiaFS.Proyecto.Inventario.Infrastructure.Inventario_AJM.Entities;
using AcademiaFS.Proyecto.Inventario.Utility;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;
using Microsoft.EntityFrameworkCore;
using SistemaInventario._Common;

namespace AcademiaFS.Proyecto.Inventario._Features.Estados
{
    public class EstadoService : IEstadoService<EstadoDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly CommonService _commonService;

        public EstadoService(UnitOfWorkBuilder unitOfWork, IMapper mapper, CommonService commonService)
        {
            _unitOfWork = unitOfWork.BuilderInventarioAjm();
            _mapper = mapper;
            _commonService = commonService;
        }

        public Respuesta<List<EstadoDto>> ListarEstados()
        {
            try
            {
                var listado = (from esta in _unitOfWork.Repository<Estado>().AsQueryable()
                               where esta.Activo == true
                               select new EstadoDto
                               {
                                   IdEstado = esta.IdEstado,
                                   Nombre = esta.Nombre
                               }).ToList();

                return Respuesta.Success(listado, Codigos.Success, Mensajes.PROCESO_EXITOSO);
            }
            catch
            {
                return Respuesta.Fault<List<EstadoDto>>(Codigos.Error, Mensajes.PROCESO_FALLIDO);
            }
        }

        public Respuesta<EstadoDto> InsertarEstados(EstadoDto empleadoDto)
        {
            try
            {
                var empleado = _mapper.Map<Estado>(empleadoDto);

                empleado.FechaCreacion = DateTime.Now;
                empleado.IdUsuarioCreacion = 1;

                _unitOfWork.Repository<Estado>().Add(empleado);
                _unitOfWork.SaveChanges();

                return Respuesta.Success(_mapper.Map<EstadoDto>(empleado), Codigos.Success, Mensajes.OPERACION_EXITOSA("insertado"));
            }
            catch (DbUpdateException ex)
            {
                return _commonService.RespuestasCatch<EstadoDto>(ex, "estado");
            }
        }

        public Respuesta<EstadoDto> EditarEstados(EstadoDto empleadoDto)
        {
            try
            {
                var empleado = _unitOfWork.Repository<Estado>().Where(x => x.IdEstado == empleadoDto.IdEstado).FirstOrDefault();

                if (empleado != null)
                {
                    empleado.Nombre = empleado.Nombre;
                    empleado.FechaModificacion = DateTime.Now;
                    empleado.IdUsuarioModificacion = 1;

                    _unitOfWork.SaveChanges();
                }

                return Respuesta.Success(_mapper.Map<EstadoDto>(empleado), Codigos.Success, Mensajes.OPERACION_EXITOSA("editado"));
            }
            catch (DbUpdateException ex)
            {

                return _commonService.RespuestasCatch<EstadoDto>(ex, "estado");
            }
        }

        public Respuesta<string> EliminarEstados(int id)
        {
            try
            {
                var sucursal = _unitOfWork.Repository<Estado>().Where(x => x.IdEstado == id).FirstOrDefault();

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
