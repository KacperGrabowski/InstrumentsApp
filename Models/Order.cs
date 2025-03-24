namespace InstrumentsApp.Models {
    public class Order {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public List<ItemEntry> Items { get; set; } = [];
    }
}
