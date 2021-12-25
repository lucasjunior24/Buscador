using Microsoft.EntityFrameworkCore.Migrations;

namespace Buscador.Migrations
{
    public partial class AddCamposDeSolicitacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NomeSolicitante",
                table: "Solicitacoes",
                newName: "NomeDoCliente");

            migrationBuilder.RenameColumn(
                name: "DocumentoSolicitante",
                table: "Solicitacoes",
                newName: "NomeDoTrabalhador");

            migrationBuilder.AddColumn<string>(
                name: "ProfissaoDoTrabalhador",
                table: "Solicitacoes",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfissaoDoTrabalhador",
                table: "Solicitacoes");

            migrationBuilder.RenameColumn(
                name: "NomeDoTrabalhador",
                table: "Solicitacoes",
                newName: "DocumentoSolicitante");

            migrationBuilder.RenameColumn(
                name: "NomeDoCliente",
                table: "Solicitacoes",
                newName: "NomeSolicitante");
        }
    }
}
