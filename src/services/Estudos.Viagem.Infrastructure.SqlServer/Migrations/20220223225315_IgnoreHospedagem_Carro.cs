using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Estudos.Viagem.Infrastructure.SqlServer.Migrations
{
    public partial class IgnoreHospedagem_Carro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Viagens_Carros_CarroId",
                table: "Viagens");

            migrationBuilder.DropForeignKey(
                name: "FK_Viagens_Hospedagens_HospedagemId",
                table: "Viagens");

            migrationBuilder.DropIndex(
                name: "IX_Viagens_CarroId",
                table: "Viagens");

            migrationBuilder.DropIndex(
                name: "IX_Viagens_HospedagemId",
                table: "Viagens");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Viagens_CarroId",
                table: "Viagens",
                column: "CarroId");

            migrationBuilder.CreateIndex(
                name: "IX_Viagens_HospedagemId",
                table: "Viagens",
                column: "HospedagemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Viagens_Carros_CarroId",
                table: "Viagens",
                column: "CarroId",
                principalTable: "Carros",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Viagens_Hospedagens_HospedagemId",
                table: "Viagens",
                column: "HospedagemId",
                principalTable: "Hospedagens",
                principalColumn: "Id");
        }
    }
}
