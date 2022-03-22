using Microsoft.EntityFrameworkCore.Migrations;

namespace webprojekat.Migrations
{
    public partial class v54 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "salonID",
                table: "Tretmani",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tretmani_salonID",
                table: "Tretmani",
                column: "salonID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tretmani_Saloni_salonID",
                table: "Tretmani",
                column: "salonID",
                principalTable: "Saloni",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tretmani_Saloni_salonID",
                table: "Tretmani");

            migrationBuilder.DropIndex(
                name: "IX_Tretmani_salonID",
                table: "Tretmani");

            migrationBuilder.DropColumn(
                name: "salonID",
                table: "Tretmani");
        }
    }
}
