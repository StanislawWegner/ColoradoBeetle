using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ColoradoBeetle.Infrastructure.Migrations
{
    public partial class AddEditByUserToGroupShopList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EditedByUserId",
                table: "GroupShopLists",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupShopLists_EditedByUserId",
                table: "GroupShopLists",
                column: "EditedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupShopLists_AspNetUsers_EditedByUserId",
                table: "GroupShopLists",
                column: "EditedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupShopLists_AspNetUsers_EditedByUserId",
                table: "GroupShopLists");

            migrationBuilder.DropIndex(
                name: "IX_GroupShopLists_EditedByUserId",
                table: "GroupShopLists");

            migrationBuilder.DropColumn(
                name: "EditedByUserId",
                table: "GroupShopLists");
        }
    }
}
