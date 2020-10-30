using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AeroportoAPI.Migrations
{
    public partial class CriacaoInicialDoBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locais",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locais", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Voos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    dataIda = table.Column<DateTime>(nullable: false),
                    dataVolta = table.Column<DateTime>(nullable: false),
                    LocalOrigemID = table.Column<int>(nullable: true),
                    LocalDestinoID = table.Column<int>(nullable: true),
                    NumeroParadas = table.Column<int>(nullable: false),
                    TempoIda = table.Column<TimeSpan>(nullable: false),
                    TempoVolta = table.Column<TimeSpan>(nullable: false),
                    Preco = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voos_Locais_LocalDestinoID",
                        column: x => x.LocalDestinoID,
                        principalTable: "Locais",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Voos_Locais_LocalOrigemID",
                        column: x => x.LocalOrigemID,
                        principalTable: "Locais",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_Voos_LocalDestinoID",
                table: "Voos",
                column: "LocalDestinoID");

            migrationBuilder.CreateIndex(
                name: "IX_Voos_LocalOrigemID",
                table: "Voos",
                column: "LocalOrigemID");
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
