using System.ComponentModel.DataAnnotations;

namespace YC3.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }

        [Required]
        public string Username { get; set; } = string.Empty; // Cần thiết để đăng nhập

        [Required]
        public string PasswordHash { get; set; } = string.Empty; // Lưu mật khẩu đã mã hóa

        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        // Phân quyền (Tùy chọn: giúp bạn phân biệt Admin và Khách hàng)
        public string Role { get; set; } = "Customer";

        public List<Order> Orders { get; set; } = new();
    }
}