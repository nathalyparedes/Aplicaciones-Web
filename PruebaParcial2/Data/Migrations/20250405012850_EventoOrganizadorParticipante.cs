using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaParcial2.Data.Migrations
{
    /// <inheritdoc />
    public partial class EventoOrganizadorParticipante : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaInscripcion",
                table: "EventoParticipantes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaInscripcion",
                table: "EventoParticipantes");
        }
    }
}
