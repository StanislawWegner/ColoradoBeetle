using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ColoradoBeetle.Infrastructure.Persistence.Migrations
{
    public partial class AddShoppingLists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ShoppingLists",
                columns: new[] { "Id", "CreatedDate", "Name", "UserId" },
                values: new object[] { 1, new DateTime(2023, 6, 28, 16, 0, 0, 0, DateTimeKind.Unspecified), "Lista zakupów nr: 1", "f9967bf4-cc0e-4dea-a1f2-97600e64adc6" });

            migrationBuilder.InsertData(
                table: "ShoppingLists",
                columns: new[] { "Id", "CreatedDate", "Name", "UserId" },
                values: new object[] { 2, new DateTime(2023, 6, 28, 16, 0, 5, 0, DateTimeKind.Unspecified), "Lista zakupów nr: 2", "f9967bf4-cc0e-4dea-a1f2-97600e64adc6" });

            migrationBuilder.InsertData(
                table: "ShoppingLists",
                columns: new[] { "Id", "CreatedDate", "Name", "UserId" },
                values: new object[] { 3, new DateTime(2023, 6, 28, 16, 0, 10, 0, DateTimeKind.Unspecified), "Lista zakupów nr: 3", "f9967bf4-cc0e-4dea-a1f2-97600e64adc6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ShoppingLists",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShoppingLists",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ShoppingLists",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
