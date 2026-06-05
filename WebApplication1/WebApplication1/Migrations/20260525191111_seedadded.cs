using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class seedadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PCs",
                columns: new[] { "Id", "CreatedAt", "Name", "Stock", "Warranty", "Weight" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 25, 21, 11, 10, 876, DateTimeKind.Local).AddTicks(439), "ROG Strix", 10, 5, 10.5f },
                    { 2, new DateTime(2026, 5, 25, 21, 11, 10, 878, DateTimeKind.Local).AddTicks(2005), "ROG Strix", 9, 5, 9.5f },
                    { 3, new DateTime(2026, 5, 25, 21, 11, 10, 878, DateTimeKind.Local).AddTicks(2024), "ROG Strix", 8, 5, 8.5f }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PCs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PCs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PCs",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
