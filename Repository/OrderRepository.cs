using Microsoft.EntityFrameworkCore;
using ProvaPub.Interfaces;
using ProvaPub.Models;

namespace ProvaPub.Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly TestDbContext _ctx;

        public OrderRepository(TestDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<int> CountAsync(int customerId, DateTime baseDate)
        {
            return await _ctx.Orders.CountAsync(s => s.CustomerId == customerId && s.OrderDate >= baseDate);
        }
    }
}
