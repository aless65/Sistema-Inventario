﻿using System;
using System.Collections.Generic;

namespace AcademiaFS.Proyecto.Inventario.Infrastructure.Inventario_AJM.Entities;

public partial class SalidasInventarioDetalle
{
    public int IdSalidaDetalle { get; set; }

    public int IdSalidaInventario { get; set; }

    public int IdLote { get; set; }

    public int CantidadProducto { get; set; }

    public virtual Lote IdLoteNavigation { get; set; } = null!;

    public virtual SalidasInventario IdSalidaInventarioNavigation { get; set; } = null!;
}
