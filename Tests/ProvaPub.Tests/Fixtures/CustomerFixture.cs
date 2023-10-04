using ProvaPub.Models;

namespace ProvaPub.Tests.Fixtures
{
    public class CustomerFixture
    {
        public static Customer CreateValidCustomer()
        {
            return new Customer()
            {
                Id = 1,
                Name = "Customer_1",
                Orders = new List<Order>()
            };
        }
    }
}
