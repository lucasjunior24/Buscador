using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Buscador.Migrations
{
    public partial class CriandoAgendamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agendamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataDoAgendamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusDoAgendamento = table.Column<int>(type: "int", nullable: false),
                    DiaAgendado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrabalhadorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamentos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamentos");
        }
    }
}
