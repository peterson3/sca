using Microsoft.EntityFrameworkCore.Migrations;

namespace SCA.Ativos.API.Migrations
{
    public partial class Mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AtivoId",
                table: "Manutencoes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoId",
                table: "Ativos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Manutencoes_AtivoId",
                table: "Manutencoes",
                column: "AtivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ativos_TipoId",
                table: "Ativos",
                column: "TipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ativos_TipoAtivos_TipoId",
                table: "Ativos",
                column: "TipoId",
                principalTable: "TipoAtivos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Manutencoes_Ativos_AtivoId",
                table: "Manutencoes",
                column: "AtivoId",
                principalTable: "Ativos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ativos_TipoAtivos_TipoId",
                table: "Ativos");

            migrationBuilder.DropForeignKey(
                name: "FK_Manutencoes_Ativos_AtivoId",
                table: "Manutencoes");

            migrationBuilder.DropIndex(
                name: "IX_Manutencoes_AtivoId",
                table: "Manutencoes");

            migrationBuilder.DropIndex(
                name: "IX_Ativos_TipoId",
                table: "Ativos");

            migrationBuilder.DropColumn(
                name: "AtivoId",
                table: "Manutencoes");

            migrationBuilder.DropColumn(
                name: "TipoId",
                table: "Ativos");
        }
    }
}
