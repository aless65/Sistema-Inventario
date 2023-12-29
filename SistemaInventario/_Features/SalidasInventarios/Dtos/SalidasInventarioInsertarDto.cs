namespace AcademiaFS.Proyecto.Inventario._Features.SalidasInventarios.Dtos
{
    public class SalidasInventarioInsertarDto
    {
        public int IdSucursal { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        public int IdUsuario { get; set; }
    }
}
