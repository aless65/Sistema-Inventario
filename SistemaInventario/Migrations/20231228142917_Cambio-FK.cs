using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcademiaFS.Proyecto.Inventario.Migrations
{
    /// <inheritdoc />
    public partial class CambioFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SalidasInventarioDetalles_IdSalidaInventario",
                table: "SalidasInventarioDetalles",
                column: "IdSalidaInventario");

            migrationBuilder.AddForeignKey(
                name: "FK_SalidasInventarioDetalles_SalidasInventario_IdSalidaInventario",
                table: "SalidasInventarioDetalles",
                column: "IdSalidaInventario",
                principalTable: "SalidasInventario",
                principalColumn: "IdSalidaInventario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalidasInventarioDetalles_SalidasInventario_IdSalidaInventario",
                table: "SalidasInventarioDetalles");

            migrationBuilder.DropIndex(
                name: "IX_SalidasInventarioDetalles_IdSalidaInventario",
                table: "SalidasInventarioDetalles");
        }
    }
}
