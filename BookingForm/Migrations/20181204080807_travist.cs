using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingForm.Migrations
{
    public partial class travist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "sale",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "birthday",
                table: "sale",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "gender",
                table: "sale",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "portrait",
                table: "sale",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "address",
                table: "sale");

            migrationBuilder.DropColumn(
                name: "birthday",
                table: "sale");

            migrationBuilder.DropColumn(
                name: "gender",
                table: "sale");

            migrationBuilder.DropColumn(
                name: "portrait",
                table: "sale");
        }
    }
}
