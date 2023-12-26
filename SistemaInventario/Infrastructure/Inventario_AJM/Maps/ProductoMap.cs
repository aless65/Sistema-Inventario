using AcademiaFS.Proyecto.Inventario.Infrastructure.Inventario_AJM.Entities;
using Farsiman.Domain.Core.Standard.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademiaFS.Proyecto.Inventario.Infrastructure.Inventario_AJM.Maps
{
    public class ProductoMap : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.HasKey(e => e.IdProducto).HasName("PK_Productos_IdProducto");

            builder.Property(e => e.Activo).HasDefaultValue(true);
            builder.Property(e => e.FechaCreacion).HasColumnType("datetime");
            builder.Property(e => e.FechaModificacion).HasColumnType("datetime");
            builder.Property(e => e.Nombre)
                .HasMaxLength(100)
            .IsUnicode(false);

            builder.HasOne(d => d.IdUsuarioCreacionNavigation).WithMany(p => p.ProductoIdUsuarioCreacionNavigations)
                .HasForeignKey(d => d.IdUsuarioCreacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Productos_IdUsuarioCreacion_IdUsuario");

            builder.HasOne(d => d.IdUsuarioModificacionNavigation).WithMany(p => p.ProductoIdUsuarioModificacionNavigations)
                .HasForeignKey(d => d.IdUsuarioModificacion)
                .HasConstraintName("FK_Productos_IdUsuarioModificacion_IdUsuario");
        }
    }
}
