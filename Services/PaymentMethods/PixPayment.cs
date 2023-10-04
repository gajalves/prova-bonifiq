using ProvaPub.Interfaces;
using ProvaPub.Models;

namespace ProvaPub.Services.PaymentMethods
{
    public class PixPayment : IPaymentMethod
    {
        public Task<Order> PayOrder(decimal paymentValue, int customerId)
        {
            Console.WriteLine("PixPayment");
            return Task.FromResult(new Order
            {
                Value = paymentValue,
            });
        }
    }
}
