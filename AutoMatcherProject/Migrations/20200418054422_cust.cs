using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoMatcherProject1.Migrations
{
    public partial class cust : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceModel_UsersCredentialsModels_modelId",
                table: "ServiceModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersCredentialsModels",
                table: "UsersCredentialsModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceModel",
                table: "ServiceModel");

            migrationBuilder.DropIndex(
                name: "IX_ServiceModel_modelId",
                table: "ServiceModel");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UsersCredentialsModels");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ServiceModel");

            migrationBuilder.DropColumn(
                name: "modelId",
                table: "ServiceModel");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UsersCredentialsModels",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ServiceId",
                table: "ServiceModel",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsersCredentialsModelUserId",
                table: "ServiceModel",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersCredentialsModels",
                table: "UsersCredentialsModels",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceModel",
                table: "ServiceModel",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceModel_UsersCredentialsModelUserId",
                table: "ServiceModel",
                column: "UsersCredentialsModelUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceModel_UsersCredentialsModels_UsersCredentialsModelUserId",
                table: "ServiceModel",
                column: "UsersCredentialsModelUserId",
                principalTable: "UsersCredentialsModels",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceModel_UsersCredentialsModels_UsersCredentialsModelUserId",
                table: "ServiceModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersCredentialsModels",
                table: "UsersCredentialsModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceModel",
                table: "ServiceModel");

            migrationBuilder.DropIndex(
                name: "IX_ServiceModel_UsersCredentialsModelUserId",
                table: "ServiceModel");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UsersCredentialsModels");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "ServiceModel");

            migrationBuilder.DropColumn(
                name: "UsersCredentialsModelUserId",
                table: "ServiceModel");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "UsersCredentialsModels",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "ServiceModel",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "modelId",
                table: "ServiceModel",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersCredentialsModels",
                table: "UsersCredentialsModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceModel",
                table: "ServiceModel",
                column: "Id");

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
    }
}
