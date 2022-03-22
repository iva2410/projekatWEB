using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webprojekat.Migrations
{
    public partial class V25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vreme",
                table: "Termini");

            migrationBuilder.AddColumn<string>(
                name: "Tip",
                table: "Saloni",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RadnikID",
                table: "Edukacije",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Vreme",
                table: "EdukacijaTermini",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Edukacije_RadnikID",
                table: "Edukacije",
                column: "RadnikID");

            migrationBuilder.AddForeignKey(
                name: "FK_Edukacije_Radnici_RadnikID",
                table: "Edukacije",
                column: "RadnikID",
                principalTable: "Radnici",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edukacije_Radnici_RadnikID",
                table: "Edukacije");

            migrationBuilder.DropIndex(
                name: "IX_Edukacije_RadnikID",
                table: "Edukacije");

            migrationBuilder.DropColumn(
                name: "Tip",
                table: "Saloni");

            migrationBuilder.DropColumn(
                name: "RadnikID",
                table: "Edukacije");

            migrationBuilder.DropColumn(
                name: "Vreme",
                table: "EdukacijaTermini");

            migrationBuilder.AddColumn<DateTime>(
                name: "Vreme",
                table: "Termini",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
