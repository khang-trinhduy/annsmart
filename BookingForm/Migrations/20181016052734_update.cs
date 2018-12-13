using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingForm.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Require",
                table: "appoinment",
                newName: "WorkPlace");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "appoinment",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Borrow",
                table: "appoinment",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Due",
                table: "appoinment",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "appoinment",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Job",
                table: "appoinment",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddColumn<string>(
                name: "Place",
                table: "appoinment",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "appoinment",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Product",
                table: "appoinment",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Purpose",
                table: "appoinment",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Requires",
                table: "appoinment",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Borrow",
                table: "appoinment");

            migrationBuilder.DropColumn(
                name: "Due",
                table: "appoinment");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "appoinment");

            migrationBuilder.DropColumn(
                name: "Job",
                table: "appoinment");

            migrationBuilder.DropColumn(
                name: "MeetingAddress",
                table: "appoinment");

            migrationBuilder.DropColumn(
                name: "MeetingDay",
                table: "appoinment");

            migrationBuilder.DropColumn(
                name: "Place",
                table: "appoinment");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "appoinment");

            migrationBuilder.DropColumn(
                name: "Product",
                table: "appoinment");

            migrationBuilder.DropColumn(
                name: "Purpose",
                table: "appoinment");

            migrationBuilder.DropColumn(
                name: "Requires",
                table: "appoinment");

            migrationBuilder.RenameColumn(
                name: "WorkPlace",
                table: "appoinment",
                newName: "Require");

            migrationBuilder.AlterColumn<string>(
                name: "Day",
                table: "appoinment",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}
