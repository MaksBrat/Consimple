using API.Controllers.Base;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CustomerController : BaseController
    {   
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// Retrieves a list of customers who have their birthday on the specified date.
        /// </summary>
        /// <param name="date">The date to check for customer birthdays.</param>
        /// <returns>An HTTP response containing a list of customers (ID, FullName) with birthdays on the specified date.</returns>
        [HttpGet("birthdays")]
        public async Task<IActionResult> GetBirthdayClients([FromQuery] DateTime date)
        {
            var customers = await _customerService.GetBirthdayCustomersAsync(date);
            return Ok(customers);
        }

        /// <summary>
        /// Retrieves a list of customers who made purchases in the last specified number of days.
        /// </summary>
        /// <param name="days">The number of days to look back for recent purchases.</param>
        /// <returns>
        /// An HTTP response containing a list of customers (ID, FullName) and the date of their last purchase.
        /// </returns>
        [HttpGet("recent-purchases")]
        public async Task<IActionResult> GetRecentBuyers([FromQuery] int days)
        {
            var customers = await _customerService.GetRecentCustomersAsync(days);
            return Ok(customers);
        }

        /// <summary>
        /// Retrieves a list of product categories purchased by the specified customer.
        /// </summary>
        /// <param name="customerId">The ID of the customer to retrieve category data for.</param>
        /// <returns>
        /// An HTTP response containing a list of categories purchased by the customer, along with the quantity of products in each category.
        /// </returns>
        [HttpGet("customer-category")]
        public async Task<IActionResult> GetCategoriesByCustomerIdAsync([FromQuery] int customerId)
        {
            var customers = await _customerService.GetCategoriesByCustomerIdAsync(customerId);
            return Ok(customers);
        }
    }
}
