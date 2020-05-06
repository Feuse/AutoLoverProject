using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoMatcherProject1.Migrations
{
    public partial class serviceMOdel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Service",
                table: "UsersCredentialsModels");

            migrationBuilder.CreateTable(
                name: "ServiceModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Service = table.Column<int>(nullable: false),
                    UsersCredentialsModelId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceModel_UsersCredentialsModels_UsersCredentialsModelId",
                        column: x => x.UsersCredentialsModelId,
                        principalTable: "UsersCredentialsModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceModel_UsersCredentialsModelId",
                table: "ServiceModel",
                column: "UsersCredentialsModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceModel");

            migrationBuilder.AddColumn<int>(
                name: "Service",
                table: "UsersCredentialsModels",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
