using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryReact.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    AdminID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AdminPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminFullName = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admins", x => x.AdminID);
                });

            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    AuthorID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.AuthorID);
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    BookID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BookName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublisherID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BooKLanguage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookCost = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.BookID);
                });

            migrationBuilder.CreateTable(
                name: "issueBooks",
                columns: table => new
                {
                    IssueBookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookIssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookDueDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_issueBooks", x => x.IssueBookId);
                });

            migrationBuilder.CreateTable(
                name: "members",
                columns: table => new
                {
                    MemberID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MemberFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemberDOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MemberContactNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemberEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemberFullAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemberPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_members", x => x.MemberID);
                });

            migrationBuilder.CreateTable(
                name: "publishers",
                columns: table => new
                {
                    PublisherID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PublisherName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_publishers", x => x.PublisherID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropTable(
                name: "authors");

            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "issueBooks");

            migrationBuilder.DropTable(
                name: "members");

            migrationBuilder.DropTable(
                name: "publishers");
        }
    }
}
