using DAL;
using DAL.Entities;

namespace API.Infrastructure
{
    public class DbInitializer
    {
        public async static Task Seed(IApplicationBuilder applicationBuilder)
        {
            using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();

            var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDBContext>();

            context.Database.EnsureCreated();

            if (context.Customers.Any())
            {
                return;
            }

            var customers = new List<Customer>
            {
                new Customer
                {
                    FullName = "John Doe",
                    DateOfBirth = new DateTime(1990, 5, 15),
                    RegistrationDate = DateTime.UtcNow.AddYears(-2)
                },
                new Customer
                {
                    FullName = "Jane Smith",
                    DateOfBirth = new DateTime(1985, 10, 22),
                    RegistrationDate = DateTime.UtcNow.AddYears(-1)
                }
            };

            context.Customers.AddRange(customers);
            await context.SaveChangesAsync();

            var products = new List<Product>
            {
                new Product { Name = "Laptop", Category = "Electronics", SKU = "ELEC001", Price = 999.99M },
                new Product { Name = "Smartphone", Category = "Electronics", SKU = "ELEC002", Price = 699.99M },
                new Product { Name = "Desk Chair", Category = "Furniture", SKU = "FURN001", Price = 149.99M }
            };

            context.Products.AddRange(products);
            await context.SaveChangesAsync();

            var purchases = new List<Purchase>
            {
                new Purchase
                {
                    Date = DateTime.UtcNow.AddDays(-10),
                    TotalAmount = 1149.98M,
                    CustomerId = customers[0].Id,
                    Items = new List<PurchaseItem>
                    {
                        new PurchaseItem { Product = products[0], Quantity = 1 },
                        new PurchaseItem { Product = products[2], Quantity = 1 }
                    }
                },
                new Purchase
                {
                    Date = DateTime.UtcNow.AddDays(-5),
                    TotalAmount = 699.99M,
                    CustomerId = customers[1].Id,
                    Items = new List<PurchaseItem>
                    {
                        new PurchaseItem { Product = products[1], Quantity = 2 }
                    }
                },
                new Purchase
                {
                    Date = DateTime.UtcNow.AddDays(-7),
                    TotalAmount = 163.99M,
                    CustomerId = customers[1].Id,
                    Items = new List<PurchaseItem>
                    {
                        new PurchaseItem { Product = products[2], Quantity = 5 }
                    }
                },
                new Purchase
                {
                    Date = DateTime.UtcNow.AddDays(-20),
                    TotalAmount = 999.99M,
                    CustomerId = customers[1].Id,
                    Items = new List<PurchaseItem>
                    {
                        new PurchaseItem { Product = products[0], Quantity = 3 }
                    }
                },
                new Purchase
                {
                    Date = DateTime.UtcNow.AddDays(-2),
                    TotalAmount = 332.99M,
                    CustomerId = customers[1].Id,
                    Items = new List<PurchaseItem>
                    {
                        new PurchaseItem { Product = products[0], Quantity = 4 }
                    }
                }
            };

            context.Purchases.AddRange(purchases);
            await context.SaveChangesAsync();
        }
    }
}
