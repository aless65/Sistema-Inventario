using Microsoft.EntityFrameworkCore;

namespace SistemaInventario.Infrastructure.Inventario_AJM.Maps
{
    public class InventarioAjmContext : DbContext
    {
        public InventarioAjmContext()
        {

        }
        public InventarioAjmContext(DbContextOptions<InventarioAjmContext> options) : base(options) 
        {

        }
    }
}
