using ProvaPub.Models;

namespace ProvaPub.Interfaces
{
    public interface IPaymentMethod
    {
        Task<Order> PayOrder(decimal paymentValue, int customerId);
    }
}
