using Microsoft.EntityFrameworkCore.Migrations;

namespace webprojekat.Migrations
{
    public partial class v55 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SalonidID",
                table: "Tretmani",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tretmani_SalonidID",
                table: "Tretmani",
                column: "SalonidID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tretmani_Saloni_SalonidID",
                table: "Tretmani",
                column: "SalonidID",
                principalTable: "Saloni",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tretmani_Saloni_SalonidID",
                table: "Tretmani");

            migrationBuilder.DropIndex(
                name: "IX_Tretmani_SalonidID",
                table: "Tretmani");

            migrationBuilder.DropColumn(
                name: "SalonidID",
                table: "Tretmani");
        }
    }
}
