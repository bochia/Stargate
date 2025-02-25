using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stargate.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUnneededTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonAstronauts");

            migrationBuilder.UpdateData(
                table: "AstronautDetail",
                keyColumn: "Id",
                keyValue: 1,
                column: "CareerStartDate",
                value: new DateTime(2025, 2, 25, 2, 16, 14, 862, DateTimeKind.Local).AddTicks(8972));

            migrationBuilder.UpdateData(
                table: "AstronautDuty",
                keyColumn: "Id",
                keyValue: 1,
                column: "DutyStartDate",
                value: new DateTime(2025, 2, 25, 2, 16, 14, 862, DateTimeKind.Local).AddTicks(9044));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonAstronauts",
                columns: table => new
                {
                    CareerEndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CareerStartDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CurrentDutyTitle = table.Column<string>(type: "TEXT", nullable: true),
                    CurrentRank = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.UpdateData(
                table: "AstronautDetail",
                keyColumn: "Id",
                keyValue: 1,
                column: "CareerStartDate",
                value: new DateTime(2025, 2, 21, 20, 45, 33, 266, DateTimeKind.Local).AddTicks(1160));

            migrationBuilder.UpdateData(
                table: "AstronautDuty",
                keyColumn: "Id",
                keyValue: 1,
                column: "DutyStartDate",
                value: new DateTime(2025, 2, 21, 20, 45, 33, 266, DateTimeKind.Local).AddTicks(1225));
        }
    }
}
