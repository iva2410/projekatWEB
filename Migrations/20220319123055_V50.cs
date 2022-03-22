using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webprojekat.Migrations
{
    public partial class V50 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tretmani_Saloni_SalonID",
                table: "Tretmani");

            migrationBuilder.DropIndex(
                name: "IX_Tretmani_SalonID",
                table: "Tretmani");

            migrationBuilder.DropColumn(
                name: "Cena",
                table: "Tretmani");

            migrationBuilder.DropColumn(
                name: "SalonID",
                table: "Tretmani");

            migrationBuilder.DropColumn(
                name: "Tip",
                table: "Saloni");

            migrationBuilder.DropColumn(
                name: "Vreme",
                table: "Edukacije");

            migrationBuilder.CreateTable(
                name: "SaloniTretmani",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalonID = table.Column<int>(type: "int", nullable: true),
                    TretmanID = table.Column<int>(type: "int", nullable: true),
                    Cena = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaloniTretmani", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SaloniTretmani_Saloni_SalonID",
                        column: x => x.SalonID,
                        principalTable: "Saloni",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaloniTretmani_Tretmani_TretmanID",
                        column: x => x.TretmanID,
                        principalTable: "Tretmani",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SaloniTretmani_SalonID",
                table: "SaloniTretmani",
                column: "SalonID");

            migrationBuilder.CreateIndex(
                name: "IX_SaloniTretmani_TretmanID",
                table: "SaloniTretmani",
                column: "TretmanID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaloniTretmani");

            migrationBuilder.AddColumn<int>(
                name: "Cena",
                table: "Tretmani",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SalonID",
                table: "Tretmani",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tip",
                table: "Saloni",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Vreme",
                table: "Edukacije",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Tretmani_SalonID",
                table: "Tretmani",
                column: "SalonID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tretmani_Saloni_SalonID",
                table: "Tretmani",
                column: "SalonID",
                principalTable: "Saloni",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
