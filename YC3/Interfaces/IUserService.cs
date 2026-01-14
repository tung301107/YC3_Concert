using YC3.Models;

namespace YC3.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserWithHistoryAsync(Guid userId);
    }
}
