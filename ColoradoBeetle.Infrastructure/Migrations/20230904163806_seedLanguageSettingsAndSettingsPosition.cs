using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ColoradoBeetle.Infrastructure.Migrations
{
    public partial class seedLanguageSettingsAndSettingsPosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Key", "Name" },
                values: new object[,]
                {
                    { 1, "pl", "Polski" },
                    { 2, "en", "Angielski" }
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "Description", "Order" },
                values: new object[,]
                {
                    { 1, "E-mail", 2 },
                    { 2, "Ogólne", 1 }
                });

            migrationBuilder.InsertData(
                table: "SettingsPositions",
                columns: new[] { "Id", "Description", "Key", "Order", "SettingsId", "Type", "Value" },
                values: new object[,]
                {
                    { 1, "Host", "HostSmtp", 1, 1, 0, "smtp.gmail.com" },
                    { 2, "Port", "Port", 2, 1, 2, "587" },
                    { 3, "Adres e-mail nadawcy", "SenderEmail", 3, 1, 0, "" },
                    { 4, "Hasło", "SenderEmailPassword", 4, 1, 4, "" },
                    { 5, "Nazwa nadawcy", "SenderName", 5, 1, 0, "Stanisław Wegner" },
                    { 6, "Login nadawcy", "SenderLogin", 6, 1, 0, "" },
                    { 7, "Czy wyświetlać banner na stronie głównej?", "BannerVisible", 1, 2, 1, "True" },
                    { 8, "Folor footera strona głównej", "FooterColor", 2, 2, 5, "#dc3545" },
                    { 9, "Główny adres e-mail administratora", "AdminEmail", 3, 2, 0, "s.wegner@onet.eu" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SettingsPositions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SettingsPositions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SettingsPositions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SettingsPositions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SettingsPositions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SettingsPositions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SettingsPositions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SettingsPositions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SettingsPositions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
