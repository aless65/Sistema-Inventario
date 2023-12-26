using AcademiaFS.Proyecto.Inventario.Infrastructure.Inventario_AJM.Entities;
using Farsiman.Domain.Core.Standard.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademiaFS.Proyecto.Inventario.Infrastructure.Inventario_AJM.Maps
{
    public class LoteMap : IEntityTypeConfiguration<Lote>
    {
        public void Configure(EntityTypeBuilder<Lote> builder)
        {
            builder.HasKey(e => e.IdLote).HasName("PK_Lotes_IdLote");

            builder.Property(e => e.Activo).HasDefaultValue(true);
            builder.Property(e => e.CostoUnidad).HasColumnType("decimal(18, 2)");
            builder.Property(e => e.FechaCreacion).HasColumnType("datetime");
            builder.Property(e => e.FechaModificacion).HasColumnType("datetime");

            builder.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Lotes)
                .HasForeignKey(d => d.IdProducto)
            .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.IdUsuarioCreacionNavigation).WithMany(p => p.LoteIdUsuarioCreacionNavigations)
                .HasForeignKey(d => d.IdUsuarioCreacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lotes_IdUsuarioCreacion_IdUsuario");

            builder.HasOne(d => d.IdUsuarioModificacionNavigation).WithMany(p => p.LoteIdUsuarioModificacionNavigations)
                .HasForeignKey(d => d.IdUsuarioModificacion)
                .HasConstraintName("FK_Lotes_IdUsuarioModificacion_IdUsuario");
        }
    }
}
