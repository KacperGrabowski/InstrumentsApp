namespace InstrumentsApp.Models {
    public class ItemEntry {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public virtual Cart? Cart { get; set; }
        public virtual Order? Order { get; set; }
        public required virtual Instrument Instrument { get; set; }
    }
}
