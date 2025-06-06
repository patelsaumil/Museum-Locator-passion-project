using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Museum_Locator.Data.Migrations
{
    /// <inheritdoc />
    public partial class usermusuemfeedback : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Museum_Id",
                table: "Feedbacks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Museum_Id1",
                table: "Feedbacks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "User_Id",
                table: "Feedbacks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "User_Id1",
                table: "Feedbacks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_Museum_Id1",
                table: "Feedbacks",
                column: "Museum_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_User_Id1",
                table: "Feedbacks",
                column: "User_Id1");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Museums_Museum_Id1",
                table: "Feedbacks",
                column: "Museum_Id1",
                principalTable: "Museums",
                principalColumn: "Museum_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Users_User_Id1",
                table: "Feedbacks",
                column: "User_Id1",
                principalTable: "Users",
                principalColumn: "User_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Museums_Museum_Id1",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Users_User_Id1",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_Museum_Id1",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_User_Id1",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "Museum_Id",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "Museum_Id1",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "User_Id",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "User_Id1",
                table: "Feedbacks");
        }
    }
}
