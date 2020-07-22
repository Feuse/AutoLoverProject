using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoMatcherProject1.Migrations
{
    public partial class addingAttributeUserServiceId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ServiceUserId",
                table: "ServiceModel",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceUserId",
                table: "ServiceModel");
        }
    }
}
