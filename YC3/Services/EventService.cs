using Microsoft.EntityFrameworkCore;
using YC3.Data;
using YC3.Interfaces;
using YC3.Models;
using YC3.DTO;

namespace YC3.Services
{
    public class EventService : IEventService
    {
        private readonly ApplicationDbContext _context;

        public EventService(ApplicationDbContext context)
        {
            _context = context;
        }

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

            // Tự động tạo danh sách ghế dựa trên số hàng và số ghế mỗi hàng
            foreach (var rowName in dto.Rows)
            {
                for (int i = 1; i <= dto.SeatsPerRow; i++)
                {
                    newEvent.Seats.Add(new Seat
                    {
                        SeatId = Guid.NewGuid(),
                        RowName = rowName,
                        SeatNumber = i,
                        IsAvailable = true,
                        Price = dto.Price, // <-- Gán giá vé cho từng ghế
                        EventId = newEvent.Id
                    });
                }
            }

            _context.Events.Add(newEvent);
            await _context.SaveChangesAsync();
            return newEvent.Id;
        }

        public async Task<List<ConcertEvent>> GetAllEventsAsync()
        {
            return await _context.Events
                .Include(e => e.Seats)
                .ToListAsync();
        }

        public async Task<bool> UpdateEventAsync(Guid id, CreateEventDto dto)
        {
            var existingEvent = await _context.Events.Include(e => e.Seats).FirstOrDefaultAsync(x => x.Id == id);
            if (existingEvent == null) return false;

            existingEvent.Name = dto.Name;
            existingEvent.Description = dto.Description;
            existingEvent.DateTime = dto.DateTime;

            // Cập nhật giá vé cho tất cả các ghế của sự kiện này nếu cần
            foreach (var seat in existingEvent.Seats)
            {
                seat.Price = dto.Price;
            }

            await _context.SaveChangesAsync();
            return true;
        }
    }
}