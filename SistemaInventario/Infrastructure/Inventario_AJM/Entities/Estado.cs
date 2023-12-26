using System;
using System.Collections.Generic;

namespace AcademiaFS.Proyecto.Inventario.Infrastructure.Inventario_AJM.Entities;

public partial class Estado
{
    public int IdEstado { get; set; }

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
