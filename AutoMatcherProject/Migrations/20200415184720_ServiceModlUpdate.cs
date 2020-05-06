using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoMatcherProject1.Migrations
{
    public partial class ServiceModlUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceModel_UsersCredentialsModels_UsersCredentialsModelId",
                table: "ServiceModel");

            migrationBuilder.DropIndex(
                name: "IX_ServiceModel_UsersCredentialsModelId",
                table: "ServiceModel");

            migrationBuilder.DropColumn(
                name: "UsersCredentialsModelId",
                table: "ServiceModel");

            migrationBuilder.AddColumn<string>(
                name: "modelId",
                table: "ServiceModel",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceModel_modelId",
                table: "ServiceModel",
                column: "modelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceModel_UsersCredentialsModels_modelId",
                table: "ServiceModel",
                column: "modelId",
                principalTable: "UsersCredentialsModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceModel_UsersCredentialsModels_modelId",
                table: "ServiceModel");

            migrationBuilder.DropIndex(
                name: "IX_ServiceModel_modelId",
                table: "ServiceModel");

            migrationBuilder.DropColumn(
                name: "modelId",
                table: "ServiceModel");

            migrationBuilder.AddColumn<string>(
                name: "UsersCredentialsModelId",
                table: "ServiceModel",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceModel_UsersCredentialsModelId",
                table: "ServiceModel",
                column: "UsersCredentialsModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceModel_UsersCredentialsModels_UsersCredentialsModelId",
                table: "ServiceModel",
                column: "UsersCredentialsModelId",
                principalTable: "UsersCredentialsModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
