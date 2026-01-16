namespace YC3.DTO
{
    // File: DTO/OrderResponseDto.cs
    public class OrderResponseDto
    {
        public Guid OrderId { get; set; }
        public string CustomerName { get; set; } = string.Empty; // Khởi tạo giá trị mặc định
        public int TicketCount { get; set; }
        public DateTime BookingTime { get; set; }
        public decimal TotalAmount { get; set; } // Nên thêm vào để trả về cho Client
    }
}
