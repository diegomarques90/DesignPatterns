using DesignPatterns.Application.Models;

namespace DesignPatterns.Infrastructure.Payments.Strategies
{
    public interface IPaymentStrategy
    {
        object Process(OrderInputModel model);
    }
}
