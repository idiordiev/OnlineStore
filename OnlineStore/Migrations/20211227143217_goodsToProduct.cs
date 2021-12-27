using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineStore.Migrations
{
    public partial class goodsToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoodsReceipt");

            migrationBuilder.DropTable(
                name: "Goods");

            migrationBuilder.CreateTable(
                name: "Products",
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
                    DescriptionFullEN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductReceipt",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    ReceiptsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReceipt", x => new { x.ProductsId, x.ReceiptsId });
                    table.ForeignKey(
                        name: "FK_ProductReceipt_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductReceipt_Receipts_ReceiptsId",
                        column: x => x.ReceiptsId,
                        principalTable: "Receipts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductReceipt_ReceiptsId",
                table: "ProductReceipt",
                column: "ReceiptsId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductReceipt");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.CreateTable(
                name: "Goods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DescriptionFullEN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionFullRU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionFullUA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionShortEN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionShortRU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionShortUA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameRU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameUA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Goods_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GoodsReceipt",
                columns: table => new
                {
                    GoodsListId = table.Column<int>(type: "int", nullable: false),
                    ReceiptsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsReceipt", x => new { x.GoodsListId, x.ReceiptsId });
                    table.ForeignKey(
                        name: "FK_GoodsReceipt_Goods_GoodsListId",
                        column: x => x.GoodsListId,
                        principalTable: "Goods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoodsReceipt_Receipts_ReceiptsId",
                        column: x => x.ReceiptsId,
                        principalTable: "Receipts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Goods_CategoryId",
                table: "Goods",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceipt_ReceiptsId",
                table: "GoodsReceipt",
                column: "ReceiptsId");
        }
    }
}
