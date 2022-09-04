using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderSystem_DAL.Migrations
{
    public partial class final2migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_OrderProduct_orderproductId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_orderproductId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "orderproductId",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "OrderProduct",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "OrderProduct",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_OrderId",
                table: "OrderProduct",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Order_OrderId",
                table: "OrderProduct",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Order_OrderId",
                table: "OrderProduct");

            migrationBuilder.DropIndex(
                name: "IX_OrderProduct_OrderId",
                table: "OrderProduct");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "OrderProduct");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "OrderProduct");

            migrationBuilder.AddColumn<int>(
                name: "orderproductId",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_orderproductId",
                table: "Order",
                column: "orderproductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_OrderProduct_orderproductId",
                table: "Order",
                column: "orderproductId",
                principalTable: "OrderProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
