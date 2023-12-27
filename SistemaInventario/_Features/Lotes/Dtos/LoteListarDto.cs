namespace AcademiaFS.Proyecto.Inventario._Features.Lotes.Dtos
{
    public class LoteListarDto
    {
        public int IdLote { get; set; }

        public int IdProducto { get; set; }

        public string? NombreProducto { get; set; }

        public int CantidadInicial { get; set; }

        public decimal CostoUnidad { get; set; }

        public DateOnly FechaVencimiento { get; set; }

        public int Inventario { get; set; }
    }
}
