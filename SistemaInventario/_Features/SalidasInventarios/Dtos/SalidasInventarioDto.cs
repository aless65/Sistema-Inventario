﻿using AcademiaFS.Proyecto.Inventario.Infrastructure.Inventario_AJM.Entities;

namespace AcademiaFS.Proyecto.Inventario._Features.SalidasInventarios.Dtos
{
    public class SalidasInventarioDto
    {
        public int IdSalidaInventario { get; set; }

        public int IdSucursal { get; set; }

        public int IdUsuario { get; set; }

        public DateTime Fecha { get; set; }

        public int IdEstado { get; set; }
        public virtual ICollection<SalidasInventarioDetalleDto> SalidasInventarioDetalles { get; set; } = new List<SalidasInventarioDetalleDto>();
    }
}
