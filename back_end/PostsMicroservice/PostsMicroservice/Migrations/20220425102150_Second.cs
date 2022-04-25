using Microsoft.EntityFrameworkCore.Migrations;

namespace PostsMicroservice.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AmountDrank",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DrinkType",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountDrank",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "DrinkType",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Post");
        }
    }
}
