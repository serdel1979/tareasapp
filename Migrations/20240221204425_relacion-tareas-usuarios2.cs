using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TareasAsp.Migrations
{
    /// <inheritdoc />
    public partial class relaciontareasusuarios2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_UsuarioCreacionId",
                table: "Tareas",
                column: "UsuarioCreacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tareas_AspNetUsers_UsuarioCreacionId",
                table: "Tareas",
                column: "UsuarioCreacionId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tareas_AspNetUsers_UsuarioCreacionId",
                table: "Tareas");

            migrationBuilder.DropIndex(
                name: "IX_Tareas_UsuarioCreacionId",
                table: "Tareas");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioCeacionId",
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
    }
}
