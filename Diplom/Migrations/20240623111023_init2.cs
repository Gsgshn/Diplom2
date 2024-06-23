using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diplom.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Apps_Id",
                table: "AspNetUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_Apps_AspNetUsers_Id",
                table: "Apps",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apps_AspNetUsers_Id",
                table: "Apps");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Apps_Id",
                table: "AspNetUsers",
                column: "Id",
                principalTable: "Apps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
