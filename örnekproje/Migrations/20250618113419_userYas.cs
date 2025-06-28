using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace örnekproje.Migrations
{
    public partial class userYas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Yas",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Yas",
                table: "Users");
        }
    }
}
