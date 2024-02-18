using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace galaxypremiere.Persistence.Migrations
{
    public partial class AddPhotoComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersPhotoComments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
