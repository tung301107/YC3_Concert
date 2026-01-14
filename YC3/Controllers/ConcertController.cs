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
        var events = await _context.Events
            .Select(e => new {
                e.Id,
                e.Name,
                e.DateTime,
                e.Description,
                // Chỉ lấy thông tin cần thiết, không lấy Seat hoặc chỉ lấy số lượng
                TotalSeats = e.Seats.Count
            })
            .ToListAsync();

        return Ok(events);
    }

    // 2. SỬA ĐỔI: Quản lý Sự kiện: Tạo mới (Hỗ trợ nhiều Row)
    [HttpPost("events")]
    public async Task<IActionResult> CreateEvent([FromBody] CreateEventDto dto)
    {
        if (dto.Rows == null || !dto.Rows.Any())
        {
            return BadRequest("Danh sách hàng (Rows) không được để trống.");
        }

        try
        {
            var id = await _eventService.CreateEventAsync(dto);
            return Ok(new
            {
                EventId = id,
                Message = $"Sự kiện đã được tạo thành công với {dto.Rows.Count} hàng ghế!"
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Lỗi hệ thống: {ex.Message}");
        }
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

    // 4. Quản lý Đặt vé
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
                CurrentTotalSold = _statsService.GetTotalTickets()
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }


    // 6. Thống kê
    [HttpGet("stats")]
    public IActionResult GetStats() => Ok(new { TotalTicketsSold = _statsService.GetTotalTickets() });
}