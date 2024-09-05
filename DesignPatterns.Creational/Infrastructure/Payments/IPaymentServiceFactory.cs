using DesignPatterns.Creational.Core.Enums;

namespace DesignPatterns.Creational.Infrastructure.Payments
{
    public interface IPaymentServiceFactory
    {
        IPaymentService GetService(PaymentMethod paymentMethod);
    }
}
