using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ColoradoBeetle.Infrastructure.Migrations
{
    public partial class AddedGroupShopListAndGroupProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupShopLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupShopLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupShopLists_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GroupShopLists_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Volume = table.Column<int>(type: "int", nullable: true),
                    VolumeUnit = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: true),
                    WeightUnit = table.Column<int>(type: "int", nullable: true),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false),
                    IsCopied = table.Column<bool>(type: "bit", nullable: false),
                    OnStock = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    GroupShopListId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupProducts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GroupProducts_GroupShopLists_GroupShopListId",
                        column: x => x.GroupShopListId,
                        principalTable: "GroupShopLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupProducts_GroupShopListId",
                table: "GroupProducts",
                column: "GroupShopListId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupProducts_UserId",
                table: "GroupProducts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupShopLists_GroupId",
                table: "GroupShopLists",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupShopLists_UserId",
                table: "GroupShopLists",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupProducts");

            migrationBuilder.DropTable(
                name: "GroupShopLists");
        }
    }
}
