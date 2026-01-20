namespace YC3.DTO
{
    public class CreateEventDto
    {
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        public List<string> Rows { get; set; }
        public int SeatsPerRow { get; set; }
        public decimal Price { get; set; } // <-- Người dùng nhập giá khi tạo Event
    }
}