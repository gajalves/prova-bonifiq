using Microsoft.EntityFrameworkCore;
using ProvaPub.Interfaces;
using ProvaPub.Models;

namespace ProvaPub.Repository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        private readonly TestDbContext _ctx;

        public CustomerRepository(TestDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<int> CountAsync(int customerId)
        {
            return await _ctx.Customers.CountAsync(s => s.Id == customerId && s.Orders.Any());
        }

        public async Task<Customer?> FindAsync(int customerId)
        {
            return await _ctx.Customers.FindAsync(customerId);
        }
    }
}
