using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingForm.Migrations
{
    public partial class ns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "unknow",
                table: "transactions",
                newName: "Sothamchieu");

            migrationBuilder.AddColumn<int>(
                name: "NCH21",
                table: "appoinment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NS",
                table: "appoinment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "pns",
                table: "appoinment",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NCH21",
                table: "appoinment");

            migrationBuilder.DropColumn(
                name: "NS",
                table: "appoinment");

            migrationBuilder.DropColumn(
                name: "pns",
                table: "appoinment");

            migrationBuilder.RenameColumn(
                name: "Sothamchieu",
                table: "transactions",
                newName: "unknow");
        }
    }
}
