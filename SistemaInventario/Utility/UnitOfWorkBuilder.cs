using Farsiman.Domain.Core.Standard.Repositories;
using Farsiman.Infraestructure.Core.Entity.Standard;
using Microsoft.EntityFrameworkCore;
using SistemaInventario.Infrastructure.Inventario_AJM;

namespace AcademiaFS.Proyecto.Inventario.Utility
{
    public class UnitOfWorkBuilder
    {
        readonly IServiceProvider _serviceProvider;
        public UnitOfWorkBuilder(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IUnitOfWork BuilderInventarioAjm()
        {
            DbContext dbContext = _serviceProvider.GetService<InventarioAjmContext>() ?? throw new NullReferenceException();
            return new UnitOfWork(dbContext);
        }

        public IUnitOfWork BuilderInventarioAjmLogs()
        {
            DbContext dbContext = _serviceProvider.GetService<InventarioAjmContext>() ?? throw new NullReferenceException();
            return new UnitOfWork(dbContext);
        }
    }
}
