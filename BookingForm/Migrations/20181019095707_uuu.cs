using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingForm.Migrations
{
    public partial class uuu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "appoinment",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "sale",
                table: "appoinment",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "sale",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: false),
                    phone = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    pass = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sale", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sale");

            migrationBuilder.DropColumn(
                name: "password",
                table: "appoinment");

            migrationBuilder.DropColumn(
                name: "sale",
                table: "appoinment");
        }
    }
}
