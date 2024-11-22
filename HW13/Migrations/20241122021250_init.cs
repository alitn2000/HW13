using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HW13.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NationalCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    License = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", maxLength: 100, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    BorrowedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, "admin", "admin" },
                    { 2, "admin1", "admin1" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "License", "NationalCode", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, "ali", "tahmasebinia", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "1234567890", "123", "alitn2000" },
                    { 2, "reza", "rezaei", new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "1234567790", "123", "user1" },
                    { 3, "sara", "saraei", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "1114567890", "123", "user2" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "BorrowedDate", "Price", "Publisher", "Status", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "Tolstoy", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 120m, "A", 2, "AnnaKarenina", 1 },
                    { 2, "Tolstoy", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 140m, "B", 2, "War&Peace", 1 },
                    { 3, "Dostoevsky", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 200m, "C", 2, "TheBrothersOfKaramazov", 1 },
                    { 4, "Dostoevsky", new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 90m, "D", 2, "TheGambler", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_UserId",
                table: "Books",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
