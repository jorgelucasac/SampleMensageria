using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Estudos.Viagem.Infrastructure.SqlServer.Migrations
{
    public partial class AddCarroEHospedagem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carros");

            migrationBuilder.DropTable(
                name: "Hospedagens");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "HospedagemId",
                table: "Viagens",
                newName: "HotelId");

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Viagens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Modelo",
                table: "Viagens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeHotel",
                table: "Viagens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecoDiariaCarro",
                table: "Viagens",
                type: "decimal(18,0)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecoDiariaHotel",
                table: "Viagens",
                type: "decimal(18,0)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Viagens");

            migrationBuilder.DropColumn(
                name: "Modelo",
                table: "Viagens");

            migrationBuilder.DropColumn(
                name: "NomeHotel",
                table: "Viagens");

            migrationBuilder.DropColumn(
                name: "PrecoDiariaCarro",
                table: "Viagens");

            migrationBuilder.DropColumn(
                name: "PrecoDiariaHotel",
                table: "Viagens");

            migrationBuilder.RenameColumn(
                name: "HotelId",
                table: "Viagens",
                newName: "HospedagemId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Carros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecoDiaria = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hospedagens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HotelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeHotel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecoDiaria = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospedagens", x => x.Id);
                });
        }
    }
}
