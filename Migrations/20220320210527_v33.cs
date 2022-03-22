using Microsoft.EntityFrameworkCore.Migrations;

namespace webprojekat.Migrations
{
    public partial class v33 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edukacije_Radnici_RadnikID",
                table: "Edukacije");

            migrationBuilder.DropForeignKey(
                name: "FK_Tretmani_Saloni_salonID",
                table: "Tretmani");

            migrationBuilder.DropIndex(
                name: "IX_Tretmani_salonID",
                table: "Tretmani");

            migrationBuilder.DropIndex(
                name: "IX_Edukacije_RadnikID",
                table: "Edukacije");

            migrationBuilder.DropColumn(
                name: "salonID",
                table: "Tretmani");

            migrationBuilder.DropColumn(
                name: "RadnikID",
                table: "Edukacije");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "salonID",
                table: "Tretmani",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RadnikID",
                table: "Edukacije",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tretmani_salonID",
                table: "Tretmani",
                column: "salonID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Tretmani_Saloni_salonID",
                table: "Tretmani",
                column: "salonID",
                principalTable: "Saloni",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
