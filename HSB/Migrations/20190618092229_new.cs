using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HSB.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Donors",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    RowVersion = table.Column<DateTime>(rowVersion: true, nullable: true),
                    FirstName = table.Column<string>(maxLength: 60, nullable: false),
                    LastName = table.Column<string>(maxLength: 60, nullable: false),
                    PhoneNo = table.Column<string>(maxLength: 12, nullable: false),
                    Cpr = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    RowVersion = table.Column<DateTime>(rowVersion: true, nullable: true),
                    FirstName = table.Column<string>(maxLength: 60, nullable: false),
                    LastName = table.Column<string>(maxLength: 60, nullable: false),
                    Cpr = table.Column<int>(nullable: true),
                    PhoneNo = table.Column<string>(maxLength: 12, nullable: false),
                    Email = table.Column<string>(maxLength: 80, nullable: false),
                    Address = table.Column<string>(maxLength: 60, nullable: false),
                    Zip = table.Column<string>(nullable: false),
                    City = table.Column<string>(maxLength: 60, nullable: false),
                    Subscribed = table.Column<bool>(nullable: false),
                    Conditions = table.Column<bool>(nullable: false),
                    PrivacyNotice = table.Column<bool>(nullable: false),
                    MobilePay = table.Column<bool>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    FromDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donors");

            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
