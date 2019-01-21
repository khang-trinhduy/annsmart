using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingForm.Migrations
{
    public partial class M31 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_AspNetUsers_SupporterId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_SupporterId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "SupporterId",
                table: "Contacts");

            migrationBuilder.AddColumn<string>(
                name: "Supporter",
                table: "Contacts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Supporter",
                table: "Contacts");

            migrationBuilder.AddColumn<Guid>(
                name: "SupporterId",
                table: "Contacts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_SupporterId",
                table: "Contacts",
                column: "SupporterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_AspNetUsers_SupporterId",
                table: "Contacts",
                column: "SupporterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
