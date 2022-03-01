using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Estudos.Viagem.Infrastructure.SqlServer.Migrations
{
    public partial class AddMensagemValidacaoViagem2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MensagensValidacoes",
                table: "Viagens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MensagensValidacoes",
                table: "Viagens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
