using AcademiaFS.Proyecto.Inventario.Infrastructure.Inventario_AJM.Entities;
using Farsiman.Domain.Core.Standard.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademiaFS.Proyecto.Inventario.Infrastructure.Inventario_AJM.Maps
{
    public class SucursalMap : IEntityTypeConfiguration<Sucursal>
    {
        public void Configure(EntityTypeBuilder<Sucursal> builder)
        {
            builder.HasKey(e => e.IdSucursal).HasName("PK_Sucursales_IdSucursal");

            builder.Property(e => e.Activo).HasDefaultValue(true);
            builder.Property(e => e.FechaCreacion).HasColumnType("datetime");
            builder.Property(e => e.FechaModificacion).HasColumnType("datetime");
            builder.Property(e => e.Nombre)
                .HasMaxLength(150)
            .IsUnicode(false);

            builder.HasOne(d => d.IdUsuarioCreacionNavigation).WithMany(p => p.SucursaleIdUsuarioCreacionNavigations)
                .HasForeignKey(d => d.IdUsuarioCreacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sucursales_IdUsuarioCreacion_IdUsuario");

            builder.HasOne(d => d.IdUsuarioModificacionNavigation).WithMany(p => p.SucursaleIdUsuarioModificacionNavigations)
                .HasForeignKey(d => d.IdUsuarioModificacion)
                .HasConstraintName("FK_Sucursales_IdUsuarioModificacion_IdUsuario");
        }
    }
}
