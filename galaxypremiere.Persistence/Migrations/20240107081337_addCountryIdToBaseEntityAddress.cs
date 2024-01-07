using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace galaxypremiere.Persistence.Migrations
{
    public partial class addCountryIdToBaseEntityAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
    name: "CountryId",
    table: "UsersCompanies",
    type: "int",
    nullable: false,
    defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "UsersAddress",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
