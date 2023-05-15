using Microsoft.EntityFrameworkCore.Migrations;

namespace AreaApi.Migrations
{
    public partial class TesteFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "AreaId",
                table: "AreaUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AreaUsers_AreaId",
                table: "AreaUsers",
                column: "AreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AreaUsers_Area_AreaId",
                table: "AreaUsers",
                column: "AreaId",
                principalTable: "Area",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AreaUsers_Area_AreaId",
                table: "AreaUsers");

            migrationBuilder.DropIndex(
                name: "IX_AreaUsers_AreaId",
                table: "AreaUsers");

            migrationBuilder.AddColumn<int>(
                name: "AreaId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AreaId",
                table: "AreaUsers",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

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
    }
}
