using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Persistence
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(OrderContext).Name);
            }
        }

        public static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>
            {
                new Order() { UserName = "Admin", FirstName = "Roman", LastName = "Hulovatyi", EmailAddress = "roman.hulovatuy@gmail.com", AddressLine = "Add Line", Country = "Ukraine", TotalPrice = 350, CVV = "111", CardName = "Card1", CardNumber = "1234567890123456", Expiration = "05/2025", LastModifiedBy = "Admin", LastModifiedDate = DateTime.Now, State = "", ZipCode = ""  }
            };
        }
    }
}
