using ProvaPub.Interfaces;
using ProvaPub.Services.PaymentMethods;

public class PaymentMethodFactory : IPaymentMethodFactory
{
    public IPaymentMethod CreatePaymentMethod(string paymentMethod)
    {
        switch (paymentMethod.ToLower())
        {
            case "pix":
                return new PixPayment();
            case "creditcard":
                return new CreditCardPayment();
            case "paypal":
                return new PaypalPayment();
            default:
                throw new NotSupportedException("Payment method not supported.");
        }
    }
}
