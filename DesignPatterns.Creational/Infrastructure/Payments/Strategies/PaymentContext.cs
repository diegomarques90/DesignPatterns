using DesignPatterns.Application.Models;

namespace DesignPatterns.Infrastructure.Payments.Strategies
{
    public class PaymentContext : IPaymentContext
    {
        private IPaymentStrategy _strategy;
        public object Process(OrderInputModel model)
        {
            return _strategy.Process(model);
        }

        public IPaymentContext SetStrategy(IPaymentStrategy strategy)
        {
            _strategy = strategy;
            return this;
        }
    }
}
