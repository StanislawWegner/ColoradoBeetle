using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ColoradoBeetle.Infrastructure.Migrations
{
    public partial class AddedReferenceGroupProductToGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "GroupProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GroupProducts_GroupId",
                table: "GroupProducts",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupProducts_Groups_GroupId",
                table: "GroupProducts",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupProducts_Groups_GroupId",
                table: "GroupProducts");

            migrationBuilder.DropIndex(
                name: "IX_GroupProducts_GroupId",
                table: "GroupProducts");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "GroupProducts");
        }
    }
}
