using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ColoradoBeetle.Infrastructure.Migrations
{
    public partial class addedShoppingListReferenceToGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "ShoppingLists",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingLists_GroupId",
                table: "ShoppingLists",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingLists_Groups_GroupId",
                table: "ShoppingLists",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingLists_Groups_GroupId",
                table: "ShoppingLists");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingLists_GroupId",
                table: "ShoppingLists");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "ShoppingLists");
        }
    }
}
