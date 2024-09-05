using DesignPatterns.Creational.Application.Models;

namespace DesignPatterns.Creational.Infrastructure.Payments
{
    public interface IPaymentService
    {
        object Process(OrderInputModel inputModel);
    }
}
