using AcademiaFS.Proyecto.Inventario._Features.SalidasInventarios;
using AcademiaFS.Proyecto.Inventario._Features.SalidasInventarios.Dtos;
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
    public class SalidasInventarioService : ISalidasInventarioService<SalidasInventarioDto, SalidasInventarioListarDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly CommonService _commonService;

        public SalidasInventarioService(UnitOfWorkBuilder unitOfWork, IMapper mapper, CommonService commonService)
        {
            _unitOfWork = unitOfWork.BuilderInventarioAjm();
            _mapper = mapper;
            _commonService = commonService;
        }

        public Respuesta<List<SalidasInventarioListarDto>> ListarSalidas()
        {
            try
            {
                var listado = (from sali in _unitOfWork.Repository<SalidasInventario>().AsQueryable()
                               join sucu in _unitOfWork.Repository<Sucursal>().AsQueryable()
                               on sali.IdSucursal equals sucu.IdSucursal
                               where sali.Activo == true
                               select new SalidasInventarioListarDto
                               {
                                   IdSalidaInventario = sali.IdSalidaInventario,
                                   IdSucursal = sucu.IdSucursal,
                                   NombreSucursal = sucu.Nombre,
                                   Fecha = sali.Fecha,
                                   IdUsuario = sali.IdUsuario,
                                   FechaRecibido = sali.FechaRecibido,
                                   IdUsuarioRecibe = sali.IdUsuarioRecibe,
                                   SalidasInventarioDetalles = (ICollection<SalidasInventarioDetalleDto>)sali.SalidasInventarioDetalles
                               }).ToList();

                return Respuesta.Success(listado, Codigos.Success, Mensajes.PROCESO_EXITOSO);

            }               
            catch
            {
                return Respuesta.Fault<List<SalidasInventarioListarDto>>(Codigos.Error, Mensajes.PROCESO_FALLIDO);
            }
        }

        public Respuesta<SalidasInventarioDto> InsertarSalidas(SalidasInventarioDto salidasInventarioDto)
        {
            try
            {

            }
            catch (DbUpdateException ex)
            {
                return _commonService.RespuestasCatch<SalidasInventarioDto>(ex, "salida");
            }
            //throw new NotImplementedException();
        }
    }
}
