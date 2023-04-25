using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Forms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Forms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Forms_AppUserId",
                table: "Forms",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_AspNetUsers_AppUserId",
                table: "Forms",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forms_AspNetUsers_AppUserId",
                table: "Forms");

            migrationBuilder.DropIndex(
                name: "IX_Forms_AppUserId",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Forms");
        }
    }
}
