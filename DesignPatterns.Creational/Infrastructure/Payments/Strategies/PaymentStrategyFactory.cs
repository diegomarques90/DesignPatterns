using DesignPatterns.Core.Enums;

namespace DesignPatterns.Infrastructure.Payments.Strategies
{
    public class PaymentStrategyFactory : IPaymentStrategyFactory
    {
        public IPaymentStrategy GetStrategy(PaymentMethod paymentMethod)
        {
            IPaymentStrategy strategy;

            if (paymentMethod == PaymentMethod.CreditCard)
            {
                strategy = new PaymentCreditCardStrategy();
            } 
            else
            {
                strategy = new PaymentSlipStrategy();
            }

            return strategy;
        }
    }
}
