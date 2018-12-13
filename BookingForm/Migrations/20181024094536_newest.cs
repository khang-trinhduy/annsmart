using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingForm.Migrations
{
    public partial class newest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Priority",
                table: "appoinment",
                newName: "pshh");

            migrationBuilder.AddColumn<string>(
                name: "info",
                table: "sale",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "sale",
                table: "appoinment",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "SaleDetails",
                table: "appoinment",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ph",
                table: "appoinment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "pms",
                table: "appoinment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "psh",
                table: "appoinment",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "info",
                table: "sale");

            migrationBuilder.DropColumn(
                name: "SaleDetails",
                table: "appoinment");

            migrationBuilder.DropColumn(
                name: "ph",
                table: "appoinment");

            migrationBuilder.DropColumn(
                name: "pms",
                table: "appoinment");

            migrationBuilder.DropColumn(
                name: "psh",
                table: "appoinment");

            migrationBuilder.RenameColumn(
                name: "pshh",
                table: "appoinment",
                newName: "Priority");

            migrationBuilder.AlterColumn<string>(
                name: "sale",
                table: "appoinment",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
