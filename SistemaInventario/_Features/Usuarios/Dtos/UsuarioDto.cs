using System.ComponentModel.DataAnnotations;

namespace AcademiaFS.Proyecto.Inventario._Features.Usuarios.Dtos
{
    public class UsuarioDto
    {
        public int IdUsuario { get; set; }

        [Required]
        public string Nombre { get; set; } = null!;

        [Required]
        public string Contrasena { get; set; } = null!;

        public int? IdEmpleado { get; set; }

        public int? IdPerfil { get; set; }

        public bool EsAdmin { get; set; }
    }
}
