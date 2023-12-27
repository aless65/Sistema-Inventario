namespace AcademiaFS.Proyecto.Inventario._Features.Usuarios.Dtos
{
    public class UsuarioListarDto
    {
        public int IdUsuario { get; set; }

        public string Nombre { get; set; } = null!;

        public string Contrasena { get; set; } = null!;

        public int? IdEmpleado { get; set; }

        public string? NombreEmpleado { get; set; }

        public int? IdPerfil { get; set; }

        public string? NombrePerfil { get; set; }

        public bool EsAdmin { get; set; }
    }
}
