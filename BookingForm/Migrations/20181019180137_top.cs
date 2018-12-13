using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingForm.Migrations
{
    public partial class top : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SaleID",
                table: "appoinment",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_appoinment_SaleID",
                table: "appoinment",
                column: "SaleID");

            migrationBuilder.AddForeignKey(
                name: "FK_appoinment_sale_SaleID",
                table: "appoinment",
                column: "SaleID",
                principalTable: "sale",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appoinment_sale_SaleID",
                table: "appoinment");

            migrationBuilder.DropIndex(
                name: "IX_appoinment_SaleID",
                table: "appoinment");

            migrationBuilder.DropColumn(
                name: "SaleID",
                table: "appoinment");
        }
    }
}
