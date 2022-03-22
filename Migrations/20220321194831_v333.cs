using Microsoft.EntityFrameworkCore.Migrations;

namespace webprojekat.Migrations
{
    public partial class v333 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RadnikID",
                table: "Edukacije",
                type: "int",
                nullable: true);

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
                name: "RadnikID",
                table: "Edukacije");
        }
    }
}
