using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Buscador.Migrations
{
    public partial class CriandoSolicitacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Solicitado",
                table: "Trabalhadores",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Solicitacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DataDaSolicitacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    NomeSolicitante = table.Column<string>(type: "text", nullable: true),
                    DocumentoSolicitante = table.Column<string>(type: "text", nullable: true),
                    TrabalhadorId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Solicitacao_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Solicitacao_Trabalhadores_TrabalhadorId",
                        column: x => x.TrabalhadorId,
                        principalTable: "Trabalhadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacao_ClienteId",
                table: "Solicitacao",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacao_TrabalhadorId",
                table: "Solicitacao",
                column: "TrabalhadorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Solicitacao");

            migrationBuilder.DropColumn(
                name: "Solicitado",
                table: "Trabalhadores");
        }
    }
}
