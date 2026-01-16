using System.ComponentModel.DataAnnotations;

namespace YC3.Models
{
    public class Seat
    {
        [Key]
        public Guid SeatId { get; set; }
        public string RowName { get; set; } = string.Empty;
        public int SeatNumber { get; set; }
        public bool IsAvailable { get; set; } = true;
        public decimal Price { get; set; } // Thêm giá cho từng ghế
        public Guid EventId { get; set; }
    }
}
