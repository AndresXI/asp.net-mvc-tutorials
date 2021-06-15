using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace L06HandsOn.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aliens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Arms = table.Column<int>(type: "INTEGER", nullable: false),
                    Head = table.Column<int>(type: "INTEGER", nullable: false),
                    Legs = table.Column<int>(type: "INTEGER", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PlanetOfOrigin = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aliens", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aliens");
        }
    }
}
