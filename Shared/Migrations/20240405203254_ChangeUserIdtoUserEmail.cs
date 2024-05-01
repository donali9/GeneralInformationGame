using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeneralInformationGame.Shared.Migrations
{
    public partial class ChangeUserIdtoUserEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_AspNetUsers_UserId",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Games",
                newName: "UserEmail");

            migrationBuilder.RenameIndex(
                name: "IX_Games_UserId",
                table: "Games",
                newName: "IX_Games_UserEmail");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_AspNetUsers_UserEmail",
                table: "Games",
                column: "UserEmail",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_AspNetUsers_UserEmail",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "Games",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_UserEmail",
                table: "Games",
                newName: "IX_Games_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_AspNetUsers_UserId",
                table: "Games",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
