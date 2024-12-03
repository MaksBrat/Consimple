namespace BLL.Models
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime? LastPurchaseDate { get; set; }
    }
}
