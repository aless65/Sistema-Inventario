using System;
using System.Collections.Generic;
using AcademiaFS.Proyecto.Inventario.Infrastructure.Inventario_AJM.Entities;
using Microsoft.EntityFrameworkCore;

namespace SistemaInventario.Context;

public partial class InventarioAjmContext : DbContext
{
    public InventarioAjmContext()
    {
    }

    public InventarioAjmContext(DbContextOptions<InventarioAjmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Lote> Lotes { get; set; }

    public virtual DbSet<Perfile> Perfiles { get; set; }

    public virtual DbSet<PerfilesPorPermiso> PerfilesPorPermisos { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<SalidasInventario> SalidasInventarios { get; set; }

    public virtual DbSet<SalidasInventarioDetalle> SalidasInventarioDetalles { get; set; }

    public virtual DbSet<Sucursal> Sucursales { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=192.168.1.33\\\\\\\\academiagfs,49194;Database=Inventario_AJM;User id=academiadev;Password=Demia#20;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK_Empleados_IdEmpleado");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Apellidos)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Identidad)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.Nombres)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioCreacionNavigation).WithMany(p => p.EmpleadoIdUsuarioCreacionNavigations)
                .HasForeignKey(d => d.IdUsuarioCreacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empleados_Usuarios_IdUsuarioCreacion_IdUsuario");

            entity.HasOne(d => d.IdUsuarioModificacionNavigation).WithMany(p => p.EmpleadoIdUsuarioModificacionNavigations)
                .HasForeignKey(d => d.IdUsuarioModificacion)
                .HasConstraintName("FK_Empleados_Usuarios_IdUsuarioModificacion_IdUsuario");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PK_Estados_IdEstado");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioCreacionNavigation).WithMany(p => p.EstadoIdUsuarioCreacionNavigations)
                .HasForeignKey(d => d.IdUsuarioCreacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Estados_IdUsuarioCreacion_IdUsuario");

            entity.HasOne(d => d.IdUsuarioModificacionNavigation).WithMany(p => p.EstadoIdUsuarioModificacionNavigations)
                .HasForeignKey(d => d.IdUsuarioModificacion)
                .HasConstraintName("FK_Estados_IdUsuarioModificacion_IdUsuario");
        });

        modelBuilder.Entity<Lote>(entity =>
        {
            entity.HasKey(e => e.IdLote).HasName("PK_Lotes_IdLote");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.CostoUnidad).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Lotes)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.IdUsuarioCreacionNavigation).WithMany(p => p.LoteIdUsuarioCreacionNavigations)
                .HasForeignKey(d => d.IdUsuarioCreacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lotes_IdUsuarioCreacion_IdUsuario");

            entity.HasOne(d => d.IdUsuarioModificacionNavigation).WithMany(p => p.LoteIdUsuarioModificacionNavigations)
                .HasForeignKey(d => d.IdUsuarioModificacion)
                .HasConstraintName("FK_Lotes_IdUsuarioModificacion_IdUsuario");
        });

        modelBuilder.Entity<Perfile>(entity =>
        {
            entity.HasKey(e => e.IdPerfil).HasName("PK_Perfiles_IdEmpleado");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioCreacionNavigation).WithMany(p => p.PerfileIdUsuarioCreacionNavigations)
                .HasForeignKey(d => d.IdUsuarioCreacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Perfiles_Usuarios_IdUsuarioCreacion_IdUsuario");

            entity.HasOne(d => d.IdUsuarioModificacionNavigation).WithMany(p => p.PerfileIdUsuarioModificacionNavigations)
                .HasForeignKey(d => d.IdUsuarioModificacion)
                .HasConstraintName("FK_Perfiles_Usuarios_IdUsuarioModificacion_IdUsuario");
        });

        modelBuilder.Entity<PerfilesPorPermiso>(entity =>
        {
            entity.HasKey(e => e.IdPermisoPerfil).HasName("PK_PerfilesPorPermisos_IdPermisoPerfil");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.IdPermiso).HasName("PK_Permisos_IdPermiso");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioCreacionNavigation).WithMany(p => p.PermisoIdUsuarioCreacionNavigations)
                .HasForeignKey(d => d.IdUsuarioCreacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Permisos_Usuarios_IdUsuarioCreacion_IdUsuario");

            entity.HasOne(d => d.IdUsuarioModificacionNavigation).WithMany(p => p.PermisoIdUsuarioModificacionNavigations)
                .HasForeignKey(d => d.IdUsuarioModificacion)
                .HasConstraintName("FK_Permisos_Usuarios_IdUsuarioModificacion_IdUsuario");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK_Productos_IdProducto");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioCreacionNavigation).WithMany(p => p.ProductoIdUsuarioCreacionNavigations)
                .HasForeignKey(d => d.IdUsuarioCreacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Productos_IdUsuarioCreacion_IdUsuario");

            entity.HasOne(d => d.IdUsuarioModificacionNavigation).WithMany(p => p.ProductoIdUsuarioModificacionNavigations)
                .HasForeignKey(d => d.IdUsuarioModificacion)
                .HasConstraintName("FK_Productos_IdUsuarioModificacion_IdUsuario");
        });

        modelBuilder.Entity<SalidasInventario>(entity =>
        {
            entity.HasKey(e => e.IdSalidaInventario).HasName("PK_SalidasInventario_IdSalidaInventario");

            entity.ToTable("SalidasInventario");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.SalidasInventarios)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.SalidasInventarios)
                .HasForeignKey(d => d.IdSucursal)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.SalidasInventarioIdUsuarioNavigations)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.IdUsuarioCreacionNavigation).WithMany(p => p.SalidasInventarioIdUsuarioCreacionNavigations)
                .HasForeignKey(d => d.IdUsuarioCreacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalidasInventario_IdUsuarioCreacion_IdUsuario");

            entity.HasOne(d => d.IdUsuarioModificacionNavigation).WithMany(p => p.SalidasInventarioIdUsuarioModificacionNavigations)
                .HasForeignKey(d => d.IdUsuarioModificacion)
                .HasConstraintName("FK_SalidasInventario_IdUsuarioModificacion_IdUsuario");

            entity.HasOne(d => d.IdUsuarioRecibeNavigation).WithMany(p => p.SalidasInventarioIdUsuarioRecibeNavigations)
                .HasForeignKey(d => d.IdUsuarioRecibe)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<SalidasInventarioDetalle>(entity =>
        {
            entity.HasKey(e => e.IdSalidaDetalle).HasName("PK_SalidasInventarioDetalles_IdSalidaDetalle");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

            entity.HasOne(d => d.IdLoteNavigation).WithMany(p => p.SalidasInventarioDetalles)
                .HasForeignKey(d => d.IdLote)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.IdUsuarioCreacionNavigation).WithMany(p => p.SalidasInventarioDetalleIdUsuarioCreacionNavigations)
                .HasForeignKey(d => d.IdUsuarioCreacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalidasInventarioDetalles_IdUsuarioCreacion_IdUsuario");

            entity.HasOne(d => d.IdUsuarioModificacionNavigation).WithMany(p => p.SalidasInventarioDetalleIdUsuarioModificacionNavigations)
                .HasForeignKey(d => d.IdUsuarioModificacion)
                .HasConstraintName("FK_SalidasInventarioDetalles_IdUsuarioModificacion_IdUsuario");
        });

        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.HasKey(e => e.IdSucursal).HasName("PK_Sucursales_IdSucursal");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioCreacionNavigation).WithMany(p => p.SucursaleIdUsuarioCreacionNavigations)
                .HasForeignKey(d => d.IdUsuarioCreacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sucursales_IdUsuarioCreacion_IdUsuario");

            entity.HasOne(d => d.IdUsuarioModificacionNavigation).WithMany(p => p.SucursaleIdUsuarioModificacionNavigations)
                .HasForeignKey(d => d.IdUsuarioModificacion)
                .HasConstraintName("FK_Sucursales_IdUsuarioModificacion_IdUsuario");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK_Usuarios_IdUsuario");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Usuarios).HasForeignKey(d => d.IdEmpleado);

            entity.HasOne(d => d.IdPerfilNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdPerfil)
                .HasConstraintName("FK_Usuarios_Perfil_IdPerfil");

            entity.HasOne(d => d.IdUsuarioCreacionNavigation).WithMany(p => p.InverseIdUsuarioCreacionNavigation)
                .HasForeignKey(d => d.IdUsuarioCreacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuarios_IdUsuarioCreacion_IdUsuario");

            entity.HasOne(d => d.IdUsuarioModificacionNavigation).WithMany(p => p.InverseIdUsuarioModificacionNavigation)
                .HasForeignKey(d => d.IdUsuarioModificacion)
                .HasConstraintName("FK_Usuarios_IdUsuarioModificacion_IdUsuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
