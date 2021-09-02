using Microsoft.EntityFrameworkCore.Migrations;

namespace Buscador.Migrations
{
    public partial class EnderecoCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnderecosDosTrabalhadores_Clientes_ClienteId",
                table: "EnderecosDosTrabalhadores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EnderecosDosTrabalhadores",
                table: "EnderecosDosTrabalhadores");

            migrationBuilder.RenameTable(
                name: "EnderecosDosTrabalhadores",
                newName: "EnderecoDosClientes");

            migrationBuilder.RenameIndex(
                name: "IX_EnderecosDosTrabalhadores_ClienteId",
                table: "EnderecoDosClientes",
                newName: "IX_EnderecoDosClientes_ClienteId");

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "EnderecoDosTrabalhadores",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Logradouro",
                table: "EnderecoDosTrabalhadores",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "EnderecoDosTrabalhadores",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Complemento",
                table: "EnderecoDosTrabalhadores",
                type: "varchar(250)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "EnderecoDosTrabalhadores",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "EnderecoDosTrabalhadores",
                type: "varchar(8)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Bairro",
                table: "EnderecoDosTrabalhadores",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EnderecoDosClientes",
                table: "EnderecoDosClientes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EnderecoDosClientes_Clientes_ClienteId",
                table: "EnderecoDosClientes",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnderecoDosClientes_Clientes_ClienteId",
                table: "EnderecoDosClientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EnderecoDosClientes",
                table: "EnderecoDosClientes");

            migrationBuilder.RenameTable(
                name: "EnderecoDosClientes",
                newName: "EnderecosDosTrabalhadores");

            migrationBuilder.RenameIndex(
                name: "IX_EnderecoDosClientes_ClienteId",
                table: "EnderecosDosTrabalhadores",
                newName: "IX_EnderecosDosTrabalhadores_ClienteId");

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "EnderecoDosTrabalhadores",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Logradouro",
                table: "EnderecoDosTrabalhadores",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "EnderecoDosTrabalhadores",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Complemento",
                table: "EnderecoDosTrabalhadores",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(250)");

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "EnderecoDosTrabalhadores",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "EnderecoDosTrabalhadores",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(8)");

            migrationBuilder.AlterColumn<string>(
                name: "Bairro",
                table: "EnderecoDosTrabalhadores",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EnderecosDosTrabalhadores",
                table: "EnderecosDosTrabalhadores",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EnderecosDosTrabalhadores_Clientes_ClienteId",
                table: "EnderecosDosTrabalhadores",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
