using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoMatcherProject1.Migrations
{
    public partial class updatingServiceMOdel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceModel",
                table: "ServiceModel");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "ServiceModel",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceModel",
                table: "ServiceModel",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceModel",
                table: "ServiceModel");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ServiceModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceModel",
                table: "ServiceModel",
                column: "Service");
        }
    }
}
