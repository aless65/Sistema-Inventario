using AcademiaFS.Proyecto.Inventario._Features.Sucursales.Dtos;
using AcademiaFS.Proyecto.Inventario.Infrastructure.Inventario_AJM.Entities;
using AcademiaFS.Proyecto.Inventario.Utility;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;
using Farsiman.Infraestructure.Core.Entity.Standard;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SistemaInventario.Infrastructure.Inventario_AJM;


namespace SistemaInventario._Common
{
    public class CommonService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommonService(UnitOfWorkBuilder unitOfWork)
        {
            _unitOfWork = unitOfWork.BuilderInventarioAjmLogs();
        }

        public Respuesta<T> RespuestasCatch<T>(DbUpdateException ex, string objeto)
        {
            var innerException = ex.InnerException;

            if (innerException is SqlException sqlException)
            {

                //using (var erroresDbContext = new InventarioAjmContext())
                //{
                _unitOfWork.Repository<ErroresDb>()
                .Add(new ErroresDb
                {
                    FechaYHora = DateTime.Now,
                    Codigo = sqlException.Number.ToString(),
                    Mensaje = sqlException.Message,
                });

                _unitOfWork.SaveChanges();

                //}
                //_unitOfWork.ChangeTracker.Entries()
                //.Where(x => x.State == EntityState.Modified &&
                //            !typeof(ErroresDb).IsAssignableFrom(x.Entity.GetType()))
                //.ToList()
                //.ForEach(entry =>
                //{
                //    entry.CurrentValues.SetValues(entry.OriginalValues);
                //});

                if (sqlException.Number == 2601 || sqlException.Number == 2627)
                    return Respuesta.Fault<T>(Codigos.Error, Mensajes.REPETIDO(objeto));
                else if (sqlException.Number == 547)
                    return Respuesta.Fault<T>(Codigos.Error, Mensajes.LLAVE_FORANEA);
            }

            return Respuesta.Fault<T>(Codigos.Error, Mensajes.PROCESO_FALLIDO);
        }
    }
}
