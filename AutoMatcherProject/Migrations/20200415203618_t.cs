using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoMatcherProject1.Migrations
{
    public partial class t : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceModel",
                table: "ServiceModel");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ServiceModel",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceModel",
                table: "ServiceModel",
                column: "Id");
        }
    }
}
