using ProvaPub.Models;

namespace ProvaPub.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<int> CountAsync(int customerId, DateTime baseDate);
    }
}