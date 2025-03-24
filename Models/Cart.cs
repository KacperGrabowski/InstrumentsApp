namespace InstrumentsApp.Models {
    public class Cart {
        public int Id { get; set; }
        public required int UserId { get; set; }
        public List<ItemEntry> Items { get; set; } = [];
    }
}
