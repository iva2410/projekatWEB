using Microsoft.EntityFrameworkCore.Migrations;

namespace webprojekat.Migrations
{
    public partial class V22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EdukacijaTermin");

            migrationBuilder.CreateTable(
                name: "EdukacijaTermini",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EdukacijaID = table.Column<int>(type: "int", nullable: true),
                    TerminID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EdukacijaTermini", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EdukacijaTermini_Edukacije_EdukacijaID",
                        column: x => x.EdukacijaID,
                        principalTable: "Edukacije",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EdukacijaTermini_Termini_TerminID",
                        column: x => x.TerminID,
                        principalTable: "Termini",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EdukacijaTermini_EdukacijaID",
                table: "EdukacijaTermini",
                column: "EdukacijaID");

            migrationBuilder.CreateIndex(
                name: "IX_EdukacijaTermini_TerminID",
                table: "EdukacijaTermini",
                column: "TerminID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EdukacijaTermini");

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
        }
    }
}
