using AcademiaFS.Proyecto.Inventario.Infrastructure.Inventario_AJM.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademiaFS.Proyecto.Inventario.Infrastructure.Inventario_AJM.Maps
{
    public class ErroresDbMap : IEntityTypeConfiguration<ErroresDb>
    {
        public void Configure(EntityTypeBuilder<ErroresDb> builder)
        {
            builder.HasKey(e => e.IdErrores).HasName("PK_ErroresDb_IdErrores");

            builder.Property(e => e.FechaYHora).HasColumnType("datetime");
            builder.Property(e => e.Codigo)
                .HasMaxLength(10)
                .IsUnicode(false);
        }
    }
}
