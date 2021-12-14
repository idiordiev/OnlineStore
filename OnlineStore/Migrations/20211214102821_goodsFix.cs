using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineStore.Migrations
{
    public partial class goodsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goods_Receipts_ReceiptId",
                table: "Goods");

            migrationBuilder.DropIndex(
                name: "IX_Goods_ReceiptId",
                table: "Goods");

            migrationBuilder.DropColumn(
                name: "ReceiptId",
                table: "Goods");

            migrationBuilder.CreateTable(
                name: "GoodsReceipt",
                columns: table => new
                {
                    GoodsListId = table.Column<int>(type: "int", nullable: false),
                    ReceiptsListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsReceipt", x => new { x.GoodsListId, x.ReceiptsListId });
                    table.ForeignKey(
                        name: "FK_GoodsReceipt_Goods_GoodsListId",
                        column: x => x.GoodsListId,
                        principalTable: "Goods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoodsReceipt_Receipts_ReceiptsListId",
                        column: x => x.ReceiptsListId,
                        principalTable: "Receipts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceipt_ReceiptsListId",
                table: "GoodsReceipt",
                column: "ReceiptsListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoodsReceipt");

            migrationBuilder.AddColumn<int>(
                name: "ReceiptId",
                table: "Goods",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Goods_ReceiptId",
                table: "Goods",
                column: "ReceiptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Goods_Receipts_ReceiptId",
                table: "Goods",
                column: "ReceiptId",
                principalTable: "Receipts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
