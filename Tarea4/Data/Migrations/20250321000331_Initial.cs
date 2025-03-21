using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tarea4.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alimentaciones");

            migrationBuilder.DropTable(
                name: "PecesHabitaciones");

            migrationBuilder.DropTable(
                name: "Alimentos");

            migrationBuilder.DropTable(
                name: "Habitaciones");

            migrationBuilder.DropTable(
                name: "Peces");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alimentos",
                columns: table => new
                {
                    IdAlimento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CantidadDisponible = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alimentos", x => x.IdAlimento);
                });

            migrationBuilder.CreateTable(
                name: "Habitaciones",
                columns: table => new
                {
                    IdHabitacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacidad = table.Column<int>(type: "int", nullable: false),
                    NivelAgua = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TemperaturaIdeal = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitaciones", x => x.IdHabitacion);
                });

            migrationBuilder.CreateTable(
                name: "Peces",
                columns: table => new
                {
                    IdPez = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Especie = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FechaIngreso = table.Column<DateOnly>(type: "date", nullable: true),
                    NombreCientifico = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NombreComun = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peces", x => x.IdPez);
                });

            migrationBuilder.CreateTable(
                name: "Alimentaciones",
                columns: table => new
                {
                    IdAlimentacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAlimento = table.Column<int>(type: "int", nullable: false),
                    IdPez = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    FechaAlimentacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alimentaciones", x => x.IdAlimentacion);
                    table.ForeignKey(
                        name: "FK_Alimentaciones_Alimentos_IdAlimento",
                        column: x => x.IdAlimento,
                        principalTable: "Alimentos",
                        principalColumn: "IdAlimento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alimentaciones_Peces_IdPez",
                        column: x => x.IdPez,
                        principalTable: "Peces",
                        principalColumn: "IdPez",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PecesHabitaciones",
                columns: table => new
                {
                    IdPez = table.Column<int>(type: "int", nullable: false),
                    IdHabitacion = table.Column<int>(type: "int", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PecesHabitaciones", x => new { x.IdPez, x.IdHabitacion });
                    table.ForeignKey(
                        name: "FK_PecesHabitaciones_Habitaciones_IdHabitacion",
                        column: x => x.IdHabitacion,
                        principalTable: "Habitaciones",
                        principalColumn: "IdHabitacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PecesHabitaciones_Peces_IdPez",
                        column: x => x.IdPez,
                        principalTable: "Peces",
                        principalColumn: "IdPez",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alimentaciones_IdAlimento",
                table: "Alimentaciones",
                column: "IdAlimento");

            migrationBuilder.CreateIndex(
                name: "IX_Alimentaciones_IdPez",
                table: "Alimentaciones",
                column: "IdPez");

            migrationBuilder.CreateIndex(
                name: "IX_PecesHabitaciones_IdHabitacion",
                table: "PecesHabitaciones",
                column: "IdHabitacion");
        }
    }
}
