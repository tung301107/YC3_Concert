using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using YC3.Models;

namespace YC3.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Order> Orders { get; set; }
    public DbSet<ConcertEvent> Events { get; set; }
    public DbSet<Seat> Seats { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // 1. Tạo ID cố định cho Event
        var eventId = Guid.Parse("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d");

        // 2. Seed data cho ConcertEvent
        modelBuilder.Entity<ConcertEvent>().HasData(
            new ConcertEvent
            {
                Id = eventId,
                Name = "The Eras Tour - Vietnam",
                DateTime = new DateTime(2025, 12, 25, 19, 0, 0),
                Description = "Đêm nhạc hoành tráng nhất năm",
                TotalSeats = 10
            }
        );

        // 3. Seed data cho Seats (Có thêm thuộc tính Price)
        var seats = new List<Seat>();
        string[] rows = { "A", "B" };

        // Giá vé mẫu cho Seed Data
        decimal defaultPrice = 2000000; // 2 triệu VNĐ

        for (int i = 0; i < rows.Length; i++)
        {
            for (int j = 1; j <= 5; j++)
            {
                // QUAN TRỌNG: Khi Seed data, nên dùng Guid.Parse với chuỗi cố định 
                // hoặc logic tạo GUID dựa trên số ghế để tránh tạo mới mỗi lần chạy Migration
                var seatId = Guid.Parse($"00000000-0000-0000-000{i}-00000000000{j}");

                seats.Add(new Seat
                {
                    SeatId = seatId,
                    RowName = rows[i],
                    SeatNumber = j,
                    IsAvailable = true,
                    Price = defaultPrice, // <-- CẬP NHẬT: Thêm giá vé ở đây
                    EventId = eventId
                });
            }
        }

        modelBuilder.Entity<Seat>().HasData(seats);
    }
}