namespace AcademiaFS.Proyecto.Inventario._Features.SalidasInventarios.Dtos
{
    public class SalidasInventarioListarDto
    {
        public int IdSalidaInventario { get; set; }

        public int IdSucursal { get; set; }

        public string NombreSucursal { get; set; } = null!;

        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; } = null!;

        public DateTime Fecha { get; set; }

        public decimal Total { get; set; }

        public DateTime? FechaRecibido { get; set; }

        public int? IdUsuarioRecibe { get; set; }
        public string? NombreUsuarioRecibe { get; set; }

        public int IdEstado { get; set; }

        public bool? Activo { get; set; }

        public virtual ICollection<SalidasInventarioDetalleDto>? SalidasInventarioDetalles { get; set; } = new List<SalidasInventarioDetalleDto>();
    }
}
