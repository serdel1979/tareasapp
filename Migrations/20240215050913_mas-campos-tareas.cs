using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TareasAsp.Migrations
{
    /// <inheritdoc />
    public partial class mascampostareas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Tareas",
                newName: "Titulo");

            migrationBuilder.AddColumn<int>(
                name: "Orden",
                table: "Tareas",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Orden",
                table: "Tareas");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Tareas",
                newName: "Nombre");
        }
    }
}
