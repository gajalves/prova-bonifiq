using ProvaPub.Interfaces;
using ProvaPub.Models;

namespace ProvaPub.Services.PaymentMethods
{
    public class CreditCardPayment : IPaymentMethod
    {
        public Task<Order> PayOrder(decimal paymentValue, int customerId)
        {
            Console.WriteLine("CreditCardPayment");
            return Task.FromResult(new Order
            {
                Value = paymentValue,
            });
        }
    }
}
