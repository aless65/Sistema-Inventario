using AcademiaFS.Proyecto.Inventario.Infrastructure.Inventario_AJM.Entities;
using Farsiman.Domain.Core.Standard.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademiaFS.Proyecto.Inventario.Infrastructure.Inventario_AJM.Maps
{
    public class PerfilesPorPermisoMap : IEntityTypeConfiguration<PerfilesPorPermiso>
    {
        public void Configure(EntityTypeBuilder<PerfilesPorPermiso> builder)
        {
            builder.HasKey(e => e.IdPermisoPerfil).HasName("PK_PerfilesPorPermisos_IdPermisoPerfil");
        }
    }
}
