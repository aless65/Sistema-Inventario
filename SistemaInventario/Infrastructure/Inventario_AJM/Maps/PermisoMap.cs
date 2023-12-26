using AcademiaFS.Proyecto.Inventario.Infrastructure.Inventario_AJM.Entities;
using Farsiman.Domain.Core.Standard.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademiaFS.Proyecto.Inventario.Infrastructure.Inventario_AJM.Maps
{
    public class PermisoMap : IEntityTypeConfiguration<Permiso>
    {
        public void Configure(EntityTypeBuilder<Permiso> builder)
        {
            builder.HasKey(e => e.IdPermiso).HasName("PK_Permisos_IdPermiso");

            builder.Property(e => e.Activo).HasDefaultValue(true);
            builder.Property(e => e.FechaCreacion).HasColumnType("datetime");
            builder.Property(e => e.FechaModificacion).HasColumnType("datetime");
            builder.Property(e => e.Nombre)
                .HasMaxLength(30)
            .IsUnicode(false);

            builder.HasOne(d => d.IdUsuarioCreacionNavigation).WithMany(p => p.PermisoIdUsuarioCreacionNavigations)
                .HasForeignKey(d => d.IdUsuarioCreacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Permisos_Usuarios_IdUsuarioCreacion_IdUsuario");

            builder.HasOne(d => d.IdUsuarioModificacionNavigation).WithMany(p => p.PermisoIdUsuarioModificacionNavigations)
                .HasForeignKey(d => d.IdUsuarioModificacion)
                .HasConstraintName("FK_Permisos_Usuarios_IdUsuarioModificacion_IdUsuario");
        }
    }
}
