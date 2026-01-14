using YC3.DTO;

namespace YC3.Interfaces
{
    public interface IAuthService
    {
        Task<bool> Register(RegisterDto registerDto);
        Task<object> Login(LoginDto loginDto);
    }
}