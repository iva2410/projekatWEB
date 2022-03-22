using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webprojekat.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Saloni",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saloni", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Termini",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vreme = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Termini", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Radnici",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GodineRada = table.Column<int>(type: "int", nullable: false),
                    Plata = table.Column<int>(type: "int", nullable: false),
                    SalonID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radnici", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Radnici_Saloni_SalonID",
                        column: x => x.SalonID,
                        principalTable: "Saloni",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tretmani",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cena = table.Column<int>(type: "int", nullable: false),
                    VremeTrajanja = table.Column<int>(type: "int", nullable: false),
                    SaloniID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tretmani", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tretmani_Saloni_SaloniID",
                        column: x => x.SaloniID,
                        principalTable: "Saloni",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "IX_Radnici_SalonID",
                table: "Radnici",
                column: "SalonID");

            migrationBuilder.CreateIndex(
                name: "IX_TerminSaloni_SalonID",
                table: "TerminSaloni",
                column: "SalonID");

            migrationBuilder.CreateIndex(
                name: "IX_TerminSaloni_TerminID",
                table: "TerminSaloni",
                column: "TerminID");

            migrationBuilder.CreateIndex(
                name: "IX_Tretmani_SaloniID",
                table: "Tretmani",
                column: "SaloniID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Radnici");

            migrationBuilder.DropTable(
                name: "TerminSaloni");

            migrationBuilder.DropTable(
                name: "Tretmani");

            migrationBuilder.DropTable(
                name: "Termini");

            migrationBuilder.DropTable(
                name: "Saloni");
        }
    }
}
