using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcademiaFS.Proyecto.Inventario.Migrations
{
    /// <inheritdoc />
    public partial class AuditoriaSalidasInventarioDetalles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalidasInventarioDetalles_IdUsuarioCreacion_IdUsuario",
                table: "SalidasInventarioDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_SalidasInventarioDetalles_IdUsuarioModificacion_IdUsuario",
                table: "SalidasInventarioDetalles");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "SalidasInventarioDetalles");

            migrationBuilder.DropColumn(
                name: "FechaModificacion",
                table: "SalidasInventarioDetalles");

            migrationBuilder.RenameColumn(
                name: "IdUsuarioModificacion",
                table: "SalidasInventarioDetalles",
                newName: "IdUsuarioModificacionNavigationIdUsuario");

            migrationBuilder.RenameColumn(
                name: "IdUsuarioCreacion",
                table: "SalidasInventarioDetalles",
                newName: "IdUsuarioCreacionNavigationIdUsuario");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalidasInventarioDetalles_Usuarios_IdUsuarioCreacionNavigationIdUsuario",
                table: "SalidasInventarioDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_SalidasInventarioDetalles_Usuarios_IdUsuarioModificacionNavigationIdUsuario",
                table: "SalidasInventarioDetalles");

            migrationBuilder.RenameColumn(
                name: "IdUsuarioModificacionNavigationIdUsuario",
                table: "SalidasInventarioDetalles",
                newName: "IdUsuarioModificacion");

            migrationBuilder.RenameColumn(
                name: "IdUsuarioCreacionNavigationIdUsuario",
                table: "SalidasInventarioDetalles",
                newName: "IdUsuarioCreacion");

            migrationBuilder.RenameIndex(
                name: "IX_SalidasInventarioDetalles_IdUsuarioModificacionNavigationIdUsuario",
                table: "SalidasInventarioDetalles",
                newName: "IX_SalidasInventarioDetalles_IdUsuarioModificacion");

            migrationBuilder.RenameIndex(
                name: "IX_SalidasInventarioDetalles_IdUsuarioCreacionNavigationIdUsuario",
                table: "SalidasInventarioDetalles",
                newName: "IX_SalidasInventarioDetalles_IdUsuarioCreacion");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "SalidasInventarioDetalles",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaModificacion",
                table: "SalidasInventarioDetalles",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SalidasInventarioDetalles_IdUsuarioCreacion_IdUsuario",
                table: "SalidasInventarioDetalles",
                column: "IdUsuarioCreacion",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_SalidasInventarioDetalles_IdUsuarioModificacion_IdUsuario",
                table: "SalidasInventarioDetalles",
                column: "IdUsuarioModificacion",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario");
        }
    }
}
