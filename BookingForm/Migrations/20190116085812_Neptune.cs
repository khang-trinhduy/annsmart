using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingForm.Migrations
{
    public partial class Neptune : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Grants",
                newName: "RoleName");

            migrationBuilder.AddColumn<Guid>(
                name: "Roles",
                table: "Grants",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Roles",
                table: "Grants");

            migrationBuilder.RenameColumn(
                name: "RoleName",
                table: "Grants",
                newName: "Role");
        }
    }
}
