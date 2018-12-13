using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingForm.Migrations
{
    public partial class transaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Hieuthietbi = table.Column<string>(nullable: true),
                    Sohieudv = table.Column<string>(nullable: true),
                    Diachi = table.Column<string>(nullable: true),
                    Loaithe = table.Column<string>(nullable: true),
                    Ngaygd = table.Column<string>(nullable: true),
                    Giogd = table.Column<string>(nullable: true),
                    Ngayxl = table.Column<string>(nullable: true),
                    Sothe = table.Column<string>(nullable: true),
                    Machuanchi = table.Column<string>(nullable: true),
                    Solo = table.Column<string>(nullable: true),
                    Tiengd = table.Column<string>(nullable: true),
                    Phi = table.Column<string>(nullable: true),
                    VAT = table.Column<string>(nullable: true),
                    Tylephantram = table.Column<string>(nullable: true),
                    unknow = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transactions");
        }
    }
}
