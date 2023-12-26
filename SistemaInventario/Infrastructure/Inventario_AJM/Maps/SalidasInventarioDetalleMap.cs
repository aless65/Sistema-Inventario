using AcademiaFS.Proyecto.Inventario.Infrastructure.Inventario_AJM.Entities;
using Farsiman.Domain.Core.Standard.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademiaFS.Proyecto.Inventario.Infrastructure.Inventario_AJM.Maps
{
    public class SalidasInventarioDetalleMap : IEntityTypeConfiguration<SalidasInventarioDetalle>
    {
        public void Configure(EntityTypeBuilder<SalidasInventarioDetalle> builder)
        {
            builder.HasKey(e => e.IdSalidaDetalle).HasName("PK_SalidasInventarioDetalles_IdSalidaDetalle");

            builder.Property(e => e.Activo).HasDefaultValue(true);
            builder.Property(e => e.FechaCreacion).HasColumnType("datetime");
            builder.Property(e => e.FechaModificacion).HasColumnType("datetime");

            builder.HasOne(d => d.IdLoteNavigation).WithMany(p => p.SalidasInventarioDetalles)
                .HasForeignKey(d => d.IdLote)
            .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.IdUsuarioCreacionNavigation).WithMany(p => p.SalidasInventarioDetalleIdUsuarioCreacionNavigations)
                .HasForeignKey(d => d.IdUsuarioCreacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalidasInventarioDetalles_IdUsuarioCreacion_IdUsuario");

            builder.HasOne(d => d.IdUsuarioModificacionNavigation).WithMany(p => p.SalidasInventarioDetalleIdUsuarioModificacionNavigations)
                .HasForeignKey(d => d.IdUsuarioModificacion)
                .HasConstraintName("FK_SalidasInventarioDetalles_IdUsuarioModificacion_IdUsuario");
        }
    }
}
