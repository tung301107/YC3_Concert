using Microsoft.AspNetCore.Mvc;
using YC3.DTO;
using YC3.Interfaces;

namespace YC3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService; // 1. Thêm khai báo này

        public AuthController(IAuthService authService, IUserService userService) // 2. Inject vào đây
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto request)
        {
            try
            {
                await _authService.Register(request);
                return Ok(new { success = true, message = "Đăng ký thành công" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto request)
        {
            try
            {
                var data = await _authService.Login(request);
                return Ok(new { success = true, message = "Đăng nhập thành công", data });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        // 3. Giữ lại hàm này ở ĐÂY (Nơi quản lý User)
        [HttpGet("user/{userId}/history")]
        public async Task<IActionResult> GetUserHistory(Guid userId)
        {
            try
            {
                var user = await _userService.GetUserWithHistoryAsync(userId);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}