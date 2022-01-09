using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineStore.Migrations
{
    public partial class categoryLocalization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "NameUA");

            migrationBuilder.AddColumn<string>(
                name: "NameEN",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameRU",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameEN",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "NameRU",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "NameUA",
                table: "Categories",
                newName: "Name");
        }
    }
}
