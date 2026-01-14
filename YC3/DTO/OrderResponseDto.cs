namespace YC3.DTO
{
    public class OrderResponseDto
    {
        public Guid OrderId { get; set; }
        public string CustomerName { get; set; }
        public int TicketCount { get; set; }
        public DateTime BookingTime { get; set; }
    }
}
