using System.Net.Sockets;

namespace YC3.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Thời gian đặt vé
        public decimal TotalAmount { get; set; } // Tổng tiền của đơn hàng
        public List<Ticket> Tickets { get; set; } = new();
    }
}
