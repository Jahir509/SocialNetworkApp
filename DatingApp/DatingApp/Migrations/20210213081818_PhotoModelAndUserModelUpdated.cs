using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatingApp.Migrations
{
    public partial class PhotoModelAndUserModelUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "Username");

            migrationBuilder.AddColumn<string>(
                name: "Area",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HouseNo",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Interests",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Introduction",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KnownAs",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastActive",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LookingFor",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoadNo",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Zip",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    IsMain = table.Column<bool>(nullable: false),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_UserId",
                table: "Photos",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropColumn(
                name: "Area",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "HouseNo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Interests",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Introduction",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "KnownAs",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastActive",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LookingFor",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoadNo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Zip",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "UserName");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
