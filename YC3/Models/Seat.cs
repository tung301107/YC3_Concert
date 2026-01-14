using System.ComponentModel.DataAnnotations;

namespace YC3.Models
{
    public class Seat
    {
        [Key]
        public Guid SeatId { get; set; }
        public string RowName { get; set; } = string.Empty; // A, B, C...
        public int SeatNumber { get; set; } // 1, 2, 3...
        public bool IsAvailable { get; set; } = true;

        // Khóa ngoại liên kết với Event
        public Guid EventId { get; set; }
        public ConcertEvent? Event { get; set; }
    }
}
