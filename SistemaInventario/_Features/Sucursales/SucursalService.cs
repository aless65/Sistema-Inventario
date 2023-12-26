using AcademiaFS.Proyecto.Inventario._Features.Sucursales.Dtos;
using AcademiaFS.Proyecto.Inventario.Infrastructure.Inventario_AJM.Entities;
using AcademiaFS.Proyecto.Inventario.Utility;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;

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
                               select new SucursalDto
                               {
                                   IdSucursal = sucu.IdSucursal,
                                   Nombre = sucu.Nombre
                               }).ToList();

                return Respuesta.Success(listado);
            } catch 
            {
                return Respuesta.Fault<List<SucursalDto>>("", "");
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

                return Respuesta.Success(_mapper.Map<SucursalDto>(sucursal));
            }
            catch
            {
                return Respuesta.Fault<SucursalDto>("", "");
            }
        }
    }
}
