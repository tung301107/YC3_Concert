using Microsoft.EntityFrameworkCore;
using YC3.Data;
using YC3.Interfaces;
using YC3.Models;
using System.Linq; // Đảm bảo có dòng này để dùng được .Where() và .Contains()

namespace YC3.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
        private readonly IStatisticsService _statsService;

        public OrderService(ApplicationDbContext context, IStatisticsService statsService)
        {
            _context = context;
            _statsService = statsService;
        }

        public async Task<Guid> PlaceOrderAsync(Guid userId, Guid eventId, List<Guid> seatIds)
        {
            // Kiểm tra danh sách ghế
            var availableSeats = await _context.Seats
                .Where(s => seatIds.Contains(s.SeatId) && s.IsAvailable && s.EventId == eventId)
                .ToListAsync();

            if (availableSeats.Count != seatIds.Count)
            {
                throw new Exception("Một số ghế đã bị đặt hoặc không tồn tại.");
            }

            var orderId = Guid.NewGuid();

            var newOrder = new Order
            {
                OrderId = orderId,
                UserId = userId,
                CreatedAt = DateTime.Now
            };

            _context.Orders.Add(newOrder);

            foreach (var seat in availableSeats)
            {
                seat.IsAvailable = false;
                _context.Tickets.Add(new Ticket
                {
                    TicketId = Guid.NewGuid(),
                    OrderId = orderId,
                    SeatId = seat.SeatId
                });
            }

            await _context.SaveChangesAsync();
            _statsService.AddTickets(seatIds.Count);

            return orderId;
        }
    }
}