using YC3.Models;

public class User
{
    public Guid UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    // Thêm dòng này để UserService.cs không còn lỗi đỏ
    public List<Order> Orders { get; set; } = new();
}