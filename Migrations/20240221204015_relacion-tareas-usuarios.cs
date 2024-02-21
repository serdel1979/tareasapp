using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TareasAsp.Migrations
{
    /// <inheritdoc />
    public partial class relaciontareasusuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsuarioCeacionId",
                table: "Tareas",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioCreacionId",
                table: "Tareas",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_UsuarioCeacionId",
                table: "Tareas",
                column: "UsuarioCeacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tareas_AspNetUsers_UsuarioCeacionId",
                table: "Tareas",
                column: "UsuarioCeacionId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tareas_AspNetUsers_UsuarioCeacionId",
                table: "Tareas");

            migrationBuilder.DropIndex(
                name: "IX_Tareas_UsuarioCeacionId",
                table: "Tareas");

            migrationBuilder.DropColumn(
                name: "UsuarioCeacionId",
                table: "Tareas");

            migrationBuilder.DropColumn(
                name: "UsuarioCreacionId",
                table: "Tareas");
        }
    }
}
