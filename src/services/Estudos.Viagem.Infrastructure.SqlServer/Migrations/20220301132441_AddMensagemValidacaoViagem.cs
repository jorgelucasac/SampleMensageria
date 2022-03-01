using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Estudos.Viagem.Infrastructure.SqlServer.Migrations
{
    public partial class AddMensagemValidacaoViagem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MensagensValidacoes",
                table: "Viagens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MensagensValidacoes",
                table: "Viagens");
        }
    }
}
