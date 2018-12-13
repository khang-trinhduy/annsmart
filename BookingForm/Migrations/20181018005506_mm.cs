using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingForm.Migrations
{
    public partial class mm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Borrow",
                table: "appoinment");

            migrationBuilder.DropColumn(
                name: "Due",
                table: "appoinment");

            migrationBuilder.DropColumn(
                name: "MeetingAddress",
                table: "appoinment");

            migrationBuilder.DropColumn(
                name: "MeetingDay",
                table: "appoinment");

            migrationBuilder.DropColumn(
                name: "fromTime",
                table: "appoinment");

            migrationBuilder.DropColumn(
                name: "toTime",
                table: "appoinment");

            migrationBuilder.AddColumn<double>(
                name: "Money",
                table: "appoinment",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "appoinment",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Money",
                table: "appoinment");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "appoinment");

            migrationBuilder.AddColumn<bool>(
                name: "Borrow",
                table: "appoinment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Due",
                table: "appoinment",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "MeetingAddress",
                table: "appoinment",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MeetingDay",
                table: "appoinment",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "fromTime",
                table: "appoinment",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "toTime",
                table: "appoinment",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
