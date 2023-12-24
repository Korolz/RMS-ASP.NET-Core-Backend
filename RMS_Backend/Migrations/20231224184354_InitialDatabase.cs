using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RMS_Backend.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    PersonnelNumber = table.Column<string>(type: "text", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    IsAdmin = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    Faculty = table.Column<string>(type: "text", nullable: true),
                    Department = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.PersonnelNumber);
                });

            migrationBuilder.CreateTable(
                name: "PublicationsScopus",
                columns: table => new
                {
                    DOI = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Pages = table.Column<int>(type: "integer", nullable: true),
                    AuthorsNo = table.Column<int>(type: "integer", nullable: true),
                    Authors = table.Column<string>(type: "text", nullable: true),
                    PersonnelNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicationsScopus", x => x.DOI);
                    table.ForeignKey(
                        name: "FK_PublicationsScopus_Users_PersonnelNumber",
                        column: x => x.PersonnelNumber,
                        principalTable: "Users",
                        principalColumn: "PersonnelNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PublicationsWebOfScience",
                columns: table => new
                {
                    DOI = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Pages = table.Column<int>(type: "integer", nullable: true),
                    AuthorsNo = table.Column<int>(type: "integer", nullable: true),
                    Authors = table.Column<string>(type: "text", nullable: true),
                    PersonnelNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicationsWebOfScience", x => x.DOI);
                    table.ForeignKey(
                        name: "FK_PublicationsWebOfScience_Users_PersonnelNumber",
                        column: x => x.PersonnelNumber,
                        principalTable: "Users",
                        principalColumn: "PersonnelNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PublicationsScopus_PersonnelNumber",
                table: "PublicationsScopus",
                column: "PersonnelNumber");

            migrationBuilder.CreateIndex(
                name: "IX_PublicationsWebOfScience_PersonnelNumber",
                table: "PublicationsWebOfScience",
                column: "PersonnelNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PublicationsScopus");

            migrationBuilder.DropTable(
                name: "PublicationsWebOfScience");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
