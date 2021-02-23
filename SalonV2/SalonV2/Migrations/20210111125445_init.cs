using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SalonV2.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klienci",
                columns: table => new
                {
                    KlienciId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(nullable: false),
                    Nazwisko = table.Column<string>(nullable: false),
                    NumerTel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klienci", x => x.KlienciId);
                });

            migrationBuilder.CreateTable(
                name: "Uslugi",
                columns: table => new
                {
                    UslugiId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(nullable: false),
                    Cena = table.Column<decimal>(nullable: false),
                    DataRozpo = table.Column<DateTime>(nullable: false),
                    DataZak = table.Column<DateTime>(nullable: false),
                    Produkty = table.Column<string>(nullable: true),
                    Uwagi = table.Column<string>(nullable: true),
                    KlienciId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uslugi", x => x.UslugiId);
                    table.ForeignKey(
                        name: "FK_Uslugi_Klienci_KlienciId",
                        column: x => x.KlienciId,
                        principalTable: "Klienci",
                        principalColumn: "KlienciId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Uslugi_KlienciId",
                table: "Uslugi",
                column: "KlienciId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Uslugi");

            migrationBuilder.DropTable(
                name: "Klienci");
        }
    }
}
