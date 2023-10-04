using ProvaPub.Interfaces;
using ProvaPub.Models;

namespace ProvaPub.Services
{
    public class OrderService : IOrderService
    {
        private readonly IPaymentMethodFactory _paymentMethodFactory;

        public OrderService(IPaymentMethodFactory paymentMethodFactory)
        {
            _paymentMethodFactory = paymentMethodFactory;
        }

        public async Task<Order> PayOrder(string paymentMethod, decimal paymentValue, int customerId)
        {
            var paymentMethodStrategy = _paymentMethodFactory.CreatePaymentMethod(paymentMethod);

            return await paymentMethodStrategy.PayOrder(paymentValue, customerId);
        }
    }
}
