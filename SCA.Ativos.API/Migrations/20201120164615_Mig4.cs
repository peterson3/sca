using Microsoft.EntityFrameworkCore.Migrations;

namespace SCA.Ativos.API.Migrations
{
    public partial class Mig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ativos_TipoAtivos_TipoId",
                table: "Ativos");

            migrationBuilder.AlterColumn<int>(
                name: "TipoId",
                table: "Ativos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ativos_TipoAtivos_TipoId",
                table: "Ativos",
                column: "TipoId",
                principalTable: "TipoAtivos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ativos_TipoAtivos_TipoId",
                table: "Ativos");

            migrationBuilder.AlterColumn<int>(
                name: "TipoId",
                table: "Ativos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Ativos_TipoAtivos_TipoId",
                table: "Ativos",
                column: "TipoId",
                principalTable: "TipoAtivos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
