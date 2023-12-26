﻿using System;
using System.Collections.Generic;

namespace SistemaInventario.Context;

public partial class Sucursale
{
    public int IdSucursal { get; set; }

    public string? Nombre { get; set; }

    public bool Activo { get; set; }

    public int IdUsuarioCreacion { get; set; }

    public DateTime FechaCreacion { get; set; }

    public int? IdUsuarioModificacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual Usuario IdUsuarioCreacionNavigation { get; set; } = null!;

    public virtual Usuario? IdUsuarioModificacionNavigation { get; set; }

    public virtual ICollection<SalidasInventario> SalidasInventarios { get; set; } = new List<SalidasInventario>();
}
