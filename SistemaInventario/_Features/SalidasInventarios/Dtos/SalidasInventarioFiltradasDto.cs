namespace AcademiaFS.Proyecto.Inventario._Features.SalidasInventarios.Dtos
{
    public class SalidasInventarioFiltradasDto
    {
        public int IdSalidaInventario { get; set; }

        public DateTime Fecha { get; set; }

        public int CantidadUnidades { get; set; }

        public decimal Total { get; set; }

        public int IdEstado { get; set; }

        public string? NombreEstado { get; set; }

        public DateTime? FechaRecibido { get; set; }

        public int? IdUsuarioRecibe { get; set; }

        public string? NombreUsuarioRecibe { get; set; }

    }
}
