using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaParcial2.Data.Migrations
{
    /// <inheritdoc />
    public partial class Lugar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Capacidad",
                table: "Lugares",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacidad",
                table: "Lugares");
        }
    }
}
