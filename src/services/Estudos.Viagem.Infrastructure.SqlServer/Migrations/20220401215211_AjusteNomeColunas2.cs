using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Estudos.Viagem.Infrastructure.SqlServer.Migrations
{
    public partial class AjusteNomeColunas2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PrecoDiariaHotel",
                table: "Viagens",
                newName: "ValorDiariaHotel");

            migrationBuilder.RenameColumn(
                name: "PrecoDiariaCarro",
                table: "Viagens",
                newName: "ValorDiariaCarro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ValorDiariaHotel",
                table: "Viagens",
                newName: "PrecoDiariaHotel");

            migrationBuilder.RenameColumn(
                name: "ValorDiariaCarro",
                table: "Viagens",
                newName: "PrecoDiariaCarro");
        }
    }
}
