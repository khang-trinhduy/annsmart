using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingForm.Migrations
{
    public partial class nb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OldContract",
                table: "appoinment",
                newName: "Note");

            migrationBuilder.AddColumn<bool>(
                name: "Official",
                table: "appoinment",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Official",
                table: "appoinment");

            migrationBuilder.RenameColumn(
                name: "Note",
                table: "appoinment",
                newName: "OldContract");
        }
    }
}
