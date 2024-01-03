using System.ComponentModel.DataAnnotations;

namespace AcademiaFS.Proyecto.Inventario._Features.Lotes.Dtos
{
    public class LoteDto
    {
        public int IdLote { get; set; }

        public int IdProducto { get; set; }

        public int CantidadInicial { get; set; }

        public decimal CostoUnidad { get; set; }

        public DateOnly FechaVencimiento { get; set; }

    }
}
