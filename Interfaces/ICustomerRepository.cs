using ProvaPub.Models;

namespace ProvaPub.Interfaces
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Task<Customer?> FindAsync(int customerId);
        Task<int> CountAsync(int customerId);
    }
}
