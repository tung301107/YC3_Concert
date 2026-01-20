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
            // Sử dụng Transaction để đảm bảo nếu lỗi ở bất kỳ bước nào, dữ liệu sẽ không bị sai lệch
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // 1. Lấy thông tin ghế từ DB (Bao gồm cả Giá vé để tính toán)
                var availableSeats = await _context.Seats
                    .Where(s => seatIds.Contains(s.SeatId) && s.IsAvailable && s.EventId == eventId)
                    .ToListAsync();

                // Kiểm tra xem số lượng ghế tìm thấy có khớp với số lượng yêu cầu không
                if (availableSeats.Count != seatIds.Count)
                {
                    throw new Exception("Một số ghế đã bị đặt bởi người khác hoặc không tồn tại.");
                }

                // 2. Tự tính tổng tiền trên Server để đảm bảo an toàn
                decimal totalAmount = availableSeats.Sum(s => s.Price);

                var orderId = Guid.NewGuid();

                // 3. Tạo Order mới
                var newOrder = new Order
                {
                    OrderId = orderId,
                    UserId = userId,
                    CreatedAt = DateTime.UtcNow, // Nên dùng UtcNow để đồng bộ thời gian
                    TotalAmount = totalAmount,
                    Tickets = new List<Ticket>()
                };

                // 4. Xử lý từng ghế: Cập nhật trạng thái và tạo Ticket
                foreach (var seat in availableSeats)
                {
                    // Đánh dấu ghế không còn trống
                    seat.IsAvailable = false;

                    // Tạo bản ghi vé chi tiết
                    newOrder.Tickets.Add(new Ticket
                    {
                        TicketId = Guid.NewGuid(),
                        OrderId = orderId,
                        SeatId = seat.SeatId,
                        PriceAtBooking = seat.Price // Lưu lại giá lúc mua để làm hóa đơn
                    });
                }

                // 5. Lưu toàn bộ vào Database
                _context.Orders.Add(newOrder);
                await _context.SaveChangesAsync();

                // 6. Cập nhật thống kê hệ thống
                _statsService.AddTickets(seatIds.Count);

                // Hoàn tất Transaction
                await transaction.CommitAsync();

                return orderId;
            }
            catch (Exception ex)
            {
                // Nếu có lỗi, hủy bỏ mọi thay đổi trong DB
                await transaction.RollbackAsync();
                throw new Exception($"Đặt vé thất bại: {ex.Message}");
            }
        }
    }
}