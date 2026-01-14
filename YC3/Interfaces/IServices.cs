using YC3.Models;

namespace YC3.Interfaces;

public interface IStatisticsService
{
    void AddTickets(int count);
    int GetTotalTickets();
}

public interface IOrderService
{
    Guid PlaceOrder(Guid eventId, List<Guid> seatIds);
}