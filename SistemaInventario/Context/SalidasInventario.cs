﻿using System;
using System.Collections.Generic;

namespace SistemaInventario.Context;

public partial class SalidasInventario
{
    public int IdSalidaInventario { get; set; }

    public int IdSucursal { get; set; }

    public int IdUsuario { get; set; }

    public DateOnly Fecha { get; set; }

    public decimal Total { get; set; }

    public DateOnly FechaRecibido { get; set; }

    public int IdUsuarioRecibe { get; set; }

    public int IdEstado { get; set; }

    public bool Activo { get; set; }

    public int IdUsuarioCreacion { get; set; }

    public DateTime FechaCreacion { get; set; }

    public int? IdUsuarioModificacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual Estado IdEstadoNavigation { get; set; } = null!;

    public virtual Sucursale IdSucursalNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioCreacionNavigation { get; set; } = null!;

    public virtual Usuario? IdUsuarioModificacionNavigation { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioRecibeNavigation { get; set; } = null!;
}
