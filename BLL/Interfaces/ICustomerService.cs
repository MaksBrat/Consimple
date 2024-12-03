using BLL.Models;

namespace BLL.Interfaces
{
    public interface ICustomerService
    {
        public Task<List<CustomerDTO>> GetBirthdayCustomersAsync(DateTime date);
        public Task<List<CustomerDTO>> GetRecentCustomersAsync(int days);
        public Task<List<CustomerCategoryDTO>> GetCategoriesByCustomerIdAsync(int customerId);
    }
}