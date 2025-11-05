using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DiaryApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedingDataDiaryEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DiaryEntries",
                columns: new[] { "Id", "Content", "Created", "IsActive", "Title" },
                values: new object[,]
                {
                    { 1, "Went hiking with Joe!", new DateTime(2025, 11, 5, 21, 52, 24, 585, DateTimeKind.Local).AddTicks(9711), true, "Went Hiking" },
                    { 2, "Went shopping with Joe!", new DateTime(2025, 11, 5, 21, 52, 24, 586, DateTimeKind.Local).AddTicks(405), true, "Went Shopping" },
                    { 3, "Went diving with Joe!", new DateTime(2025, 11, 5, 21, 52, 24, 586, DateTimeKind.Local).AddTicks(407), true, "Went Diving" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
