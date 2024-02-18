using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace galaxypremiere.Persistence.Migrations
{
    public partial class AddPhotoComment4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersPhotoComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Parent = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsersId = table.Column<long>(type: "bigint", nullable: false),
                    UsersPhotosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersPhotoComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersPhotoComments_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersPhotoComments_UsersPhotos_UsersPhotosId",
                        column: x => x.UsersPhotosId,
                        principalTable: "UsersPhotos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersPhotoComments_UsersId",
                table: "UsersPhotoComments",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersPhotoComments_UsersPhotosId",
                table: "UsersPhotoComments",
                column: "UsersPhotosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersPhotoComments");
        }
    }
}
