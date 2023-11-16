using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace galaxypremiere.Persistence.Migrations
{
    public partial class ModifyLanguagesConfiguration10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Languages",
                newName: "NameEnglish");

            migrationBuilder.AddColumn<string>(
                name: "NameNative",
                table: "Languages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "LanguageCountryCode", "NameEnglish", "NameNative" },
                values: new object[] { 1, null, "Not Specified", "Not Specified" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "NameNative",
                table: "Languages");

            migrationBuilder.RenameColumn(
                name: "NameEnglish",
                table: "Languages",
                newName: "Name");
        }
    }
}
