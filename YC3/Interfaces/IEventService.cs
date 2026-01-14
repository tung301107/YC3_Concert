using YC3.DTO;
using YC3.Models;

namespace YC3.Interfaces
{
    public interface IEventService
    {
        Task<Guid> CreateEventAsync(CreateEventDto dto);
        Task<bool> UpdateEventAsync(Guid id, CreateEventDto dto);
        Task<List<ConcertEvent>> GetAllEventsAsync();
    }
}
