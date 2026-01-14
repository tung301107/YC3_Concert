namespace YC3.DTO
{
    public class CreateEventDto
    {
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        public List<string> Rows { get; set; } // Ví dụ: ["A", "B", "C"]
        public int SeatsPerRow { get; set; }   // Ví dụ: 10
    }
}
