using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Buscador.Migrations
{
    public partial class CriandoPerfil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PerfilId",
                table: "Trabalhadores",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PerfilId",
                table: "Clientes",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Clientes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Perfis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    PerfilDeUsuario = table.Column<string>(type: "varchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfis", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trabalhadores_PerfilId",
                table: "Trabalhadores",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_PerfilId",
                table: "Clientes",
                column: "PerfilId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Perfis_PerfilId",
                table: "Clientes",
                column: "PerfilId",
                principalTable: "Perfis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trabalhadores_Perfis_PerfilId",
                table: "Trabalhadores",
                column: "PerfilId",
                principalTable: "Perfis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Perfis_PerfilId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Trabalhadores_Perfis_PerfilId",
                table: "Trabalhadores");

            migrationBuilder.DropTable(
                name: "Perfis");

            migrationBuilder.DropIndex(
                name: "IX_Trabalhadores_PerfilId",
                table: "Trabalhadores");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_PerfilId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "PerfilId",
                table: "Trabalhadores");

            migrationBuilder.DropColumn(
                name: "PerfilId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Clientes");
        }
    }
}
