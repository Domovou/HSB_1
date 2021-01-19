using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HSB.Migrations
{
    public partial class Case : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RowVersion",
                table: "Members",
                rowVersion: true,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RowVersion",
                table: "Donors",
                rowVersion: true,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    RowVersion = table.Column<DateTime>(rowVersion: true, nullable: true),
                    FirstName = table.Column<string>(maxLength: 60, nullable: false),
                    LastName = table.Column<string>(maxLength: 60, nullable: false),
                    Address = table.Column<string>(maxLength: 60, nullable: false),
                    Zip = table.Column<string>(nullable: false),
                    City = table.Column<string>(maxLength: 60, nullable: false),
                    Birthdate = table.Column<DateTime>(nullable: false),
                    PhoneNo = table.Column<string>(maxLength: 12, nullable: false),
                    Email = table.Column<string>(maxLength: 80, nullable: false),
                    Diagnosis = table.Column<string>(maxLength: 1000, nullable: false),
                    Story = table.Column<string>(maxLength: 10000, nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Parent = table.Column<string>(maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RowVersion",
                table: "Members",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldRowVersion: true,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RowVersion",
                table: "Donors",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldRowVersion: true,
                oldNullable: true);
        }
    }
}
