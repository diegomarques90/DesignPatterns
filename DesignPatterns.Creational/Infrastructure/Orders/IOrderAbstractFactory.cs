using DesignPatterns.Core.Enums;
using DesignPatterns.Infrastructure.Deliveries;
using DesignPatterns.Infrastructure.Payments;

namespace DesignPatterns.Infrastructure.Orders
{
    public interface IOrderAbstractFactory
    {
        IPaymentService GetPaymentService(PaymentMethod paymentMethod);
        IDeliveryService GetDeliveryService();
    }
}
