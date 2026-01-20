using Microsoft.EntityFrameworkCore;
using YC3.Data;
using YC3.Interfaces;

namespace YC3.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly ApplicationDbContext _context;

        public StatisticsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<object> GetDetailedStatsAsync()
        {
            // Truy vấn danh sách sự kiện kèm theo tính toán thống kê từ danh sách ghế
            var stats = await _context.Events
                .Select(e => new
                {
                    EventId = e.Id,
                    ConcertName = e.Name,
                    DateTime = e.DateTime,
                    // Đếm số ghế có IsAvailable = false
                    TicketsSold = e.Seats.Count(s => !s.IsAvailable),
                    // Tổng tiền từ các ghế đã bán
                    TotalRevenue = e.Seats.Where(s => !s.IsAvailable).Sum(s => s.Price),
                    TotalSeats = e.TotalSeats,
                    // Tính tỷ lệ lấp đầy
                    OccupancyRate = e.TotalSeats > 0
                        ? (double)e.Seats.Count(s => !s.IsAvailable) / e.TotalSeats * 100
                        : 0
                })
                .ToListAsync();

            return new
            {
                GeneratedAt = DateTime.Now,
                TotalSystemRevenue = stats.Sum(s => s.TotalRevenue),
                TotalSystemTicketsSold = stats.Sum(s => s.TicketsSold),
                DetailsPerConcert = stats
            };
        }

        // Triển khai các phương thức từ Interface để đảm bảo không lỗi biên dịch
        public void AddTickets(int count) { /* Không cần thiết vì đã truy vấn trực tiếp DB */ }

        public int GetTotalTickets() => _context.Seats.Count(s => !s.IsAvailable);
    }
}