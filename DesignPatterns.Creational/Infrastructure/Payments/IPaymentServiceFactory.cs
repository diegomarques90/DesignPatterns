using DesignPatterns.Core.Enums;

namespace DesignPatterns.Infrastructure.Payments
{
    public interface IPaymentServiceFactory
    {
        IPaymentService GetService(PaymentMethod paymentMethod);
    }
}
