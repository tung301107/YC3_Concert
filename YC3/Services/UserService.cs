using YC3.Data;
using YC3.Interfaces;
using YC3.Models;
using Microsoft.EntityFrameworkCore;

namespace YC3.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context) => _context = context;

        public async Task<User> GetUserWithHistoryAsync(Guid userId)
        {
            // Lấy thông tin User kèm theo danh sách Đơn hàng và Vé đã mua
            return await _context.Users
                .Include(u => u.Orders)
                    .ThenInclude(o => o.Tickets)
                .FirstOrDefaultAsync(u => u.UserId == userId) ?? throw new Exception("User not found");
        }
    }
}
