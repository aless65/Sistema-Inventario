using System;
using System.Collections.Generic;

namespace SistemaInventario.Context;

public partial class SalidasInventarioDetalle
{
    public int IdSalidaDetalle { get; set; }

    public int IdSalidaInventario { get; set; }

    public int IdLote { get; set; }

    public int CantidadProducto { get; set; }

    public bool Activo { get; set; }

    public int IdUsuarioCreacion { get; set; }

    public DateTime FechaCreacion { get; set; }

    public int? IdUsuarioModificacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual Lote IdLoteNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioCreacionNavigation { get; set; } = null!;

    public virtual Usuario? IdUsuarioModificacionNavigation { get; set; }
}
