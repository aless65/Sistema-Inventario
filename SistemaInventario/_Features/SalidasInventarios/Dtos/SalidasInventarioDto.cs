namespace AcademiaFS.Proyecto.Inventario._Features.SalidasInventarios.Dtos
{
    public class SalidasInventarioDto
    {
        public int IdSalidaInventario { get; set; }

        public int IdSucursal { get; set; }

        public int IdUsuario { get; set; }

        public DateTime Fecha { get; set; }

        public decimal Total { get; set; }

        public DateOnly FechaRecibido { get; set; }

        public int IdUsuarioRecibe { get; set; }    

        public int IdEstado { get; set; }
    }
}
