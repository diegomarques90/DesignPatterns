using DesignPatterns.Application.Models;

namespace DesignPatterns.Infrastructure.Payments.Interfaces
{
    public interface IPaymentService
    {
        object Process(OrderInputModel inputModel);
    }
}
