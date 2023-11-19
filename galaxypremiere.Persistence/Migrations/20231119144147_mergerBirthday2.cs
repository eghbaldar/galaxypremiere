using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace galaxypremiere.Persistence.Migrations
{
    public partial class mergerBirthday2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthMonth",
                table: "UsersInformation");

            migrationBuilder.DropColumn(
                name: "BirthYear",
                table: "UsersInformation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BirthMonth",
                table: "UsersInformation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BirthYear",
                table: "UsersInformation",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
