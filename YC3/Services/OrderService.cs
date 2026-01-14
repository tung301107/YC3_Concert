using Microsoft.EntityFrameworkCore;
using YC3.Data;
using YC3.Interfaces;
using YC3.Models;

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
            // 1. Kiểm tra danh sách ghế trống bằng cách truy vấn database bất đồng bộ
            var availableSeats = await _context.Seats
                .Where(s => seatIds.Contains(s.SeatId) && s.IsAvailable && s.EventId == eventId)
                .ToListAsync();

            // Kiểm tra nếu số lượng ghế tìm thấy không khớp với số lượng ghế yêu cầu
            if (availableSeats.Count != seatIds.Count)
            {
                throw new Exception("Một số ghế đã bị đặt hoặc không tồn tại.");
            }

            var orderId = Guid.NewGuid();

            // 2. Tạo bản ghi Order mới (Sử dụng CreatedAt để khớp với Model Order.cs của bạn)
            var newOrder = new Order
            {
                OrderId = orderId,
                UserId = userId,
                CreatedAt = DateTime.Now // Đã sửa từ OrderDate thành CreatedAt để hết lỗi CS0117
            };

            _context.Orders.Add(newOrder);

            // 3. Cập nhật trạng thái từng ghế và tạo vé (Ticket) tương ứng
            foreach (var seat in availableSeats)
            {
                seat.IsAvailable = false; // Đánh dấu ghế không còn trống

                _context.Tickets.Add(new Ticket
                {
                    TicketId = Guid.NewGuid(),
                    OrderId = orderId,
                    SeatId = seat.SeatId
                });
            }

            // 4. Lưu tất cả thay đổi vào SQL Server trong một giao dịch duy nhất
            await _context.SaveChangesAsync();

            // 5. Cập nhật thống kê vào dịch vụ Singleton
            _statsService.AddTickets(seatIds.Count);

            return orderId;
        }
    }
}