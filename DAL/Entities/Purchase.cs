namespace DAL.Entities
{
    public class Purchase
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
  
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<PurchaseItem> Items { get; set; }
    }
}
