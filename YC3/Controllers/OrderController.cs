using Microsoft.AspNetCore.Mvc;
using YC3.Data;
using YC3.DTO;
using YC3.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace YC3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IStatisticsService _statsService;
        private readonly IPriceCalculator _priceCalculator; // Inject Transient
        private readonly ApplicationDbContext _context;

        public OrderController(
            IOrderService orderService,
            IStatisticsService statsService,
            IPriceCalculator priceCalculator,
            ApplicationDbContext context)
        {
            _orderService = orderService;
            _statsService = statsService;
            _priceCalculator = priceCalculator;
            _context = context;
        }

        [HttpPost("book")]
        public async Task<IActionResult> BookTickets([FromBody] BookingRequestDto request)
        {
            try
            {
                // 1. Lấy thông tin các ghế để tính tiền
                var selectedSeats = await _context.Seats
                    .Where(s => request.SelectedSeatIds.Contains(s.SeatId) && s.IsAvailable)
                    .ToListAsync();

                if (selectedSeats.Count != request.SelectedSeatIds.Count)
                    return BadRequest("Một số ghế đã bị đặt hoặc không tồn tại.");

                // 2. Sử dụng Transient Service để tính tổng tiền
                var totalAmount = _priceCalculator.CalculateTotal(selectedSeats.Select(s => s.Price));

                // 3. Thực hiện đặt đơn hàng qua Service
                // Thực hiện đặt đơn hàng qua Service (Bỏ tham số totalAmount)
                var orderId = await _orderService.PlaceOrderAsync(
                    request.UserId,
                    request.EventId,
                    request.SelectedSeatIds
                );

                // 4. Cập nhật thống kê (Singleton)
                _statsService.AddTickets(selectedSeats.Count);

                return Ok(new
                {
                    OrderId = orderId,
                    BookingTime = DateTime.Now,
                    TotalAmount = totalAmount,
                    TicketCount = selectedSeats.Count,
                    Message = "Đặt vé thành công!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
