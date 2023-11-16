using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace galaxypremiere.Persistence.Migrations
{
    public partial class ModifyLanguagesConfiguration30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "LanguageCountryCode", "NameEnglish", "NameNative" },
                values: new object[] { 1, null, "Not Specified", "Not Specified" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "LanguageCountryCode", "NameEnglish", "NameNative" },
                values: new object[] { 2, "aa-DJ", "Afar (Djibouti)", "Afar (Djibouti)" });
        }
    }
}
