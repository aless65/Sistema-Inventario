namespace AcademiaFS.Proyecto.Inventario._Features.Usuarios.Dtos
{
    public class UsuarioDto
    {
        public int IdUsuario { get; set; }

        public string Nombre { get; set; } = null!;

        public string Contrasena { get; set; } = null!;

        public int? IdEmpleado { get; set; }

        public int? IdPerfil { get; set; }

        public bool EsAdmin { get; set; }
    }
}
