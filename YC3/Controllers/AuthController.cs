using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using YC3.Interfaces;
using YC3.DTO;

namespace YC3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public AuthController(IAuthService authService, IUserService userService)
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
                var result = await _authService.Login(request);
                return Ok(new { success = true, message = "Đăng nhập thành công", data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        // Chức năng tự động lấy UserId từ Token để xem lịch sử
        [Authorize]
        [HttpGet("my-history")]
        public async Task<IActionResult> GetMyHistory()
        {
            try
            {
                // Lấy UserId từ Claims trong Token
                var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userIdStr)) return Unauthorized();

                var userId = Guid.Parse(userIdStr);
                var history = await _userService.GetUserWithHistoryAsync(userId);

                return Ok(history);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}