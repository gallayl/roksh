using Microsoft.EntityFrameworkCore.Migrations;

namespace roksh.Migrations
{
    public partial class ItemUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ItemUrl",
                table: "Items",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemUrl",
                table: "Items");
        }
    }
}
