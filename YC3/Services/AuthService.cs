using Microsoft.EntityFrameworkCore;
using YC3.Models;
using YC3.Data; // Để nhận diện ApplicationDbContext
using YC3.DTO;  // Để nhận diện LoginDto và RegisterDto
using YC3.Interfaces;
using BCrypt.Net; // Cần cài package BCrypt.Net-Next

namespace YC3.Services
{
    public class AuthService : IAuthService
    {
        // Đã đổi từ MyDbContext thành ApplicationDbContext theo đúng ảnh của bạn
        private readonly ApplicationDbContext _context;

        public AuthService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Register(RegisterDto dto)
        {
            if (await _context.Users.AnyAsync(u => u.Username == dto.Username))
                throw new Exception("Tên đăng nhập đã tồn tại.");

            var user = new User
            {
                UserId = Guid.NewGuid(),
                Username = dto.Username,
                // Mã hóa mật khẩu
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone
            };

            _context.Users.Add(user);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<object> Login(LoginDto dto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == dto.Username);

            // Kiểm tra mật khẩu bằng hàm Verify
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            {
                throw new Exception("Tên đăng nhập hoặc mật khẩu không chính xác.");
            }

            return new
            {
                user.UserId,
                user.Username,
                user.Name,
                user.Email
            };
        }
    }
}