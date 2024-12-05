using DesignPatterns.Application.Models;

namespace DesignPatterns.Infrastructure.Payments
{
    public interface IPaymentService
    {
        object Process(OrderInputModel inputModel);
    }
}
