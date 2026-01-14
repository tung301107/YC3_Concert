namespace YC3.Models
{
    public class Ticket
    {
        public Guid TicketId { get; set; }
        public Guid OrderId { get; set; }
        public Guid SeatId { get; set; }
    }
}
