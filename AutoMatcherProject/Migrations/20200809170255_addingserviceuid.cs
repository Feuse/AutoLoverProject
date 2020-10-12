using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoMatcherProject1.Migrations
{
    public partial class addingserviceuid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceUserId",
                table: "ServiceModel");

            migrationBuilder.AddColumn<string>(
                name: "ServiceUserId",
                table: "ServiceCredentialsModel",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceUserId",
                table: "ServiceCredentialsModel");

            migrationBuilder.AddColumn<string>(
                name: "ServiceUserId",
                table: "ServiceModel",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
