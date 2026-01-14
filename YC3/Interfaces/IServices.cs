using YC3.Models;

namespace YC3.Interfaces;

public interface IStatisticsService
{
    void AddTickets(int count);
    int GetTotalTickets();
}
