using System.ComponentModel.DataAnnotations;

namespace AcademiaFS.Proyecto.Inventario._Features.Sucursales.Dtos
{
    public class SucursalDto
    {
        public int IdSucursal { get; set; }

        [Required]
        public string Nombre { get; set; } = null!;
    }
}
