using DesignPatterns.Core.Enums;

namespace DesignPatterns.Infrastructure.Payments.Interfaces
{
    public interface IPaymentServiceFactory
    {
        IPaymentService GetService(PaymentMethod paymentMethod);
    }
}
