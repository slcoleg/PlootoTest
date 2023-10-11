using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Invoice",
                columns: new[] { "Id", "Amount", "Description", "DueDate", "IssuedDate", "State", "VendorId" },
                values: new object[,]
                {
                    { 1, 100m, "MSDN Subscription", new DateTime(2023, 10, 16, 12, 47, 54, 847, DateTimeKind.Local).AddTicks(8160), new DateTime(2023, 10, 10, 12, 47, 54, 847, DateTimeKind.Local).AddTicks(8131), 0, 1 },
                    { 2, 123m, "Private hub", new DateTime(2023, 10, 23, 12, 47, 54, 847, DateTimeKind.Local).AddTicks(8164), new DateTime(2023, 9, 29, 12, 47, 54, 847, DateTimeKind.Local).AddTicks(8162), 0, 2 },
                    { 3, 345m, "Office", new DateTime(2023, 10, 14, 12, 47, 54, 847, DateTimeKind.Local).AddTicks(8168), new DateTime(2023, 9, 20, 12, 47, 54, 847, DateTimeKind.Local).AddTicks(8166), 0, 1 },
                    { 4, 22.22m, "Visio", new DateTime(2023, 10, 12, 12, 47, 54, 847, DateTimeKind.Local).AddTicks(8173), new DateTime(2023, 9, 10, 12, 47, 54, 847, DateTimeKind.Local).AddTicks(8171), 0, 1 },
                    { 5, 12.11m, "Training", new DateTime(2023, 10, 18, 12, 47, 54, 847, DateTimeKind.Local).AddTicks(8176), new DateTime(2023, 10, 8, 12, 47, 54, 847, DateTimeKind.Local).AddTicks(8175), 0, 3 }
                });

            migrationBuilder.InsertData(
                table: "Vendor",
                columns: new[] { "Id", "Address", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "123 Street West, Dallas", "Microsoft Subscriptions", "MSDN" },
                    { 2, "4 Main Street, NY", "Repo", "Docker" },
                    { 3, "5 Quieen Street, Boston", "Books", "EFCore" },
                    { 4, "6 CoonWelth Avenue, Berlin", "Education", "Oracle" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Vendor",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vendor",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vendor",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vendor",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
