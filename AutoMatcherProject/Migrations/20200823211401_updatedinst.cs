using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoMatcherProject1.Migrations
{
    public partial class updatedinst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_InstagramMediaModel",
                table: "InstagramMediaModel");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "InstagramMediaModel",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "InstagramMediaModel",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InstagramMediaModel",
                table: "InstagramMediaModel",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_InstagramMediaModel",
                table: "InstagramMediaModel");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "InstagramMediaModel");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "InstagramMediaModel",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_InstagramMediaModel",
                table: "InstagramMediaModel",
                column: "Id");
        }
    }
}
