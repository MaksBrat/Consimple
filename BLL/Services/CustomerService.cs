using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CustomerDTO>> GetBirthdayCustomersAsync(DateTime date)
        {
            var customers = await _unitOfWork.GetRepository<Customer>().GetAllAsync(predicate: x => x.DateOfBirth == date);

            return _mapper.Map<List<CustomerDTO>>(customers);
        }

        public async Task<List<CustomerDTO>> GetRecentCustomersAsync(int days)
        {
            var dateThreshold = DateTime.UtcNow.AddDays(-days);

            var customers = await _unitOfWork.GetRepository<Purchase>().GetGroupedAsync(
                groupingKey: p => p.Customer,
                resultSelector: g => new CustomerDTO
                {
                    Id = g.Key.Id,
                    FullName = g.Key.FullName,
                    LastPurchaseDate = g.Max(p => p.Date)
                },
                predicate: p => p.Date >= dateThreshold
            );

            return customers.ToList();
        }

        public async Task<List<CustomerCategoryDTO>> GetCategoriesByCustomerIdAsync(int customerId)
        {
            var categories = await _unitOfWork.GetRepository<PurchaseItem>().GetGroupedAsync(
                groupingKey: pi => new { pi.Purchase.Customer.FullName, pi.Product.Category },
                resultSelector: g => new CustomerCategoryDTO
                {
                    FullName = g.Key.FullName,
                    Category = g.Key.Category,
                    Quantity = g.Sum(pi => pi.Quantity) 
                },
                predicate: pi => pi.Purchase.CustomerId == customerId
            );

            return categories.ToList();
        }
    }
}
