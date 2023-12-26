using AcademiaFS.Proyecto.Inventario.Infrastructure.Inventario_AJM.Entities;
using Farsiman.Domain.Core.Standard.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademiaFS.Proyecto.Inventario.Infrastructure.Inventario_AJM.Maps
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(e => e.IdUsuario).HasName("PK_Usuarios_IdUsuario");

            builder.Property(e => e.Activo).HasDefaultValue(true);
            builder.Property(e => e.FechaCreacion).HasColumnType("datetime");
            builder.Property(e => e.FechaModificacion).HasColumnType("datetime");
            builder.Property(e => e.Nombre)
                .HasMaxLength(30)
            .IsUnicode(false);

            builder.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Usuarios).HasForeignKey(d => d.IdEmpleado);

            builder.HasOne(d => d.IdPerfilNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdPerfil)
                .HasConstraintName("FK_Usuarios_Perfil_IdPerfil");

            builder.HasOne(d => d.IdUsuarioCreacionNavigation).WithMany(p => p.InverseIdUsuarioCreacionNavigation)
                .HasForeignKey(d => d.IdUsuarioCreacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuarios_IdUsuarioCreacion_IdUsuario");

            builder.HasOne(d => d.IdUsuarioModificacionNavigation).WithMany(p => p.InverseIdUsuarioModificacionNavigation)
                .HasForeignKey(d => d.IdUsuarioModificacion)
                .HasConstraintName("FK_Usuarios_IdUsuarioModificacion_IdUsuario");
        }
    }
}
