using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YC3.Interfaces;
using YC3.Data;
using YC3.DTO;

namespace YC3.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConcertController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly IStatisticsService _statsService;
    private readonly IEventService _eventService;
    private readonly IUserService _userService;
    private readonly ApplicationDbContext _context;

    // Dependency Injection: Hệ thống tự động bơm các Service vào thông qua Constructor
    public ConcertController(
        IOrderService orderService,
        IStatisticsService statsService,
        IEventService eventService,
        IUserService userService,
        ApplicationDbContext context)
    {
        _orderService = orderService;
        _statsService = statsService;
        _eventService = eventService;
        _userService = userService;
        _context = context;
    }

    // 1. Quản lý Sự kiện: Lấy danh sách
    [HttpGet("events")]
    public async Task<IActionResult> GetEvents()
    {
        var events = await _eventService.GetAllEventsAsync();
        return Ok(events);
    }

    // 2. Quản lý Sự kiện: Tạo mới (Tự động sinh ghế)
    [HttpPost("events")]
    public async Task<IActionResult> CreateEvent([FromBody] CreateEventDto dto)
    {
        var id = await _eventService.CreateEventAsync(dto);
        return Ok(new { EventId = id, Message = "Sự kiện và sơ đồ ghế đã được tạo thành công!" });
    }

    // 3. Quản lý Ghế: Hiển thị ghế trống
    [HttpGet("events/{eventId}/available-seats")]
    public async Task<IActionResult> GetAvailableSeats(Guid eventId)
    {
        var seats = await _context.Seats
            .Where(s => s.EventId == eventId && s.IsAvailable)
            .ToListAsync();
        return Ok(seats);
    }

    // 4. Quản lý Đặt vé: Đặt nhiều vé trong một đơn hàng
    [HttpPost("book")]
    public async Task<IActionResult> BookTickets([FromBody] BookingRequestDto request)
    {
        try
        {
            var orderId = await _orderService.PlaceOrderAsync(request.UserId, request.EventId, request.SelectedSeatIds);
            return Ok(new
            {
                OrderId = orderId,
                Message = "Đặt vé thành công!",
                CurrentTotalSold = _statsService.GetTotalTickets() // Kiểm tra Singleton
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    // 5. Quản lý Khách hàng: Xem lịch sử
    [HttpGet("user/{userId}/history")]
    public async Task<IActionResult> GetUserHistory(Guid userId)
    {
        var user = await _userService.GetUserWithHistoryAsync(userId);
        return Ok(user);
    }

    // 6. Thống kê: Sử dụng Singleton Service
    [HttpGet("stats")]
    public IActionResult GetStats() => Ok(new { TotalTicketsSold = _statsService.GetTotalTickets() });
}