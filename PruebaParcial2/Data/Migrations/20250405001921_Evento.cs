using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaParcial2.Data.Migrations
{
    /// <inheritdoc />
    public partial class Evento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organizadores_Eventos_EventoId",
                table: "Organizadores");

            migrationBuilder.DropForeignKey(
                name: "FK_Participantes_Eventos_EventoId",
                table: "Participantes");

            migrationBuilder.DropIndex(
                name: "IX_Participantes_EventoId",
                table: "Participantes");

            migrationBuilder.DropIndex(
                name: "IX_Organizadores_EventoId",
                table: "Organizadores");

            migrationBuilder.DropColumn(
                name: "EventoId",
                table: "Participantes");

            migrationBuilder.DropColumn(
                name: "EventoId",
                table: "Organizadores");

            migrationBuilder.AlterColumn<string>(
                name: "Contacto",
                table: "Participantes",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Hora",
                table: "Eventos",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha",
                table: "Eventos",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Contacto",
                table: "Participantes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<int>(
                name: "EventoId",
                table: "Participantes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventoId",
                table: "Organizadores",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "Hora",
                table: "Eventos",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Fecha",
                table: "Eventos",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_Participantes_EventoId",
                table: "Participantes",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizadores_EventoId",
                table: "Organizadores",
                column: "EventoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizadores_Eventos_EventoId",
                table: "Organizadores",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Participantes_Eventos_EventoId",
                table: "Participantes",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "Id");
        }
    }
}
