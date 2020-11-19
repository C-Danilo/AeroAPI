using Microsoft.EntityFrameworkCore.Migrations;

namespace AeroportoAPI.Migrations
{
    public partial class CriacaoColunaLimitePassageiro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LimitePassageiros",
                table: "Voos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LimitePassageiros",
                table: "Voos");
        }
    }
}
