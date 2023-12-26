using System;
using System.Collections.Generic;

namespace AcademiaFS.Proyecto.Inventario.Infrastructure.Inventario_AJM.Entities;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public int? IdEmpleado { get; set; }

    public int? IdPerfil { get; set; }

    public bool EsAdmin { get; set; }

    public bool Activo { get; set; }

    public int IdUsuarioCreacion { get; set; }

    public DateTime FechaCreacion { get; set; }

    public int? IdUsuarioModificacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual ICollection<Empleado> EmpleadoIdUsuarioCreacionNavigations { get; set; } = new List<Empleado>();

    public virtual ICollection<Empleado> EmpleadoIdUsuarioModificacionNavigations { get; set; } = new List<Empleado>();

    public virtual ICollection<Estado> EstadoIdUsuarioCreacionNavigations { get; set; } = new List<Estado>();

    public virtual ICollection<Estado> EstadoIdUsuarioModificacionNavigations { get; set; } = new List<Estado>();

    public virtual Empleado? IdEmpleadoNavigation { get; set; }

    public virtual Perfile? IdPerfilNavigation { get; set; }

    public virtual Usuario IdUsuarioCreacionNavigation { get; set; } = null!;

    public virtual Usuario? IdUsuarioModificacionNavigation { get; set; }

    public virtual ICollection<Usuario> InverseIdUsuarioCreacionNavigation { get; set; } = new List<Usuario>();

    public virtual ICollection<Usuario> InverseIdUsuarioModificacionNavigation { get; set; } = new List<Usuario>();

    public virtual ICollection<Lote> LoteIdUsuarioCreacionNavigations { get; set; } = new List<Lote>();

    public virtual ICollection<Lote> LoteIdUsuarioModificacionNavigations { get; set; } = new List<Lote>();

    public virtual ICollection<Perfile> PerfileIdUsuarioCreacionNavigations { get; set; } = new List<Perfile>();

    public virtual ICollection<Perfile> PerfileIdUsuarioModificacionNavigations { get; set; } = new List<Perfile>();

    public virtual ICollection<Permiso> PermisoIdUsuarioCreacionNavigations { get; set; } = new List<Permiso>();

    public virtual ICollection<Permiso> PermisoIdUsuarioModificacionNavigations { get; set; } = new List<Permiso>();

    public virtual ICollection<Producto> ProductoIdUsuarioCreacionNavigations { get; set; } = new List<Producto>();

    public virtual ICollection<Producto> ProductoIdUsuarioModificacionNavigations { get; set; } = new List<Producto>();

    public virtual ICollection<SalidasInventarioDetalle> SalidasInventarioDetalleIdUsuarioCreacionNavigations { get; set; } = new List<SalidasInventarioDetalle>();

    public virtual ICollection<SalidasInventarioDetalle> SalidasInventarioDetalleIdUsuarioModificacionNavigations { get; set; } = new List<SalidasInventarioDetalle>();

    public virtual ICollection<SalidasInventario> SalidasInventarioIdUsuarioCreacionNavigations { get; set; } = new List<SalidasInventario>();

    public virtual ICollection<SalidasInventario> SalidasInventarioIdUsuarioModificacionNavigations { get; set; } = new List<SalidasInventario>();

    public virtual ICollection<SalidasInventario> SalidasInventarioIdUsuarioNavigations { get; set; } = new List<SalidasInventario>();

    public virtual ICollection<SalidasInventario> SalidasInventarioIdUsuarioRecibeNavigations { get; set; } = new List<SalidasInventario>();

    public virtual ICollection<Sucursal> SucursaleIdUsuarioCreacionNavigations { get; set; } = new List<Sucursal>();

    public virtual ICollection<Sucursal> SucursaleIdUsuarioModificacionNavigations { get; set; } = new List<Sucursal>();
}
