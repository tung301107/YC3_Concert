using Microsoft.AspNetCore.Mvc;
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
        private readonly ILoginTracker _loginTracker; // Inject Singleton

        public AuthController(IAuthService authService, IUserService userService, ILoginTracker loginTracker)
        {
            _authService = authService;
            _userService = userService;
            _loginTracker = loginTracker;
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

                // TÁC DỤNG SINGLETON: Mỗi lần login thành công, cộng thêm 1 vào biến tổng trong RAM
                _loginTracker.TrackLogin();

                return Ok(new { success = true, message = "Đăng nhập thành công", data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpGet("my-history/{userId}")]
        public async Task<IActionResult> GetMyHistory(Guid userId)
        {
            try
            {
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