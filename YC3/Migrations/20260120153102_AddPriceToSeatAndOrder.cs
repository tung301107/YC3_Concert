using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YC3.Migrations
{
    /// <inheritdoc />
    public partial class AddPriceToSeatAndOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: new Guid("33cc6dc8-7836-48a1-aedf-0592650c11ed"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: new Guid("3f62c10f-d885-4110-be59-c84dc9f5d97a"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: new Guid("63f46c8b-daa9-486f-8ef9-6acfe7934437"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: new Guid("6929df17-19fe-406d-b778-a37d544c96b7"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: new Guid("752fca55-c87e-4a7a-9716-6f45621ddf75"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: new Guid("75f50dd4-71d4-4728-8a68-43b6f15b7db4"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: new Guid("a3d96d02-f3fb-4dca-8a4e-f6c9b12b70a6"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: new Guid("d72af3ea-74c3-4223-90a5-d77cbadf7030"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: new Guid("e0bae87f-6bd7-47bd-be27-2cdff548a816"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: new Guid("ee65396b-fc73-45c0-8672-75e7a8ca7ead"));

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "SeatId", "ConcertEventId", "EventId", "IsAvailable", "Price", "RowName", "SeatNumber" },
                values: new object[,]
                {
                    { new Guid("09fb82fe-f590-4264-9555-43e9a34d5bf6"), null, new Guid("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d"), true, 0m, "A", 4 },
                    { new Guid("19144aad-8cd3-4ce8-a471-a27dd3995c01"), null, new Guid("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d"), true, 0m, "B", 4 },
                    { new Guid("1c6303b3-6fa8-42a8-ab63-da97d9dfb7d3"), null, new Guid("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d"), true, 0m, "A", 3 },
                    { new Guid("4ed4a8f1-d2c8-4cc3-b774-55ce5dce17d4"), null, new Guid("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d"), true, 0m, "B", 2 },
                    { new Guid("5299d0bb-5ff4-42ad-ad1c-9a1017985c31"), null, new Guid("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d"), true, 0m, "B", 5 },
                    { new Guid("700e5b41-f4e8-4740-a47f-9baec6af89c7"), null, new Guid("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d"), true, 0m, "A", 1 },
                    { new Guid("bbb1d45f-ab2e-45b8-ad30-fc3b039b8f1f"), null, new Guid("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d"), true, 0m, "B", 3 },
                    { new Guid("df587dc7-dd97-494e-ad91-5c51b41da1fb"), null, new Guid("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d"), true, 0m, "A", 5 },
                    { new Guid("e237e2eb-5c58-4e4b-a595-b83f3cb4fb1b"), null, new Guid("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d"), true, 0m, "A", 2 },
                    { new Guid("f1d7898a-02eb-4809-8ffc-7b6b19dfdb2a"), null, new Guid("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d"), true, 0m, "B", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: new Guid("09fb82fe-f590-4264-9555-43e9a34d5bf6"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: new Guid("19144aad-8cd3-4ce8-a471-a27dd3995c01"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: new Guid("1c6303b3-6fa8-42a8-ab63-da97d9dfb7d3"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: new Guid("4ed4a8f1-d2c8-4cc3-b774-55ce5dce17d4"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: new Guid("5299d0bb-5ff4-42ad-ad1c-9a1017985c31"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: new Guid("700e5b41-f4e8-4740-a47f-9baec6af89c7"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: new Guid("bbb1d45f-ab2e-45b8-ad30-fc3b039b8f1f"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: new Guid("df587dc7-dd97-494e-ad91-5c51b41da1fb"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: new Guid("e237e2eb-5c58-4e4b-a595-b83f3cb4fb1b"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: new Guid("f1d7898a-02eb-4809-8ffc-7b6b19dfdb2a"));

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "SeatId", "ConcertEventId", "EventId", "IsAvailable", "Price", "RowName", "SeatNumber" },
                values: new object[,]
                {
                    { new Guid("33cc6dc8-7836-48a1-aedf-0592650c11ed"), null, new Guid("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d"), true, 0m, "B", 1 },
                    { new Guid("3f62c10f-d885-4110-be59-c84dc9f5d97a"), null, new Guid("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d"), true, 0m, "A", 2 },
                    { new Guid("63f46c8b-daa9-486f-8ef9-6acfe7934437"), null, new Guid("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d"), true, 0m, "B", 2 },
                    { new Guid("6929df17-19fe-406d-b778-a37d544c96b7"), null, new Guid("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d"), true, 0m, "A", 3 },
                    { new Guid("752fca55-c87e-4a7a-9716-6f45621ddf75"), null, new Guid("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d"), true, 0m, "A", 5 },
                    { new Guid("75f50dd4-71d4-4728-8a68-43b6f15b7db4"), null, new Guid("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d"), true, 0m, "B", 4 },
                    { new Guid("a3d96d02-f3fb-4dca-8a4e-f6c9b12b70a6"), null, new Guid("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d"), true, 0m, "A", 1 },
                    { new Guid("d72af3ea-74c3-4223-90a5-d77cbadf7030"), null, new Guid("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d"), true, 0m, "A", 4 },
                    { new Guid("e0bae87f-6bd7-47bd-be27-2cdff548a816"), null, new Guid("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d"), true, 0m, "B", 3 },
                    { new Guid("ee65396b-fc73-45c0-8672-75e7a8ca7ead"), null, new Guid("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d"), true, 0m, "B", 5 }
                });
        }
    }
}
