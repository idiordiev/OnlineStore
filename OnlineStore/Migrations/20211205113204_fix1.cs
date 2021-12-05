using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineStore.Migrations
{
    public partial class fix1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Goods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NameUA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameRU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionShortUA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionShortRU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionShortEN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionFullUA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionFullRU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionFullEN = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goods", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Goods");
        }
    }
}
