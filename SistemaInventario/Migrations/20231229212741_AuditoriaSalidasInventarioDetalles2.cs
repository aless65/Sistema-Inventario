using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcademiaFS.Proyecto.Inventario.Migrations
{
    /// <inheritdoc />
    public partial class AuditoriaSalidasInventarioDetalles2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalidasInventarioDetalles_Usuarios_IdUsuarioCreacionNavigationIdUsuario",
                table: "SalidasInventarioDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_SalidasInventarioDetalles_Usuarios_IdUsuarioModificacionNavigationIdUsuario",
                table: "SalidasInventarioDetalles");

            migrationBuilder.DropColumn(
                name: "IdUsuarioCreacionNavigationIdUsuario",
                table: "SalidasInventarioDetalles");

            migrationBuilder.DropColumn(
                name: "IdUsuarioModificacionNavigationIdUsuario",
                table: "SalidasInventarioDetalles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUsuarioCreacionNavigationIdUsuario",
                table: "SalidasInventarioDetalles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuarioModificacionNavigationIdUsuario",
                table: "SalidasInventarioDetalles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalidasInventarioDetalles_IdUsuarioCreacionNavigationIdUsuario",
                table: "SalidasInventarioDetalles",
                column: "IdUsuarioCreacionNavigationIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_SalidasInventarioDetalles_IdUsuarioModificacionNavigationIdUsuario",
                table: "SalidasInventarioDetalles",
                column: "IdUsuarioModificacionNavigationIdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_SalidasInventarioDetalles_Usuarios_IdUsuarioCreacionNavigationIdUsuario",
                table: "SalidasInventarioDetalles",
                column: "IdUsuarioCreacionNavigationIdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalidasInventarioDetalles_Usuarios_IdUsuarioModificacionNavigationIdUsuario",
                table: "SalidasInventarioDetalles",
                column: "IdUsuarioModificacionNavigationIdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario");
        }
    }
}
