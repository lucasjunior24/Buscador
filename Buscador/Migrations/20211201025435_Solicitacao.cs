using Microsoft.EntityFrameworkCore.Migrations;

namespace Buscador.Migrations
{
    public partial class Solicitacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solicitacao_Clientes_ClienteId",
                table: "Solicitacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Solicitacao_Trabalhadores_TrabalhadorId",
                table: "Solicitacao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Solicitacao",
                table: "Solicitacao");

            migrationBuilder.DropIndex(
                name: "IX_Solicitacao_TrabalhadorId",
                table: "Solicitacao");

            migrationBuilder.RenameTable(
                name: "Solicitacao",
                newName: "Solicitacoes");

            migrationBuilder.RenameIndex(
                name: "IX_Solicitacao_ClienteId",
                table: "Solicitacoes",
                newName: "IX_Solicitacoes_ClienteId");

            migrationBuilder.AlterColumn<string>(
                name: "NomeSolicitante",
                table: "Solicitacoes",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DocumentoSolicitante",
                table: "Solicitacoes",
                type: "varchar(14)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Solicitacoes",
                table: "Solicitacoes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacoes_TrabalhadorId",
                table: "Solicitacoes",
                column: "TrabalhadorId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitacoes_Clientes_ClienteId",
                table: "Solicitacoes",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitacoes_Trabalhadores_TrabalhadorId",
                table: "Solicitacoes",
                column: "TrabalhadorId",
                principalTable: "Trabalhadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solicitacoes_Clientes_ClienteId",
                table: "Solicitacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Solicitacoes_Trabalhadores_TrabalhadorId",
                table: "Solicitacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Solicitacoes",
                table: "Solicitacoes");

            migrationBuilder.DropIndex(
                name: "IX_Solicitacoes_TrabalhadorId",
                table: "Solicitacoes");

            migrationBuilder.RenameTable(
                name: "Solicitacoes",
                newName: "Solicitacao");

            migrationBuilder.RenameIndex(
                name: "IX_Solicitacoes_ClienteId",
                table: "Solicitacao",
                newName: "IX_Solicitacao_ClienteId");

            migrationBuilder.AlterColumn<string>(
                name: "NomeSolicitante",
                table: "Solicitacao",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "DocumentoSolicitante",
                table: "Solicitacao",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(14)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Solicitacao",
                table: "Solicitacao",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacao_TrabalhadorId",
                table: "Solicitacao",
                column: "TrabalhadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitacao_Clientes_ClienteId",
                table: "Solicitacao",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitacao_Trabalhadores_TrabalhadorId",
                table: "Solicitacao",
                column: "TrabalhadorId",
                principalTable: "Trabalhadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
