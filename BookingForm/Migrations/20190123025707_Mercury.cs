using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingForm.Migrations
{
    public partial class Mercury : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContractNumber",
                table: "Requests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Customer",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "Requests",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoanStatus",
                table: "Requests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaritalStatus",
                table: "Requests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Product",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Purpose",
                table: "Requests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContractNumber",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Customer",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "DOB",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "LoanStatus",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Product",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Purpose",
                table: "Requests");
        }
    }
}
