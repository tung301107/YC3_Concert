namespace YC3.Interfaces
{
    public interface IStatisticsService
    {
        // Thêm dòng này vào
        Task<object> GetDetailedStatsAsync();

        // Các hàm cũ (nếu có)
        void AddTickets(int count);
        int GetTotalTickets();
    }
}