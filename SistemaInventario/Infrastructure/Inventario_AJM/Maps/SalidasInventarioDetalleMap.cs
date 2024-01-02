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

            builder.HasOne(d => d.IdLoteNavigation).WithMany(p => p.SalidasInventarioDetalles)
                .HasForeignKey(d => d.IdLote)
            .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.IdSalidaInventarioNavigation).WithMany(p => p.SalidasInventarioDetalles)
                .HasForeignKey(d => d.IdSalidaInventario)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
