using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderSystem_DAL.Migrations
{
    public partial class lastone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Product_Image",
                table: "OrderProduct",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Product_Image",
                table: "OrderProduct");
        }
    }
}
