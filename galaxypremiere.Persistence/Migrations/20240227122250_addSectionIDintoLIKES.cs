using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace galaxypremiere.Persistence.Migrations
{
    public partial class addSectionIDintoLIKES : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SectionId",
                table: "Likes",
                type: "uniqueidentifier",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
