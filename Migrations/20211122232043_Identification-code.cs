using Microsoft.EntityFrameworkCore.Migrations;

namespace Books.BooksApi.Migrations
{
    public partial class Identificationcode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryCode",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorCode",
                table: "Author",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryCode",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "AuthorCode",
                table: "Author");
        }
    }
}
