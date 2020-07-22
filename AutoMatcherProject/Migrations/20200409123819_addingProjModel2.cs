using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoMatcherProject1.Migrations
{
    public partial class addingProjModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CookieModel",
                table: "CookieModel");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "CookieModel",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SessionId",
                table: "CookieModel",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CookieModel",
                table: "CookieModel",
                column: "UserId");

            migrationBuilder.CreateTable(
                name: "ProjectionModel",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    Projections = table.Column<long>(nullable: false),
                    UsersIds = table.Column<string>(nullable: true),
                    SessionId = table.Column<string>(nullable: true),
                    time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectionModel", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectionModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CookieModel",
                table: "CookieModel");

            migrationBuilder.AlterColumn<string>(
                name: "SessionId",
                table: "CookieModel",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "CookieModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CookieModel",
                table: "CookieModel",
                column: "SessionId");
        }
    }
}
