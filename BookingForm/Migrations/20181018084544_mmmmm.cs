using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingForm.Migrations
{
    public partial class mmmmm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Product",
                table: "appoinment");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "appoinment",
                newName: "NSHH");

            migrationBuilder.AddColumn<int>(
                name: "NCH1",
                table: "appoinment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NCH2",
                table: "appoinment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NCH3",
                table: "appoinment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NMS",
                table: "appoinment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NSH",
                table: "appoinment",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NCH1",
                table: "appoinment");

            migrationBuilder.DropColumn(
                name: "NCH2",
                table: "appoinment");

            migrationBuilder.DropColumn(
                name: "NCH3",
                table: "appoinment");

            migrationBuilder.DropColumn(
                name: "NMS",
                table: "appoinment");

            migrationBuilder.DropColumn(
                name: "NSH",
                table: "appoinment");

            migrationBuilder.RenameColumn(
                name: "NSHH",
                table: "appoinment",
                newName: "Number");

            migrationBuilder.AddColumn<string>(
                name: "Product",
                table: "appoinment",
                nullable: false,
                defaultValue: "");
        }
    }
}
