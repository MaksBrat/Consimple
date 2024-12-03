namespace DAL.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime RegistrationDate { get; set; }

        public List<Purchase> Purchases { get; set; }
    }
}