using Microsoft.EntityFrameworkCore.Migrations;

namespace Fisher.Bookstore.Migrations
{
    public partial class bookprice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Books",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "Books",
                type: "text",
                nullable: true,
                oldClrType: typeof(double));
        }
    }
}
