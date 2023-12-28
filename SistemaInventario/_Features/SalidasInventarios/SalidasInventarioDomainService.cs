using AcademiaFS.Proyecto.Inventario._Features.SalidasInventarios.Dtos;
using AcademiaFS.Proyecto.Inventario.Infrastructure.Inventario_AJM.Entities;
using Farsiman.Application.Core.Standard.DTOs;
using System.Collections.Generic;

namespace AcademiaFS.Proyecto.Inventario._Features.SalidasInventarios
{
    public class SalidasInventarioDomainService
    {
        public Respuesta<List<SalidasInventarioDetalle>> ConseguirDetalles(SalidasInventarioInsertarDto salidasInventarioInsertarDto, List<Lote> lotes)
        {
            var productosDisponbles = (from lote in lotes.AsQueryable()
                                       orderby lote.FechaVencimiento ascending
                                       where lote.IdProducto == salidasInventarioInsertarDto.IdProducto
                                       && lote.Inventario > 0
                                       select new { 
                                           lote.IdLote, 
                                           lote.Inventario }).ToList();

            List<SalidasInventarioDetalle> detalles = new();

            if (productosDisponbles.Sum(x => x.Inventario) < salidasInventarioInsertarDto.Cantidad)
                return Respuesta.Fault("Stock insuficiente", "400", detalles);

            return Respuesta.Success(detalles);

        }
    }
}
