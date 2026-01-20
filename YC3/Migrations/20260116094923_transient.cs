using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YC3.Migrations
{
    /// <inheritdoc />
    public partial class transient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Events_EventId",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Seats_EventId",
                table: "Seats");

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

            migrationBuilder.AddColumn<decimal>(
                name: "PriceAtBooking",
                table: "Tickets",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "ConcertEventId",
                table: "Seats",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Seats",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

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

            migrationBuilder.CreateIndex(
                name: "IX_Seats_ConcertEventId",
                table: "Seats",
                column: "ConcertEventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Events_ConcertEventId",
                table: "Seats",
                column: "ConcertEventId",
                principalTable: "Events",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Events_ConcertEventId",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Seats_ConcertEventId",
                table: "Seats");

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

            migrationBuilder.DropColumn(
                name: "PriceAtBooking",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ConcertEventId",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Orders");

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

            migrationBuilder.CreateIndex(
                name: "IX_Seats_EventId",
                table: "Seats",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Events_EventId",
                table: "Seats",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
