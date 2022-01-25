using Microsoft.EntityFrameworkCore.Migrations;

namespace Buscador.Migrations
{
    public partial class CriandoCampoAprovacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Disponivel",
                table: "Trabalhadores",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Aprovado",
                table: "Solicitacoes",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Disponivel",
                table: "Trabalhadores");

            migrationBuilder.DropColumn(
                name: "Aprovado",
                table: "Solicitacoes");
        }
    }
}
