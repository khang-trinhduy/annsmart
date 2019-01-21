using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingForm.Migrations
{
    public partial class Whirlwind : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AppoinmentId",
                table: "Contacts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_AppoinmentId",
                table: "Contacts",
                column: "AppoinmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_appoinment_AppoinmentId",
                table: "Contacts",
                column: "AppoinmentId",
                principalTable: "appoinment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_appoinment_AppoinmentId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_AppoinmentId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "AppoinmentId",
                table: "Contacts");
        }
    }
}
