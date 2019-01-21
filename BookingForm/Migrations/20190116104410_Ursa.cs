using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingForm.Migrations
{
    public partial class Ursa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grants_AspNetRoles_CurrRoleId",
                table: "Grants");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Grants");

            migrationBuilder.RenameColumn(
                name: "CurrRoleId",
                table: "Grants",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Grants_CurrRoleId",
                table: "Grants",
                newName: "IX_Grants_RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grants_AspNetRoles_RoleId",
                table: "Grants",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grants_AspNetRoles_RoleId",
                table: "Grants");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Grants",
                newName: "CurrRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Grants_RoleId",
                table: "Grants",
                newName: "IX_Grants_CurrRoleId");

            migrationBuilder.AddColumn<Guid>(
                name: "Role",
                table: "Grants",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Grants_AspNetRoles_CurrRoleId",
                table: "Grants",
                column: "CurrRoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
