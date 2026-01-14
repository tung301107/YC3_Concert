namespace YC3.DTO
{
    public class BookingRequestDto
    {
        public Guid UserId { get; set; }
        public Guid EventId { get; set; }
        public List<Guid> SelectedSeatIds { get; set; }
    }
}
