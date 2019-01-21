using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingForm.Migrations
{
    public partial class Polaris : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CurrRoleId",
                table: "Grants",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grants_CurrRoleId",
                table: "Grants",
                column: "CurrRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grants_AspNetRoles_CurrRoleId",
                table: "Grants",
                column: "CurrRoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grants_AspNetRoles_CurrRoleId",
                table: "Grants");

            migrationBuilder.DropIndex(
                name: "IX_Grants_CurrRoleId",
                table: "Grants");

            migrationBuilder.DropColumn(
                name: "CurrRoleId",
                table: "Grants");
        }
    }
}
