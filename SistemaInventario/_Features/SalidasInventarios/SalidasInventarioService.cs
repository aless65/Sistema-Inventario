using AcademiaFS.Proyecto.Inventario._Common;
using AcademiaFS.Proyecto.Inventario._Features.Auth.Dto;
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
    public class SalidasInventarioService : ISalidasInventarioService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly CommonService _commonService;
        private readonly SalidasInventarioDomainService _salidasInventarioDomainService;

        public SalidasInventarioService(UnitOfWorkBuilder unitOfWork, IMapper mapper, CommonService commonService, SalidasInventarioDomainService salidasInventarioDomainService)
        {
            _unitOfWork = unitOfWork.BuilderInventarioAjm();
            _mapper = mapper;
            _commonService = commonService;
            _salidasInventarioDomainService = salidasInventarioDomainService;
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
                                   Total = sali.Total,
                                   IdUsuario = sali.IdUsuario,
                                   FechaRecibido = sali.FechaRecibido,
                                   IdUsuarioRecibe = sali.IdUsuarioRecibe,
                                   SalidasInventarioDetalles = _mapper.Map<List<SalidasInventarioDetalleDto>>(sali.SalidasInventarioDetalles)
                               }).ToList();

                return Respuesta.Success(listado, Codigos.Success, Mensajes.PROCESO_EXITOSO);

            }               
            catch  
            {
                return Respuesta.Fault<List<SalidasInventarioListarDto>>(Mensajes.PROCESO_FALLIDO, Codigos.Error);
            }
        }

        public Respuesta<SalidasInventarioListarDto> InsertarSalidas(SalidasInventarioInsertarDto salidasInventarioInsertarDto)
        {
            try
            {
                var sobrepasaLimite = (from sali in _unitOfWork.Repository<SalidasInventario>().AsQueryable()
                                       where sali.IdSucursal == salidasInventarioInsertarDto.IdSucursal && sali.IdEstado == (int)EstadosDeSalidas.EnviadaASucursal
                                       select sali.Total).ToList();

                var validarSucursal = _salidasInventarioDomainService.ValidarPermisoYDisponibilidad(salidasInventarioInsertarDto, sobrepasaLimite);

                if (!validarSucursal.Ok)
                    return Respuesta.Fault<SalidasInventarioListarDto>(validarSucursal.Mensaje);

                List<Lote> productosDisponbles = (from lote in _unitOfWork.Repository<Lote>().AsQueryable()
                                                  orderby lote.FechaVencimiento ascending
                                                  where lote.IdProducto == salidasInventarioInsertarDto.IdProducto
                                                  && lote.Inventario > 0
                                                  select new Lote
                                                  {
                                                      IdLote = lote.IdLote,
                                                      CostoUnidad = lote.CostoUnidad,
                                                      Inventario = lote.Inventario
                                                  }).ToList();

                var respuesta = _salidasInventarioDomainService.ConseguirDetalles(salidasInventarioInsertarDto, productosDisponbles);

                if (respuesta.Ok)
                {
                    SalidasInventario salida = new SalidasInventario
                    {
                        IdSucursal = salidasInventarioInsertarDto.IdSucursal,
                        Fecha = salidasInventarioInsertarDto.Fecha,
                        IdUsuario = salidasInventarioInsertarDto.IdUsuario,
                        IdEstado = (int)EstadosDeSalidas.EnviadaASucursal,
                        Total = (from detalles in respuesta.Data.AsQueryable()
                                 join lote in productosDisponbles.AsQueryable()
                                 on detalles.IdLote equals lote.IdLote
                                 select detalles.CantidadProducto * lote.CostoUnidad).Sum(),
                        IdUsuarioCreacion = DatosSesion.IdUsuario,
                        FechaCreacion = DateTime.Now,
                        SalidasInventarioDetalles = respuesta.Data
                    };

                    _unitOfWork.BeginTransaction();


                    foreach (var item in productosDisponbles)
                    {
                        var inventarioAEditar = _unitOfWork.Repository<Lote>().Where(x => x.IdLote == item.IdLote).FirstOrDefault();

                        if (inventarioAEditar != null)
                            inventarioAEditar.Inventario = item.Inventario;
                    }

                    _unitOfWork.Repository<SalidasInventario>().Add(salida);


                    _unitOfWork.Commit();
                    _unitOfWork.SaveChanges();

                    return Respuesta.Success(_mapper.Map<SalidasInventarioListarDto>(salida), Codigos.Success, Mensajes.OPERACION_EXITOSA("insertado"));

                }
                else
                {
                    return Respuesta.Fault<SalidasInventarioListarDto>(respuesta.Mensaje);
                }

            }
            catch (DbUpdateException ex)
            {
                return _commonService.RespuestasCatch<SalidasInventarioListarDto>(ex, "salida");
            }
        }

        public Respuesta<List<SalidasInventarioFiltradasDto>> ListarSalidasFiltro(DateTime fechaInicio, DateTime fechaFin, int IdSucursal)
        {
            var listado = (from sali in _unitOfWork.Repository<SalidasInventario>().AsQueryable()
                           join esta in _unitOfWork.Repository<Estado>().AsQueryable()
                           on sali.IdEstado equals esta.IdEstado
                           join usua in _unitOfWork.Repository<Usuario>().AsQueryable()
                           on sali.IdUsuarioRecibe equals usua.IdUsuario into usualeft
                           from subusua in usualeft.DefaultIfEmpty()
                           where sali.Fecha.Date >= fechaInicio.Date && sali.Fecha.Date <= fechaFin.Date && sali.IdSucursal == IdSucursal
                           select new SalidasInventarioFiltradasDto
                           {
                               IdSalidaInventario = sali.IdSalidaInventario,
                               Fecha = sali.Fecha,
                               CantidadUnidades = sali.SalidasInventarioDetalles.Sum(x => x.CantidadProducto),
                               Total = sali.Total,
                               IdEstado = sali.IdEstado,
                               NombreEstado = esta.Nombre,
                               IdUsuarioRecibe = sali.IdUsuarioRecibe,
                               NombreUsuarioRecibe = subusua.Nombre,
                               FechaRecibido = sali.FechaRecibido
                           }).ToList();

            return Respuesta.Success(listado, Mensajes.PROCESO_EXITOSO, Codigos.Success);
        }

        public Respuesta<SalidasInventarioListarDto> RecibirSalida(SalidasInventariosRecibirDto salidasInventariosRecibirDto)
        {
            try
            {
                var salidaARecibir = _unitOfWork.Repository<SalidasInventario>().AsQueryable().Where(x => x.IdSalidaInventario == salidasInventariosRecibirDto.IdSalida).FirstOrDefault();

                

                if (salidaARecibir != null)
                {
                    if (salidaARecibir.IdUsuarioRecibe != null || salidaARecibir.FechaRecibido != null)
                        return Respuesta.Fault<SalidasInventarioListarDto>("Esta salida ya ha sido recibida", Codigos.Info);

                    salidaARecibir.IdUsuarioRecibe = salidasInventariosRecibirDto.IdUsuarioRecibe;
                    salidaARecibir.FechaRecibido = salidasInventariosRecibirDto.FechaRecibido;
                }

                _unitOfWork.SaveChanges();

                return Respuesta.Success(_mapper.Map<SalidasInventarioListarDto>(salidaARecibir), Codigos.Success, Mensajes.OPERACION_EXITOSA("recibido"));

            } catch (DbUpdateException ex)
            {
                return _commonService.RespuestasCatch<SalidasInventarioListarDto>(ex, "salida");
            }

        }
    }
}
