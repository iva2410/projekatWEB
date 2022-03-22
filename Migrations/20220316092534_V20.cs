using Microsoft.EntityFrameworkCore.Migrations;

namespace webprojekat.Migrations
{
    public partial class V20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edukacije_Termini_TerminID",
                table: "Edukacije");

            migrationBuilder.DropForeignKey(
                name: "FK_Termini_Saloni_SalonID",
                table: "Termini");

            migrationBuilder.DropForeignKey(
                name: "FK_Tretmani_Saloni_SaloniID",
                table: "Tretmani");

            migrationBuilder.DropIndex(
                name: "IX_Termini_SalonID",
                table: "Termini");

            migrationBuilder.DropColumn(
                name: "SalonID",
                table: "Termini");

            migrationBuilder.RenameColumn(
                name: "SaloniID",
                table: "Tretmani",
                newName: "SalonID");

            migrationBuilder.RenameIndex(
                name: "IX_Tretmani_SaloniID",
                table: "Tretmani",
                newName: "IX_Tretmani_SalonID");

            migrationBuilder.RenameColumn(
                name: "TerminID",
                table: "Edukacije",
                newName: "salonID");

            migrationBuilder.RenameIndex(
                name: "IX_Edukacije_TerminID",
                table: "Edukacije",
                newName: "IX_Edukacije_salonID");

            migrationBuilder.CreateTable(
                name: "EdukacijaTermin",
                columns: table => new
                {
                    EdukacijaID = table.Column<int>(type: "int", nullable: false),
                    terminiID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EdukacijaTermin", x => new { x.EdukacijaID, x.terminiID });
                    table.ForeignKey(
                        name: "FK_EdukacijaTermin_Edukacije_EdukacijaID",
                        column: x => x.EdukacijaID,
                        principalTable: "Edukacije",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EdukacijaTermin_Termini_terminiID",
                        column: x => x.terminiID,
                        principalTable: "Termini",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EdukacijaTermin_terminiID",
                table: "EdukacijaTermin",
                column: "terminiID");

            migrationBuilder.AddForeignKey(
                name: "FK_Edukacije_Saloni_salonID",
                table: "Edukacije",
                column: "salonID",
                principalTable: "Saloni",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tretmani_Saloni_SalonID",
                table: "Tretmani",
                column: "SalonID",
                principalTable: "Saloni",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edukacije_Saloni_salonID",
                table: "Edukacije");

            migrationBuilder.DropForeignKey(
                name: "FK_Tretmani_Saloni_SalonID",
                table: "Tretmani");

            migrationBuilder.DropTable(
                name: "EdukacijaTermin");

            migrationBuilder.RenameColumn(
                name: "SalonID",
                table: "Tretmani",
                newName: "SaloniID");

            migrationBuilder.RenameIndex(
                name: "IX_Tretmani_SalonID",
                table: "Tretmani",
                newName: "IX_Tretmani_SaloniID");

            migrationBuilder.RenameColumn(
                name: "salonID",
                table: "Edukacije",
                newName: "TerminID");

            migrationBuilder.RenameIndex(
                name: "IX_Edukacije_salonID",
                table: "Edukacije",
                newName: "IX_Edukacije_TerminID");

            migrationBuilder.AddColumn<int>(
                name: "SalonID",
                table: "Termini",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Termini_SalonID",
                table: "Termini",
                column: "SalonID");

            migrationBuilder.AddForeignKey(
                name: "FK_Edukacije_Termini_TerminID",
                table: "Edukacije",
                column: "TerminID",
                principalTable: "Termini",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Termini_Saloni_SalonID",
                table: "Termini",
                column: "SalonID",
                principalTable: "Saloni",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tretmani_Saloni_SaloniID",
                table: "Tretmani",
                column: "SaloniID",
                principalTable: "Saloni",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
