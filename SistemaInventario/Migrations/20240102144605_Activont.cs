using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcademiaFS.Proyecto.Inventario.Migrations
{
    /// <inheritdoc />
    public partial class Activont : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activo",
                table: "SalidasInventarioDetalles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "SalidasInventarioDetalles",
                type: "bit",
                nullable: true,
                defaultValue: true);
        }
    }
}
