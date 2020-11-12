using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AeroportoAPI.Migrations
{
    public partial class CriacaoBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locais",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Voos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    dataIda = table.Column<DateTime>(nullable: false),
                    dataVolta = table.Column<DateTime>(nullable: false),
                    LocalOrigemId = table.Column<int>(nullable: false),
                    LocalDestinoId = table.Column<int>(nullable: false),
                    NumeroParadas = table.Column<int>(nullable: false),
                    TempoIda = table.Column<TimeSpan>(nullable: false),
                    TempoVolta = table.Column<TimeSpan>(nullable: false),
                    Preco = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voos_Locais_LocalDestinoId",
                        column: x => x.LocalDestinoId,
                        principalTable: "Locais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Voos_Locais_LocalOrigemId",
                        column: x => x.LocalOrigemId,
                        principalTable: "Locais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VooId = table.Column<int>(nullable: false),
                    Documento = table.Column<string>(nullable: true),
                    Poltrona = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservas_Voos_VooId",
                        column: x => x.VooId,
                        principalTable: "Voos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_VooId",
                table: "Reservas",
                column: "VooId");

            migrationBuilder.CreateIndex(
                name: "IX_Voos_LocalDestinoId",
                table: "Voos",
                column: "LocalDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Voos_LocalOrigemId",
                table: "Voos",
                column: "LocalOrigemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Voos");

            migrationBuilder.DropTable(
                name: "Locais");
        }
    }
}
