using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Estudos.Viagem.Infrastructure.SqlServer.Migrations
{
    public partial class AjusteNomeColunas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Modelo",
                table: "Viagens",
                newName: "ModeloCarro");

            migrationBuilder.RenameColumn(
                name: "Categoria",
                table: "Viagens",
                newName: "CategoriaCarro");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoDiariaHotel",
                table: "Viagens",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoDiariaCarro",
                table: "Viagens",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModeloCarro",
                table: "Viagens",
                newName: "Modelo");

            migrationBuilder.RenameColumn(
                name: "CategoriaCarro",
                table: "Viagens",
                newName: "Categoria");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoDiariaHotel",
                table: "Viagens",
                type: "decimal(18,0)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoDiariaCarro",
                table: "Viagens",
                type: "decimal(18,0)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);
        }
    }
}
