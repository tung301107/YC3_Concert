using YC3.Data;  
using YC3.Interfaces;
using YC3.Models;
using Microsoft.EntityFrameworkCore; // Quan trọng để dùng được .Include() và .ToListAsync()

namespace YC3.Services;

public class OrderService : IOrderService
{
    private readonly ApplicationDbContext _context;
    private readonly IStatisticsService _statsService;

    public OrderService(ApplicationDbContext context, IStatisticsService statsService)
    {
        _context = context;
        _statsService = statsService;
    }

    public Guid PlaceOrder(Guid eventId, List<Guid> seatIds)
    {
        // Kiểm tra ghế còn trống không trong DB
        var availableSeats = _context.Seats
            .Where(s => seatIds.Contains(s.SeatId) && s.IsAvailable && s.EventId == eventId)
            .ToList();

        if (availableSeats.Count != seatIds.Count)
            throw new Exception("Một số ghế đã bị đặt hoặc không tồn tại.");

        var orderId = Guid.NewGuid();
        foreach (var seat in availableSeats)
        {
            seat.IsAvailable = false; // Đánh dấu đã đặt
            _context.Tickets.Add(new Ticket
            {
                TicketId = Guid.NewGuid(),
                OrderId = orderId,
                SeatId = seat.SeatId
            });
        }

        _context.SaveChanges(); // Lưu vào SQL Server
        _statsService.AddTickets(seatIds.Count); // Cập nhật Singleton

        return orderId;
    }
}