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
                    AdminType = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
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
                name: "Publications",
                columns: table => new
                {
                    DOI = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Vol = table.Column<int>(type: "integer", nullable: true),
                    No = table.Column<int>(type: "integer", nullable: true),
                    Pages = table.Column<string>(type: "text", nullable: true),
                    AuthorsNo = table.Column<int>(type: "integer", nullable: true),
                    Authors = table.Column<string>(type: "text", nullable: true),
                    JournalTitle = table.Column<string>(type: "text", nullable: true),
                    JournalISSN = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: false, defaultValue: "Waiting"),
                    UserPersonnelNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publications", x => x.DOI);
                    table.ForeignKey(
                        name: "FK_Publications_Users_UserPersonnelNumber",
                        column: x => x.UserPersonnelNumber,
                        principalTable: "Users",
                        principalColumn: "PersonnelNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PublicationsScopus",
                columns: table => new
                {
                    DOI = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicationsScopus", x => x.DOI);
                    table.ForeignKey(
                        name: "FK_PublicationsScopus_Publications_DOI",
                        column: x => x.DOI,
                        principalTable: "Publications",
                        principalColumn: "DOI",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PublicationsWebOfScience",
                columns: table => new
                {
                    DOI = table.Column<string>(type: "text", nullable: false),
                    WOSNumber = table.Column<string>(type: "text", nullable: false),
                    HasAbroadAuthor = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    IsAbroadAuthorTop400 = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    Top400UniversityName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicationsWebOfScience", x => x.DOI);
                    table.ForeignKey(
                        name: "FK_PublicationsWebOfScience_Publications_DOI",
                        column: x => x.DOI,
                        principalTable: "Publications",
                        principalColumn: "DOI",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Publications_UserPersonnelNumber",
                table: "Publications",
                column: "UserPersonnelNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PublicationsScopus");

            migrationBuilder.DropTable(
                name: "PublicationsWebOfScience");

            migrationBuilder.DropTable(
                name: "Publications");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
