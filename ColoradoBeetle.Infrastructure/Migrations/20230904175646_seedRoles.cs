using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ColoradoBeetle.Infrastructure.Migrations
{
    public partial class seedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "DA0D03EA-3DB5-48E1-A88F-7ED520A9289A", "D7D71FD0-C6D1-455C-86E8-ED861B169F46", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "F5502C99-1E28-4025-AB7B-6D99CE8EE4A3", "85AA5510-5124-4B37-B63A-382656367B02", "Klient", "KLIENT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "DA0D03EA-3DB5-48E1-A88F-7ED520A9289A");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "F5502C99-1E28-4025-AB7B-6D99CE8EE4A3");
        }
    }
}
