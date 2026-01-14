using System.ComponentModel.DataAnnotations;

namespace YC3.Models
{
    public class ConcertEvent
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime DateTime { get; set; }
        public string Description { get; set; } = string.Empty;
        public int TotalSeats { get; set; }

        // Mối quan hệ 1-n: Một sự kiện có nhiều ghế
        public List<Seat> Seats { get; set; } = new();
    }
}
