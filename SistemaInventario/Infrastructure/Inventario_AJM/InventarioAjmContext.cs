using AcademiaFS.Proyecto.Inventario.Infrastructure.Inventario_AJM.Entities;
using AcademiaFS.Proyecto.Inventario.Infrastructure.Inventario_AJM.Maps;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SistemaInventario.Infrastructure.Inventario_AJM
{
    public class InventarioAjmContext : DbContext
    {
        public InventarioAjmContext()
        {

        }
        public InventarioAjmContext(DbContextOptions<InventarioAjmContext> options) : base(options)
        {

        }

        public virtual DbSet<Empleado> Empleados { get; set; }

        public virtual DbSet<ErroresDb> __ErroresDb { get; set; }

        public virtual DbSet<Estado> Estados { get; set; }

        public virtual DbSet<Lote> Lotes { get; set; }

        public virtual DbSet<Perfil> Perfiles { get; set; }

        public virtual DbSet<PerfilesPorPermiso> PerfilesPorPermisos { get; set; }

        public virtual DbSet<Permiso> Permisos { get; set; }

        public virtual DbSet<Producto> Productos { get; set; }

        public virtual DbSet<SalidasInventario> SalidasInventarios { get; set; }

        public virtual DbSet<SalidasInventarioDetalle> SalidasInventarioDetalles { get; set; }

        public virtual DbSet<Sucursal> Sucursales { get; set; }

        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmpleadoMap());
            modelBuilder.ApplyConfiguration(new ErroresDbMap());
            modelBuilder.ApplyConfiguration(new EstadoMap());
            modelBuilder.ApplyConfiguration(new LoteMap());
            modelBuilder.ApplyConfiguration(new PerfilMap());
            modelBuilder.ApplyConfiguration(new PerfilesPorPermisoMap());
            modelBuilder.ApplyConfiguration(new PermisoMap());
            modelBuilder.ApplyConfiguration(new ProductoMap());
            modelBuilder.ApplyConfiguration(new SalidasInventarioMap());
            modelBuilder.ApplyConfiguration(new SalidasInventarioDetalleMap());
            modelBuilder.ApplyConfiguration(new SucursalMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }
    }
}
