using Microsoft.EntityFrameworkCore.Migrations;

namespace webprojekat.Migrations
{
    public partial class V11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TerminSaloni");

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
                name: "FK_Termini_Saloni_SalonID",
                table: "Termini",
                column: "SalonID",
                principalTable: "Saloni",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Termini_Saloni_SalonID",
                table: "Termini");

            migrationBuilder.DropIndex(
                name: "IX_Termini_SalonID",
                table: "Termini");

            migrationBuilder.DropColumn(
                name: "SalonID",
                table: "Termini");

            migrationBuilder.CreateTable(
                name: "TerminSaloni",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalonID = table.Column<int>(type: "int", nullable: true),
                    TerminID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerminSaloni", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TerminSaloni_Saloni_SalonID",
                        column: x => x.SalonID,
                        principalTable: "Saloni",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TerminSaloni_Termini_TerminID",
                        column: x => x.TerminID,
                        principalTable: "Termini",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TerminSaloni_SalonID",
                table: "TerminSaloni",
                column: "SalonID");

            migrationBuilder.CreateIndex(
                name: "IX_TerminSaloni_TerminID",
                table: "TerminSaloni",
                column: "TerminID");
        }
    }
}
