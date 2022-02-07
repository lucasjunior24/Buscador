using Microsoft.EntityFrameworkCore.Migrations;

namespace Buscador.Migrations
{
    public partial class StatusDaSolicitacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Solicitacoes_TrabalhadorId",
                table: "Solicitacoes");

            migrationBuilder.DropColumn(
                name: "Aprovado",
                table: "Solicitacoes");

            migrationBuilder.AddColumn<int>(
                name: "StatusDaSolicitacao",
                table: "Solicitacoes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacoes_TrabalhadorId",
                table: "Solicitacoes",
                column: "TrabalhadorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Solicitacoes_TrabalhadorId",
                table: "Solicitacoes");

            migrationBuilder.DropColumn(
                name: "StatusDaSolicitacao",
                table: "Solicitacoes");

            migrationBuilder.AddColumn<bool>(
                name: "Aprovado",
                table: "Solicitacoes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacoes_TrabalhadorId",
                table: "Solicitacoes",
                column: "TrabalhadorId",
                unique: true);
        }
    }
}
