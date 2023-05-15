using Microsoft.EntityFrameworkCore.Migrations;

namespace AreaApi.Migrations
{
    public partial class AddUserToArea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AreaId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AreaId",
                table: "AspNetUsers",
                column: "AreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Area_AreaId",
                table: "AspNetUsers",
                column: "AreaId",
                principalTable: "Area",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Area_AreaId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AreaId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "AspNetUsers");
        }
    }
}
