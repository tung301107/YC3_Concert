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

        // 1. Tạo ID cố định để tránh thay đổi khi Migration lại
        var eventId = Guid.Parse("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d");

        // 2. Seed data cho ConcertEvent
        modelBuilder.Entity<ConcertEvent>().HasData(
            new ConcertEvent
            {
                Id = eventId,
                Name = "The Eras Tour - Vietnam",
                DateTime = new DateTime(2025, 12, 25, 19, 0, 0),
                Description = "Đêm nhạc hoành tráng nhất năm",
                TotalSeats = 10 // Giả sử 10 ghế để test nhanh
            }
        );

        // 3. Seed data cho Seats (Tự động tạo hàng A và hàng B)
        var seats = new List<Seat>();
        string[] rows = { "A", "B" };
        int seatCounter = 1;

        for (int i = 0; i < rows.Length; i++)
        {
            for (int j = 1; j <= 5; j++) // Mỗi hàng 5 ghế
            {
                seats.Add(new Seat
                {
                    SeatId = Guid.NewGuid(), // Lưu ý: Trong thực tế Seed Data nên dùng GUID cố định
                    RowName = rows[i],
                    SeatNumber = j,
                    IsAvailable = true,
                    EventId = eventId
                });
            }
        }

        modelBuilder.Entity<Seat>().HasData(seats);
    }
}