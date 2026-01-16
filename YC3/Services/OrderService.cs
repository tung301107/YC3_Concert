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

        // File: Services/OrderService.cs
        public async Task<Guid> PlaceOrderAsync(Guid userId, Guid eventId, List<Guid> seatIds, decimal totalAmount) // Thêm totalAmount ở đây
        {
            // 1. Kiểm tra danh sách ghế
            var availableSeats = await _context.Seats
                .Where(s => seatIds.Contains(s.SeatId) && s.IsAvailable && s.EventId == eventId)
                .ToListAsync();

            if (availableSeats.Count != seatIds.Count)
            {
                throw new Exception("Một số ghế đã bị đặt hoặc không tồn tại.");
            }

            var orderId = Guid.NewGuid();

            // 2. Tạo Order mới kèm theo tổng tiền và thời gian
            var newOrder = new Order
            {
                OrderId = orderId,
                UserId = userId,
                CreatedAt = DateTime.Now,
                TotalAmount = totalAmount // Đảm bảo Model Order đã có trường này
            };

            _context.Orders.Add(newOrder);

            // 3. Tạo các vé (Tickets) tương ứng
            foreach (var seat in availableSeats)
            {
                seat.IsAvailable = false; // Đánh dấu ghế đã được đặt
                _context.Tickets.Add(new Ticket
                {
                    TicketId = Guid.NewGuid(),
                    OrderId = orderId,
                    SeatId = seat.SeatId
                });
            }

            await _context.SaveChangesAsync();

            // Lưu ý: Việc gọi _statsService ở đây là Singleton để cộng dồn toàn hệ thống
            _statsService.AddTickets(seatIds.Count);

            return orderId;
        }
    }
}