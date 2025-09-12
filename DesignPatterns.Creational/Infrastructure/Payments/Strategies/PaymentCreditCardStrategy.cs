using DesignPatterns.Application.Models;

namespace DesignPatterns.Infrastructure.Payments.Strategies
{
    public class PaymentCreditCardStrategy : IPaymentStrategy
    {
        public object Process(OrderInputModel model)
        {
            return "Payment with credit card has been processed.";
        }
    }
}
