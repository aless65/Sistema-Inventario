using AcademiaFS.Proyecto.Inventario.Infrastructure.Inventario_AJM.Entities;
using Farsiman.Domain.Core.Standard.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademiaFS.Proyecto.Inventario.Infrastructure.Inventario_AJM.Maps
{
    public class EmpleadoMap : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.HasKey(e => e.IdEmpleado).HasName("PK_Empleados_IdEmpleado");

            builder.Property(e => e.Activo).HasDefaultValue(true);
            builder.Property(e => e.Apellidos)
                .HasMaxLength(150)
                .IsUnicode(false);
            builder.Property(e => e.Direccion)
                .HasMaxLength(500)
                .IsUnicode(false);
            builder.Property(e => e.FechaCreacion).HasColumnType("datetime");
            builder.Property(e => e.FechaModificacion).HasColumnType("datetime");
            builder.Property(e => e.Identidad)
                .HasMaxLength(13)
                .IsUnicode(false);
            builder.Property(e => e.Nombres)
                .HasMaxLength(150)
                .IsUnicode(false);
            builder.Property(e => e.Telefono)
                .HasMaxLength(20)
            .IsUnicode(false);

            builder.HasOne(d => d.IdUsuarioCreacionNavigation).WithMany(p => p.EmpleadoIdUsuarioCreacionNavigations)
                .HasForeignKey(d => d.IdUsuarioCreacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empleados_Usuarios_IdUsuarioCreacion_IdUsuario");

            builder.HasOne(d => d.IdUsuarioModificacionNavigation).WithMany(p => p.EmpleadoIdUsuarioModificacionNavigations)
                .HasForeignKey(d => d.IdUsuarioModificacion)
                .HasConstraintName("FK_Empleados_Usuarios_IdUsuarioModificacion_IdUsuario");
        }
    }
}
