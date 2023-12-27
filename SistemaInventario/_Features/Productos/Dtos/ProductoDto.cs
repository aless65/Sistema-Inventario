using System.ComponentModel.DataAnnotations;

namespace AcademiaFS.Proyecto.Inventario._Features.Productos.Dtos
{
    public class ProductoDto
    {
        public int IdProducto { get; set; }

        [Required]
        public string? Nombre { get; set; } = null!;
    }
}
