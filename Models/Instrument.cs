namespace InstrumentsApp.Models {
    public class Instrument {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public required string ImagePath { get; set; }
        public int Stock { get; set; }
    }
}
