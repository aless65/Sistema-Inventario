using AcademiaFS.Proyecto.Inventario._Features.Lotes.Dtos;
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
    public class LoteService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly CommonService _commonService;

        public LoteService(UnitOfWorkBuilder unitOfWork, IMapper mapper, CommonService commonService)
        {
            _unitOfWork = unitOfWork.BuilderInventarioAjm();
            _mapper = mapper;
            _commonService = commonService;
        }

        public Respuesta<List<LoteListarDto>> ListarLotes()
        {
            try
            {
                var listado = (from lote in _unitOfWork.Repository<Lote>().AsQueryable()
                               join prod in _unitOfWork.Repository<Producto>().AsQueryable()
                               on lote.IdProducto equals prod.IdProducto
                               where lote.Activo == true
                               select new LoteListarDto
                               {
                                   IdLote = lote.IdLote,
                                   IdProducto = lote.IdProducto,
                                   NombreProducto = prod.Nombre,
                                   CantidadInicial = lote.CantidadInicial,
                                   CostoUnidad = lote.CostoUnidad,
                                   FechaVencimiento = lote.FechaVencimiento,
                                   Inventario = lote.Inventario
                               }).ToList();

                return Respuesta.Success(listado, Codigos.Success, Mensajes.PROCESO_EXITOSO);
            }
            catch
            {
                return Respuesta.Fault<List<LoteListarDto>>(Codigos.Error, Mensajes.PROCESO_FALLIDO);
            }
        }

        public Respuesta<LoteDto> InsertarLotes(LoteDto loteDto)
        {
            try
            {
                var lote = _mapper.Map<Lote>(loteDto);

                lote.FechaCreacion = DateTime.Now;
                lote.IdUsuarioCreacion = 1;

                _unitOfWork.Repository<Lote>().Add(lote);
                _unitOfWork.SaveChanges();

                return Respuesta.Success(_mapper.Map<LoteDto>(lote), Codigos.Success, Mensajes.OPERACION_EXITOSA("insertado"));
            }
            catch (DbUpdateException ex)
            {
                return _commonService.RespuestasCatch<LoteDto>(ex, "lote");

            }
        }

        public Respuesta<LoteDto> EditarLotes(LoteDto loteDto)
        {
            try
            {
                var lote = _unitOfWork.Repository<Lote>().Where(x => x.IdLote == loteDto.IdLote).FirstOrDefault();

                if (lote != null)
                {
                    lote.CantidadInicial = loteDto.CantidadInicial;
                    lote.CostoUnidad = loteDto.CostoUnidad;
                    lote.IdProducto = loteDto.IdProducto;
                    lote.FechaModificacion = DateTime.Now;
                    lote.IdUsuarioModificacion = 1;

                    _unitOfWork.SaveChanges();
                }

                return Respuesta.Success(_mapper.Map<LoteDto>(lote), Codigos.Success, Mensajes.OPERACION_EXITOSA("editado"));
            }
            catch (DbUpdateException ex)
            {

                return _commonService.RespuestasCatch<LoteDto>(ex, "lote");
            }
        }

        public Respuesta<string> EliminarLotes(int id)
        {
            try
            {
                var lote = _unitOfWork.Repository<Lote>().Where(x => x.IdLote == id).FirstOrDefault();

                if (lote != null)
                {
                    lote.Activo = false;

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
