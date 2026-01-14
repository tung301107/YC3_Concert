using Microsoft.EntityFrameworkCore; // Quan trọng: Giúp hết lỗi .Include() và .ToListAsync()
using YC3.Data;
using YC3.Interfaces;
using YC3.Models;
using YC3.DTO;

namespace YC3.Services;

public class EventService : IEventService
{
    private readonly ApplicationDbContext _context;

    // Inject DbContext (Scoped) vào Service
    public EventService(ApplicationDbContext context)
    {
        _context = context;
    }

    // Tạo sự kiện và tự động tạo danh sách ghế
    public async Task<Guid> CreateEventAsync(CreateEventDto dto)
    {
        var newEvent = new ConcertEvent
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            DateTime = dto.DateTime,
            Description = dto.Description,
            TotalSeats = dto.Rows.Count * dto.SeatsPerRow
        };

        // Logic tạo ghế theo hàng (A, B, C...) và số (1, 2, 3...)
        foreach (var row in dto.Rows)
        {
            for (int i = 1; i <= dto.SeatsPerRow; i++)
            {
                newEvent.Seats.Add(new Seat
                {
                    SeatId = Guid.NewGuid(),
                    RowName = row,
                    SeatNumber = i,
                    IsAvailable = true,
                    EventId = newEvent.Id
                });
            }
        }

        _context.Events.Add(newEvent);
        await _context.SaveChangesAsync();
        return newEvent.Id;
    }

    // Lấy tất cả sự kiện kèm theo danh sách ghế (Eager Loading)
    public async Task<List<ConcertEvent>> GetAllEventsAsync()
    {
        return await _context.Events
            .Include(e => e.Seats) // Sử dụng EF Core để nạp dữ liệu liên quan
            .ToListAsync();
    }

    // Cập nhật thông tin sự kiện
    public async Task<bool> UpdateEventAsync(Guid id, CreateEventDto dto)
    {
        var existingEvent = await _context.Events.FindAsync(id);
        if (existingEvent == null) return false;

        existingEvent.Name = dto.Name;
        existingEvent.Description = dto.Description;
        existingEvent.DateTime = dto.DateTime;

        await _context.SaveChangesAsync();
        return true;
    }
}