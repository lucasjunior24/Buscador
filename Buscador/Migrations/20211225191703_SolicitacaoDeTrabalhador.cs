using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Buscador.Migrations
{
    public partial class SolicitacaoDeTrabalhador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Foto = table.Column<string>(type: "varchar(200)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(20)", nullable: false),
                    Email = table.Column<string>(type: "varchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trabalhadores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Documento = table.Column<string>(type: "varchar(14)", nullable: false),
                    TipoDeTrabalhador = table.Column<string>(type: "varchar(50)", nullable: false),
                    Profissao = table.Column<string>(type: "varchar(140)", nullable: false),
                    Solicitado = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Foto = table.Column<string>(type: "varchar(200)", nullable: false),
                    Telefone = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "varchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trabalhadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnderecoDosClientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uuid", nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(200)", nullable: false),
                    Numero = table.Column<string>(type: "varchar(50)", nullable: false),
                    Complemento = table.Column<string>(type: "varchar(250)", nullable: false),
                    Cep = table.Column<string>(type: "varchar(11)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(100)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecoDosClientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnderecoDosClientes_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnderecoDosTrabalhadores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TrabalhadorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(200)", nullable: false),
                    Numero = table.Column<string>(type: "varchar(50)", nullable: false),
                    Complemento = table.Column<string>(type: "varchar(250)", nullable: false),
                    Cep = table.Column<string>(type: "varchar(11)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(100)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecoDosTrabalhadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnderecoDosTrabalhadores_Trabalhadores_TrabalhadorId",
                        column: x => x.TrabalhadorId,
                        principalTable: "Trabalhadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Solicitacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DataDaSolicitacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    NomeSolicitante = table.Column<string>(type: "varchar(200)", nullable: false),
                    NomeTrabalhador = table.Column<string>(type: "varchar(200)", nullable: false),
                    ProfisssaoDoTrabalhador = table.Column<string>(type: "text", nullable: true),
                    TrabalhadorId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Solicitacoes_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Solicitacoes_Trabalhadores_TrabalhadorId",
                        column: x => x.TrabalhadorId,
                        principalTable: "Trabalhadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TiposDeServicos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TrabalhadorId = table.Column<Guid>(type: "uuid", nullable: false),
                    NomeDoServico = table.Column<string>(type: "varchar(200)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: false),
                    Imagem = table.Column<string>(type: "varchar(200)", nullable: false),
                    AreaProfissional = table.Column<string>(type: "text", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposDeServicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TiposDeServicos_Trabalhadores_TrabalhadorId",
                        column: x => x.TrabalhadorId,
                        principalTable: "Trabalhadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoDosClientes_ClienteId",
                table: "EnderecoDosClientes",
                column: "ClienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoDosTrabalhadores_TrabalhadorId",
                table: "EnderecoDosTrabalhadores",
                column: "TrabalhadorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacoes_ClienteId",
                table: "Solicitacoes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacoes_TrabalhadorId",
                table: "Solicitacoes",
                column: "TrabalhadorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TiposDeServicos_TrabalhadorId",
                table: "TiposDeServicos",
                column: "TrabalhadorId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnderecoDosClientes");

            migrationBuilder.DropTable(
                name: "EnderecoDosTrabalhadores");

            migrationBuilder.DropTable(
                name: "Solicitacoes");

            migrationBuilder.DropTable(
                name: "TiposDeServicos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Trabalhadores");
        }
    }
}
