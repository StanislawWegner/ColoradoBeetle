using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ColoradoBeetle.Infrastructure.Migrations
{
    public partial class ChangedGroupShopListDeleteBehaviourToRestrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupShopLists_AspNetUsers_UserId",
                table: "GroupShopLists");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupShopLists_AspNetUsers_UserId",
                table: "GroupShopLists",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupShopLists_AspNetUsers_UserId",
                table: "GroupShopLists");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupShopLists_AspNetUsers_UserId",
                table: "GroupShopLists",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
