namespace YC3.Models
{
    public class Seat
    {
        public Guid SeatId { get; set; }
        public string RowName { get; set; }
        public int SeatNumber { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Price { get; set; } // <-- QUAN TRỌNG: Thêm trường này
        public Guid EventId { get; set; }
    }
}