using Microsoft.EntityFrameworkCore.Migrations;

namespace AreaApi.Migrations
{
    public partial class manymany7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Area_AspNetUsers_ApplicationUserId",
                table: "Area");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Area_AreaId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AreaId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Area",
                newName: "OwnerUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Area_ApplicationUserId",
                table: "Area",
                newName: "IX_Area_OwnerUserId");

            migrationBuilder.CreateTable(
                name: "ApplicationUserArea",
                columns: table => new
                {
                    AreasId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserArea", x => new { x.AreasId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserArea_Area_AreasId",
                        column: x => x.AreasId,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserArea_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserArea_UsersId",
                table: "ApplicationUserArea",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Area_AspNetUsers_OwnerUserId",
                table: "Area",
                column: "OwnerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Area_AspNetUsers_OwnerUserId",
                table: "Area");

            migrationBuilder.DropTable(
                name: "ApplicationUserArea");

            migrationBuilder.RenameColumn(
                name: "OwnerUserId",
                table: "Area",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Area_OwnerUserId",
                table: "Area",
                newName: "IX_Area_ApplicationUserId");

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
                name: "FK_Area_AspNetUsers_ApplicationUserId",
                table: "Area",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
