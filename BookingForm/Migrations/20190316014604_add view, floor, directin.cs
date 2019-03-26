using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingForm.Migrations
{
    public partial class addviewfloordirectin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Acreage",
                table: "appoinment",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Direction",
                table: "appoinment",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Floor",
                table: "appoinment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "View",
                table: "appoinment",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Acreage",
                table: "appoinment");

            migrationBuilder.DropColumn(
                name: "Direction",
                table: "appoinment");

            migrationBuilder.DropColumn(
                name: "Floor",
                table: "appoinment");

            migrationBuilder.DropColumn(
                name: "View",
                table: "appoinment");
        }
    }
}
