using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ColoradoBeetle.Infrastructure.Migrations
{
    public partial class AddedPropertiesToProductIsCopiedAndIsChecked : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsChecked",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCopied",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsChecked",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsCopied",
                table: "Products");
        }
    }
}
