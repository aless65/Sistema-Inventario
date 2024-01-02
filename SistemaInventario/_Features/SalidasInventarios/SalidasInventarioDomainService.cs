using AcademiaFS.Proyecto.Inventario._Common;
using AcademiaFS.Proyecto.Inventario._Features.Auth.Dto;
using AcademiaFS.Proyecto.Inventario._Features.SalidasInventarios.Dtos;
using AcademiaFS.Proyecto.Inventario.Infrastructure.Inventario_AJM.Entities;
using AcademiaFS.Proyecto.Inventario.Utility;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;
using SistemaInventario._Common;
using System.Collections.Generic;

namespace AcademiaFS.Proyecto.Inventario._Features.SalidasInventarios
{
    public class SalidasInventarioDomainService
    {

        public Respuesta<bool> ValidarPermisoYDisponibilidad(int IdSucursal, List<decimal> salidasInventario)
        {
            if (DatosSesion.IdPerfil != (int)EstadosDeSalidas.JefeDeTiendaId && !DatosSesion.EsAdmin)
                return Respuesta.Fault<bool>(Mensajes.NO_AUTORIZADO, Codigos.Unauthorized);

            if (salidasInventario.Sum() > (int)EstadosDeSalidas.Limite)
                return Respuesta.Fault(Mensajes.LIMITE_SUCURSAL((int)EstadosDeSalidas.Limite), "", false);
            else
                return Respuesta.Success(true);
        }

        public Respuesta<List<SalidasInventarioDetalle>> ConseguirDetalles(SalidasInventarioInsertarDto salidasInventarioInsertarDto, List<Lote> productosDisponbles)
        {

            List<SalidasInventarioDetalle> detalles = new();

            List<Lote>  productosAlterados = new();

            if (productosDisponbles.Sum(x => x.Inventario) < salidasInventarioInsertarDto.Cantidad)
                return Respuesta.Fault(Mensajes.STOCK_INSUFICIENTE, "", detalles);
            else
            {
                foreach (var item in productosDisponbles)
                {
                    if (item.Inventario >= salidasInventarioInsertarDto.Cantidad)
                    {
                        detalles.Add(new SalidasInventarioDetalle
                        {
                            IdLote = item.IdLote,
                            CantidadProducto = salidasInventarioInsertarDto.Cantidad,
                        });

                        item.Inventario -= salidasInventarioInsertarDto.Cantidad;
                        salidasInventarioInsertarDto.Cantidad -= salidasInventarioInsertarDto.Cantidad;
                    }
                    else
                    {

                        detalles.Add(new SalidasInventarioDetalle
                        {
                            IdLote = item.IdLote,
                            CantidadProducto = item.Inventario,
                        });

                        salidasInventarioInsertarDto.Cantidad -= item.Inventario;
                        item.Inventario -= item.Inventario;

                    }

                    productosAlterados.Add(item);

                    if (salidasInventarioInsertarDto.Cantidad == 0)
                        break;
                }

                productosDisponbles = productosAlterados;

                return Respuesta.Success(detalles);

            }


        }
    }
}
