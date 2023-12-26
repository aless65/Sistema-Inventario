using AcademiaFS.Proyecto.Inventario.Infrastructure.Inventario_AJM.Entities;
using Farsiman.Domain.Core.Standard.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademiaFS.Proyecto.Inventario.Infrastructure.Inventario_AJM.Maps
{
    public class SalidasInventarioMap : IEntityTypeConfiguration<SalidasInventario>
    {
        public void Configure(EntityTypeBuilder<SalidasInventario> builder)
        {
            builder.HasKey(e => e.IdSalidaInventario).HasName("PK_SalidasInventario_IdSalidaInventario");
            builder.ToTable("SalidasInventario");

            builder.Property(e => e.Activo).HasDefaultValue(true);
            builder.Property(e => e.Fecha).HasColumnType("datetime");
            builder.Property(e => e.FechaCreacion).HasColumnType("datetime");
            builder.Property(e => e.FechaModificacion).HasColumnType("datetime");
            builder.Property(e => e.Total).HasColumnType("decimal(18, 2)");

            builder.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.SalidasInventarios)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.SalidasInventarios)
                .HasForeignKey(d => d.IdSucursal)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.SalidasInventarioIdUsuarioNavigations)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.IdUsuarioCreacionNavigation).WithMany(p => p.SalidasInventarioIdUsuarioCreacionNavigations)
                .HasForeignKey(d => d.IdUsuarioCreacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalidasInventario_IdUsuarioCreacion_IdUsuario");

            builder.HasOne(d => d.IdUsuarioModificacionNavigation).WithMany(p => p.SalidasInventarioIdUsuarioModificacionNavigations)
                .HasForeignKey(d => d.IdUsuarioModificacion)
                .HasConstraintName("FK_SalidasInventario_IdUsuarioModificacion_IdUsuario");

            builder.HasOne(d => d.IdUsuarioRecibeNavigation).WithMany(p => p.SalidasInventarioIdUsuarioRecibeNavigations)
                .HasForeignKey(d => d.IdUsuarioRecibe)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
