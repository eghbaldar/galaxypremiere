using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace galaxypremiere.Persistence.Migrations
{
    public partial class removeCountryIdUserInformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "UsersInformation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "UsersInformation",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
