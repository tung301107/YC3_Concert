using YC3.Interfaces;
using YC3.Data;
namespace YC3.Services;

public class StatisticsService : IStatisticsService
{
    // Dictionary để lưu: TicketId -> Số lần được truy vấn (ví dụ)
    private readonly Dictionary<Guid, int> _ticketAccessCount = new();
    private int _totalTicketsSold = 0;

    public void AddTickets(int count) => _totalTicketsSold += count;
    public int GetTotalTickets() => _totalTicketsSold;

    public void IncrementTicketView(Guid ticketId)
    {
        if (!_ticketAccessCount.ContainsKey(ticketId))
            _ticketAccessCount[ticketId] = 0;
        _ticketAccessCount[ticketId]++;
    }
}