using DesignPatterns.Core.Enums;
using DesignPatterns.Infrastructure.Deliveries;
using DesignPatterns.Infrastructure.Payments.Interfaces;

namespace DesignPatterns.Infrastructure.Orders
{
    public interface IOrderAbstractFactory
    {
        IPaymentService GetPaymentService(PaymentMethod paymentMethod);
        IDeliveryService GetDeliveryService();
    }
}
