using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Heikal.Lubricant.Infrastructure.Migrations
{
    public partial class addday : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Days",
                columns: new[] { "Id", "CreationDate", "DayName", "IsActive" },
                values: new object[] { 1, new DateTime(2021, 1, 18, 14, 51, 25, 349, DateTimeKind.Local).AddTicks(3579), "Saturday", true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Days",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
