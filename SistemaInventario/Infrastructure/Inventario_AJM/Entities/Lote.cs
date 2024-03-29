﻿using FluentValidation;
using SistemaInventario._Common;
using System;
using System.Collections.Generic;

namespace AcademiaFS.Proyecto.Inventario.Infrastructure.Inventario_AJM.Entities;

public partial class Lote
{
    public int IdLote { get; set; }

    public int IdProducto { get; set; }

    public int CantidadInicial { get; set; }

    public decimal CostoUnidad { get; set; }

    public DateOnly FechaVencimiento { get; set; }

    public int Inventario { get; set; }

    public bool? Activo { get; set; }

    public int IdUsuarioCreacion { get; set; }

    public DateTime FechaCreacion { get; set; }

    public int? IdUsuarioModificacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioCreacionNavigation { get; set; } = null!;

    public virtual Usuario? IdUsuarioModificacionNavigation { get; set; }

    public virtual ICollection<SalidasInventarioDetalle> SalidasInventarioDetalles { get; set; } = new List<SalidasInventarioDetalle>();
}

public class LoteValidator : AbstractValidator<Lote>
{
    public LoteValidator()
    {
        RuleFor(r => r.CantidadInicial).GreaterThan(0).WithMessage(Mensajes.CAMPO_MAYOR("Cantidad inicial", 0));
        RuleFor(r => r.CostoUnidad).GreaterThan(0).WithMessage(Mensajes.CAMPO_MAYOR("Costo por unidad", 0));
    }
}

