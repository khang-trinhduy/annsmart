using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingForm.Migrations
{
    public partial class Sun : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Grants",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grants_UserId",
                table: "Grants",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grants_AspNetUsers_UserId",
                table: "Grants",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grants_AspNetUsers_UserId",
                table: "Grants");

            migrationBuilder.DropIndex(
                name: "IX_Grants_UserId",
                table: "Grants");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Grants");
        }
    }
}
