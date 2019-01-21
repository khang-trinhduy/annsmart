using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingForm.Migrations
{
    public partial class Sirius : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    Condition = table.Column<string>(nullable: true),
                    CNumber = table.Column<int>(nullable: false),
                    PNumber = table.Column<int>(nullable: false),
                    Ch = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Policy = table.Column<string>(nullable: true),
                    Charges = table.Column<double>(nullable: false),
                    Totals = table.Column<double>(nullable: false),
                    PDate = table.Column<DateTime>(nullable: false),
                    q4a = table.Column<string>(nullable: true),
                    q5a = table.Column<bool>(nullable: false),
                    q5b = table.Column<bool>(nullable: false),
                    q5c = table.Column<bool>(nullable: false),
                    q5d = table.Column<bool>(nullable: false),
                    q6a = table.Column<bool>(nullable: false),
                    q6b = table.Column<bool>(nullable: false),
                    q6c = table.Column<bool>(nullable: false),
                    q7a = table.Column<bool>(nullable: false),
                    q7b = table.Column<bool>(nullable: false),
                    q7c = table.Column<bool>(nullable: false),
                    q7d = table.Column<bool>(nullable: false),
                    q7e = table.Column<bool>(nullable: false),
                    q7f = table.Column<bool>(nullable: false),
                    q7g = table.Column<bool>(nullable: false),
                    q7h = table.Column<bool>(nullable: false),
                    q7i = table.Column<bool>(nullable: false),
                    q7j = table.Column<bool>(nullable: false),
                    q7k = table.Column<bool>(nullable: false),
                    q7l = table.Column<bool>(nullable: false),
                    q7m = table.Column<bool>(nullable: false),
                    SupporterId = table.Column<Guid>(nullable: true),
                    ProviderId = table.Column<Guid>(nullable: true),
                    Signed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_AspNetUsers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contacts_AspNetUsers_SupporterId",
                        column: x => x.SupporterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ProviderId",
                table: "Contacts",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_SupporterId",
                table: "Contacts",
                column: "SupporterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
