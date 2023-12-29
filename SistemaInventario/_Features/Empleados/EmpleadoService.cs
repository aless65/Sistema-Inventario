using AcademiaFS.Proyecto.Inventario._Features.Empleados;
using AcademiaFS.Proyecto.Inventario._Features.Empleados.Dtos;
using AcademiaFS.Proyecto.Inventario._Features.Sucursales.Dtos;
using AcademiaFS.Proyecto.Inventario.Infrastructure.Inventario_AJM.Entities;
using AcademiaFS.Proyecto.Inventario.Utility;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using SistemaInventario._Common;

namespace SistemaInventario._Features.Empleados
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly CommonService _commonService;

        public EmpleadoService(UnitOfWorkBuilder unitOfWork, IMapper mapper, CommonService commonService)
        {
            _unitOfWork = unitOfWork.BuilderInventarioAjm();
            _mapper = mapper;
            _commonService = commonService;
        }

        public Respuesta<List<EmpleadoDto>> ListarEmpleados()
        {
            try
            {
                var listado = (from empl in _unitOfWork.Repository<Empleado>().AsQueryable()
                               where empl.Activo == true
                               select new EmpleadoDto
                               {
                                   IdEmpleado = empl.IdEmpleado,
                                   Nombres = empl.Nombres,
                                   Apellidos = empl.Apellidos,
                                   Identidad = empl.Identidad,
                                   Direccion = empl.Direccion,
                                   Telefono = empl.Telefono
                               }).ToList();

                return Respuesta.Success(listado, Codigos.Success, Mensajes.PROCESO_EXITOSO);
            }
            catch
            {
                return Respuesta.Fault<List<EmpleadoDto>>(Codigos.Error, Mensajes.PROCESO_FALLIDO);
            }
        }

        public Respuesta<EmpleadoDto> InsertarEmpleados(EmpleadoDto empleadoDto)
        {
            try
            {
                var empleado = _mapper.Map<Empleado>(empleadoDto);

                EmpleadoValidator validator = new EmpleadoValidator();
                ValidationResult validationResult = validator.Validate(empleado);

                if (!validationResult.IsValid)
                {
                    IEnumerable<string> errores = validationResult.Errors.Select(s => s.ErrorMessage);
                    string menssageValidation = string.Join(Environment.NewLine, errores);
                    return Respuesta.Fault<EmpleadoDto>(menssageValidation, Codigos.BadRequest);
                }

                empleado.FechaCreacion = DateTime.Now;
                empleado.IdUsuarioCreacion = 1;

                _unitOfWork.Repository<Empleado>().Add(empleado);
                _unitOfWork.SaveChanges();

                return Respuesta.Success(_mapper.Map<EmpleadoDto>(empleado), Codigos.Success, Mensajes.OPERACION_EXITOSA("insertado"));
            }
            catch (DbUpdateException ex)
            {
                return _commonService.RespuestasCatch<EmpleadoDto>(ex, "empleado");
            }
        }

        public Respuesta<EmpleadoDto> EditarEmpleados(EmpleadoDto empleadoDto)
        {
            try
            {
                var empleado = _unitOfWork.Repository<Empleado>().Where(x => x.IdEmpleado == empleadoDto.IdEmpleado).FirstOrDefault();

                if (empleado != null)
                {
                    EmpleadoValidator validator = new EmpleadoValidator();
                    ValidationResult validationResult = validator.Validate(empleado);

                    if (!validationResult.IsValid)
                    {
                        IEnumerable<string> errores = validationResult.Errors.Select(s => s.ErrorMessage);
                        string menssageValidation = string.Join(Environment.NewLine, errores);
                        return Respuesta.Fault<EmpleadoDto>(menssageValidation, Codigos.BadRequest);
                    }

                    empleado.Nombres = empleadoDto.Nombres;
                    empleado.Apellidos = empleadoDto.Apellidos;
                    empleado.Identidad = empleadoDto.Identidad;
                    empleado.Direccion = empleadoDto.Direccion;
                    empleado.FechaModificacion = DateTime.Now;
                    empleado.IdUsuarioModificacion = 1;

                    _unitOfWork.SaveChanges();
                }

                return Respuesta.Success(_mapper.Map<EmpleadoDto>(empleado), Codigos.Success, Mensajes.OPERACION_EXITOSA("editado"));
            }
            catch (DbUpdateException ex)
            {

                return _commonService.RespuestasCatch<EmpleadoDto>(ex, "empleado");
            }
        }

        public Respuesta<string> EliminarEmpleados(int id)
        {
            try
            {
                var sucursal = _unitOfWork.Repository<Empleado>().Where(x => x.IdEmpleado == id).FirstOrDefault();

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
