using Microsoft.EntityFrameworkCore.Migrations;

namespace SCA.Ativos.API.Migrations
{
    public partial class AdicManutencao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRealizada",
                table: "Manutencoes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRealizada",
                table: "Manutencoes");
        }
    }
}
