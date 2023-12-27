using System.ComponentModel.DataAnnotations;

namespace AcademiaFS.Proyecto.Inventario._Features.Empleados.Dtos
{
    public class EmpleadoDto
    {
        public int IdEmpleado { get; set; }

        [Required]
        public string Identidad { get; set; } = null!; 

        [Required]
        public string Nombres { get; set; } = null!;

        [Required]
        public string Apellidos { get; set; } = null!;

        [Required]
        public string Telefono { get; set; } = null!;

        [Required]
        public string Direccion { get; set; } = null!;
    }
}
