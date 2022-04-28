using Microsoft.EntityFrameworkCore.Migrations;

namespace Buscador.Migrations
{
    public partial class camposTrabalhador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CursoOuFormaçao",
                table: "Trabalhadores",
                type: "varchar(1000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Trabalhadores",
                type: "varchar(1000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TempoExperiencia",
                table: "Trabalhadores",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CursoOuFormaçao",
                table: "Trabalhadores");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Trabalhadores");

            migrationBuilder.DropColumn(
                name: "TempoExperiencia",
                table: "Trabalhadores");
        }
    }
}
