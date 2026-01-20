using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YC3.Data;
using YC3.DTO;
using YC3.Interfaces;

namespace YC3.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConcertController : ControllerBase
{
    private readonly IEventService _eventService;
    private readonly IStatisticsService _statsService; // Phải là IStatisticsService
    private readonly ILoginTracker _loginTracker;      // Singleton đếm lượt đăng nhập
    private readonly ApplicationDbContext _context;

    public ConcertController(
        IEventService eventService,
        IStatisticsService statsService,
        ILoginTracker loginTracker,
        ApplicationDbContext context)
    {
        _eventService = eventService;
        _statsService = statsService;
        _loginTracker = loginTracker;
        _context = context;
    }

    // 1. Lấy danh sách tất cả sự kiện
    [HttpGet("events")]
    public async Task<IActionResult> GetEvents()
    {
        var events = await _context.Events
            .Select(e => new {
                e.Id,
                e.Name,
                e.DateTime,
                e.Description,
                TotalSeats = e.TotalSeats,
                AvailableSeats = e.Seats.Count(s => s.IsAvailable)
            })
            .ToListAsync();

        return Ok(events);
    }

    // 2. Tạo sự kiện mới
    [HttpPost("events")]
    public async Task<IActionResult> CreateEvent([FromBody] CreateEventDto dto)
    {
        if (dto.Rows == null || !dto.Rows.Any())
            return BadRequest("Danh sách hàng không được để trống.");

        try
        {
            var id = await _eventService.CreateEventAsync(dto);
            return Ok(new { EventId = id, Message = "Tạo sự kiện thành công." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Lỗi: {ex.Message}");
        }
    }

    // 3. Cập nhật sự kiện
    [HttpPut("events/{id}")]
    public async Task<IActionResult> UpdateEvent(Guid id, [FromBody] CreateEventDto dto)
    {
        var result = await _eventService.UpdateEventAsync(id, dto);
        if (!result) return NotFound("Không tìm thấy sự kiện.");
        return Ok("Cập nhật thành công.");
    }

    // 4. Hiển thị ghế trống
    [HttpGet("events/{eventId}/available-seats")]
    public async Task<IActionResult> GetAvailableSeats(Guid eventId)
    {
        var seats = await _context.Seats
            .Where(s => s.EventId == eventId && s.IsAvailable)
            .OrderBy(s => s.RowName).ThenBy(s => s.SeatNumber)
            .ToListAsync();
        return Ok(seats);
    }

    // 5. Thống kê (Kết hợp Scoped Stats và Singleton LoginTracker)
    [HttpGet("stats")]
    public async Task<IActionResult> GetStats()
    {
        // Lấy doanh thu từ Database (Scoped Service)
        var stats = await _statsService.GetDetailedStatsAsync();

        // Lấy số lượt login từ RAM (Singleton Service)
        var totalLogins = _loginTracker.GetTotalLogins();

        return Ok(new
        {
            TotalLoginsOnSystem = totalLogins, // Số lượt đăng nhập [Singleton]
            ConcertDetails = stats            // Dữ liệu concert [Scoped]
        });
    }
}