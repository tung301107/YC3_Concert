using Microsoft.AspNetCore.Mvc;
using YC3.Interfaces;
using YC3.DTO; // Lưu ý trong ảnh của bạn thư mục là DTO (viết hoa)

namespace YC3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
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
    }
}