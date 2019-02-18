using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingForm.Migrations
{
    public partial class EagleNebula : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ContractId",
                table: "Requests",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ContractId",
                table: "Requests",
                column: "ContractId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_appoinment_ContractId",
                table: "Requests",
                column: "ContractId",
                principalTable: "appoinment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_appoinment_ContractId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_ContractId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "Requests");
        }
    }
}
