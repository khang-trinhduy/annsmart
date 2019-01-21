using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingForm.Migrations
{
    public partial class Titan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdType",
                table: "appoinment",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsForeigner",
                table: "appoinment",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdType",
                table: "appoinment");

            migrationBuilder.DropColumn(
                name: "IsForeigner",
                table: "appoinment");
        }
    }
}
