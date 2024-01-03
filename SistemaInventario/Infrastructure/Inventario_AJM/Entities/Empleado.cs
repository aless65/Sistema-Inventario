using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SistemaInventario._Common;
using System;
using System.Collections.Generic;

namespace AcademiaFS.Proyecto.Inventario.Infrastructure.Inventario_AJM.Entities;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string Identidad { get; set; } = null!;

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public bool? Activo { get; set; }

    public int IdUsuarioCreacion { get; set; }

    public DateTime FechaCreacion { get; set; }

    public int? IdUsuarioModificacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual Usuario IdUsuarioCreacionNavigation { get; set; } = null!;

    public virtual Usuario? IdUsuarioModificacionNavigation { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}

public class EmpleadoValidator : AbstractValidator<Empleado>
{
    public EmpleadoValidator()
    {
        RuleFor(r => r.Identidad).NotEmpty().MaximumLength(13).MinimumLength(13).WithMessage(Mensajes.LONGITUD_ERRONEA("Identidad", 13));
        RuleFor(r => r.Telefono).NotEmpty().MinimumLength(8).WithMessage(Mensajes.LONGITUD_ERRONEA("Teléfono", 8));
    }
}
