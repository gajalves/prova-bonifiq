using ProvaPub.Interfaces;
using ProvaPub.Models;

namespace ProvaPub.Services.PaymentMethods
{
    public class PaypalPayment : IPaymentMethod
    {
        public Task<Order> PayOrder(decimal paymentValue, int customerId)
        {
            Console.WriteLine("PaypalPayment");
            return Task.FromResult(new Order
            {
                Value = paymentValue,
            });
        }
    }
}
