using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderSystem_DAL.Migrations
{
    public partial class finalmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_Email = table.Column<string>(nullable: true),
                    Customer_Password = table.Column<string>(nullable: true),
                    Customer_First_Name = table.Column<string>(nullable: true),
                    Customer_Last_Name = table.Column<string>(nullable: true),
                    Customer_Phone_Number = table.Column<string>(nullable: true),
                    Customer_Address_Line_1 = table.Column<string>(nullable: true),
                    Customer_City = table.Column<string>(nullable: true),
                    Customer_Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Name = table.Column<string>(nullable: true),
                    Product_Description = table.Column<string>(nullable: true),
                    Product_Price = table.Column<string>(nullable: true),
                    Product_Quantity = table.Column<string>(nullable: true),
                    Total_Product_Price = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Name = table.Column<string>(nullable: true),
                    Product_Category = table.Column<string>(nullable: true),
                    Product_Description = table.Column<string>(nullable: true),
                    Product_Price = table.Column<string>(nullable: true),
                    Product_Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_Order_Date = table.Column<DateTime>(nullable: false),
                    Order_Comments = table.Column<string>(nullable: true),
                    Customer_Name = table.Column<string>(nullable: true),
                    Customer_Phone = table.Column<string>(nullable: true),
                    Customer_Email = table.Column<string>(nullable: true),
                    Customer_Address = table.Column<string>(nullable: true),
                    Customer_Country = table.Column<string>(nullable: true),
                    Total = table.Column<string>(nullable: true),
                    orderproductId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_OrderProduct_orderproductId",
                        column: x => x.orderproductId,
                        principalTable: "OrderProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    CartId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Quantity = table.Column<string>(nullable: true),
                    Total_Product_Price = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_Cart_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ProductId",
                table: "Cart",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_orderproductId",
                table: "Order",
                column: "orderproductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "OrderProduct");
        }
    }
}
