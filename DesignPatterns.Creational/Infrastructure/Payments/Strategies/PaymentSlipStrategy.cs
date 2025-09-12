using DesignPatterns.Application.Models;

namespace DesignPatterns.Infrastructure.Payments.Strategies
{
    public class PaymentSlipStrategy : IPaymentStrategy
    {
        public object Process(OrderInputModel model)
        {
            return "Payment with payment slip has been processed.";
        }
    }
}
