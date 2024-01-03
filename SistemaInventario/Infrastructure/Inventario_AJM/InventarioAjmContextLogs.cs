using AcademiaFS.Proyecto.Inventario.Infrastructure.Inventario_AJM.Entities;
using AcademiaFS.Proyecto.Inventario.Infrastructure.Inventario_AJM.Maps;
using Microsoft.EntityFrameworkCore;

namespace AcademiaFS.Proyecto.Inventario.Infrastructure.Inventario_AJM
{
    public class InventarioAjmContextLogs : DbContext
    {
        public InventarioAjmContextLogs()
        {

        }

        public InventarioAjmContextLogs(DbContextOptions<InventarioAjmContextLogs> options) : base(options)
        {

        }
        public virtual DbSet<ErroresDb> __ErroresDb { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ErroresDbMap());
        }
    }
}
