using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Books.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("9bea4a18-545c-424c-b75f-16ab31d301f2"), "Navid", "Golforoushan" },
                    { new Guid("21b8d121-51f4-46be-a27a-e2d2ba71b99a"), "Nima", "Golforoushan" },
                    { new Guid("3cb59583-746c-4c96-99fe-b09bcf85d2ab"), "Ali", "Jason" },
                    { new Guid("684e0159-26fb-4f39-a042-b62c372d2fb6"), "James", "Elroy" },
                    { new Guid("5aac79cf-d273-404d-85ed-96cfd8da9f49"), "Douglas", "Adams" },
                    { new Guid("1485fb96-39a5-4e89-a3ec-843dffa005bb"), "Stephan", "Fry" },
                    { new Guid("a2196927-4608-4641-8234-bff1341d846c"), "George", "RR Martin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Author");
        }
    }
}
