namespace AcademiaFS.Proyecto.Inventario.Infrastructure.Inventario_AJM.Entities
{
    public class ErroresDb
    {
        public int IdErrores { get; set; }
        public DateTime FechaYHora { get; set; }
        public string? Codigo { get; set; }
        public string? Mensaje { get; set; }
    }
}
