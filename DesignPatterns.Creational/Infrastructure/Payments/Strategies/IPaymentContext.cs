using DesignPatterns.Application.Models;

namespace DesignPatterns.Infrastructure.Payments.Strategies
{
    public interface IPaymentContext
    {
        object Process(OrderInputModel model);
        IPaymentContext SetStrategy(IPaymentStrategy strategy);
    }
}
