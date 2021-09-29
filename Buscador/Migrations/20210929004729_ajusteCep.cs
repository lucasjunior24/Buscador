using Microsoft.EntityFrameworkCore.Migrations;

namespace Buscador.Migrations
{
    public partial class ajusteCep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "EnderecoDosTrabalhadores",
                type: "varchar(11)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(8)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "EnderecoDosTrabalhadores",
                type: "varchar(8)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(11)");
        }
    }
}
