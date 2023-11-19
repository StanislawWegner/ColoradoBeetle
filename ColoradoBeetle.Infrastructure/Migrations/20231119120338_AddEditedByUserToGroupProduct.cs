using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ColoradoBeetle.Infrastructure.Migrations
{
    public partial class AddEditedByUserToGroupProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EditedByUserId",
                table: "GroupProducts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupProducts_EditedByUserId",
                table: "GroupProducts",
                column: "EditedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupProducts_AspNetUsers_EditedByUserId",
                table: "GroupProducts",
                column: "EditedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupProducts_AspNetUsers_EditedByUserId",
                table: "GroupProducts");

            migrationBuilder.DropIndex(
                name: "IX_GroupProducts_EditedByUserId",
                table: "GroupProducts");

            migrationBuilder.DropColumn(
                name: "EditedByUserId",
                table: "GroupProducts");
        }
    }
}
