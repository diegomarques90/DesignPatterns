using DesignPatterns.Core.Enums;

namespace DesignPatterns.Infrastructure.Payments.Strategies
{
    public interface IPaymentStrategyFactory
    {
        IPaymentStrategy GetStrategy(PaymentMethod paymentMethod);
    }
}
