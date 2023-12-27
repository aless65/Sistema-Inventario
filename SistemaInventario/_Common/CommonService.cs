using AcademiaFS.Proyecto.Inventario._Features.Sucursales.Dtos;
using Farsiman.Application.Core.Standard.DTOs;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace SistemaInventario._Common
{
    public class CommonService
    {
        public Respuesta<T> RespuestasCatch<T>(DbUpdateException ex, string objeto)
        {
            var innerException = ex.InnerException;

            if (innerException is SqlException sqlException)
                if (sqlException.Number == 2601 || sqlException.Number == 2627)
                    return Respuesta.Fault<T>(Codigos.Error, Mensajes.REPETIDO(objeto));
                else if (sqlException.Number == 547)
                    return Respuesta.Fault<T>(Codigos.Error, Mensajes.LLAVE_FORANEA);

            return Respuesta.Fault<T>(Codigos.Error, Mensajes.PROCESO_FALLIDO);
        }
    }
}
