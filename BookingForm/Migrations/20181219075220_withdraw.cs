using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingForm.Migrations
{
    public partial class withdraw : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "WDay",
                table: "appoinment",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "WMoney",
                table: "appoinment",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "WType",
                table: "appoinment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WithdrawCode",
                table: "appoinment",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WDay",
                table: "appoinment");

            migrationBuilder.DropColumn(
                name: "WMoney",
                table: "appoinment");

            migrationBuilder.DropColumn(
                name: "WType",
                table: "appoinment");

            migrationBuilder.DropColumn(
                name: "WithdrawCode",
                table: "appoinment");
        }
    }
}
