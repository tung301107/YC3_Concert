using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YC3.Migrations
{
    /// <inheritdoc />
    public partial class SeedConcertAndSeats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "DateTime", "Description", "Name", "TotalSeats" },
                values: new object[] { new Guid("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d"), new DateTime(2025, 12, 25, 19, 0, 0, 0, DateTimeKind.Unspecified), "Đêm nhạc hoành tráng nhất năm", "The Eras Tour - Vietnam", 10 });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "SeatId", "EventId", "IsAvailable", "RowName", "SeatNumber" },
                values: new object[,]
                {
                    { new Guid("1b594fcf-06cf-4f15-a877-9e1a450ed44c"), new Guid("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d"), true, "B", 4 },
                    { new Guid("2babc1f4-b17f-4b3b-b3bf-7339b2e86432"), new Guid("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d"), true, "B", 5 },
                    { new Guid("31024cf6-6e7a-4e67-b2c8-be87cd821e20"), new Guid("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d"), true, "A", 5 },
                    { new Guid("3a594d1b-3916-431c-a9c9-68fd2cbcd85d"), new Guid("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d"), true, "B", 2 },
                    { new Guid("6a44327f-97a0-4e71-aefc-55dfe4dabb23"), new Guid("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d"), true, "A", 2 },
                    { new Guid("734baade-366c-4810-a0d8-522ba1eaefbd"), new Guid("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d"), true, "B", 3 },
                    { new Guid("9df7b1b1-40c1-4f5a-a310-0b884a7b576a"), new Guid("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d"), true, "B", 1 },
                    { new Guid("a35ab57f-1d53-4018-a6a9-323a6002b11d"), new Guid("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d"), true, "A", 3 },
                    { new Guid("a970397c-3c8f-4e8e-a575-a24d3d0ecca5"), new Guid("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d"), true, "A", 4 },
                    { new Guid("ffafec5a-6c81-414f-b5b3-b998dd101174"), new Guid("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d"), true, "A", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: new Guid("1b594fcf-06cf-4f15-a877-9e1a450ed44c"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: new Guid("2babc1f4-b17f-4b3b-b3bf-7339b2e86432"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: new Guid("31024cf6-6e7a-4e67-b2c8-be87cd821e20"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: new Guid("3a594d1b-3916-431c-a9c9-68fd2cbcd85d"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: new Guid("6a44327f-97a0-4e71-aefc-55dfe4dabb23"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: new Guid("734baade-366c-4810-a0d8-522ba1eaefbd"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: new Guid("9df7b1b1-40c1-4f5a-a310-0b884a7b576a"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: new Guid("a35ab57f-1d53-4018-a6a9-323a6002b11d"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: new Guid("a970397c-3c8f-4e8e-a575-a24d3d0ecca5"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: new Guid("ffafec5a-6c81-414f-b5b3-b998dd101174"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d"));
        }
    }
}
