using ProvaPub.Models;

namespace ProvaPub.Interfaces
{
    public interface ICustomerService : IGenericListService<Customer>
    {
        Task<bool> CanPurchase(int customerId, decimal purchaseValue);
    }
}
