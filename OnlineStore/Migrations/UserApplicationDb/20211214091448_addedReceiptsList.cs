using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineStore.Migrations.UserApplicationDb
{
    public partial class addedReceiptsList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.CreateTable(
            //     name: "Category",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Category", x => x.Id);
            //     });
            //
            // migrationBuilder.CreateTable(
            //     name: "Receipt",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
            //         Summa = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //         Date = table.Column<DateTime>(type: "datetime2", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Receipt", x => x.Id);
            //         table.ForeignKey(
            //             name: "FK_Receipt_AspNetUsers_UserId",
            //             column: x => x.UserId,
            //             principalTable: "AspNetUsers",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Restrict);
            //     });
            //
            // migrationBuilder.CreateTable(
            //     name: "Goods",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //         NameUA = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //         NameRU = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //         NameEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //         DescriptionShortUA = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         DescriptionShortRU = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         DescriptionShortEN = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         DescriptionFullUA = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         DescriptionFullRU = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         DescriptionFullEN = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         ImageLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         CategoryId = table.Column<int>(type: "int", nullable: false),
            //         DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
            //         ReceiptId = table.Column<int>(type: "int", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Goods", x => x.Id);
            //         table.ForeignKey(
            //             name: "FK_Goods_Category_CategoryId",
            //             column: x => x.CategoryId,
            //             principalTable: "Category",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Cascade);
            //         table.ForeignKey(
            //             name: "FK_Goods_Receipt_ReceiptId",
            //             column: x => x.ReceiptId,
            //             principalTable: "Receipt",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Restrict);
            //     });
            //
            // migrationBuilder.CreateTable(
            //     name: "DiscountedGoods",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         GoodsId = table.Column<int>(type: "int", nullable: false),
            //         NewPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //         DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
            //         DateTo = table.Column<DateTime>(type: "datetime2", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_DiscountedGoods", x => x.Id);
            //         table.ForeignKey(
            //             name: "FK_DiscountedGoods_Goods_GoodsId",
            //             column: x => x.GoodsId,
            //             principalTable: "Goods",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Cascade);
            //     });
            //
            // migrationBuilder.CreateIndex(
            //     name: "IX_DiscountedGoods_GoodsId",
            //     table: "DiscountedGoods",
            //     column: "GoodsId",
            //     unique: true);
            //
            // migrationBuilder.CreateIndex(
            //     name: "IX_Goods_CategoryId",
            //     table: "Goods",
            //     column: "CategoryId");
            //
            // migrationBuilder.CreateIndex(
            //     name: "IX_Goods_ReceiptId",
            //     table: "Goods",
            //     column: "ReceiptId");
            //
            // migrationBuilder.CreateIndex(
            //     name: "IX_Receipt_UserId",
            //     table: "Receipt",
            //     column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiscountedGoods");

            migrationBuilder.DropTable(
                name: "Goods");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Receipt");
        }
    }
}
