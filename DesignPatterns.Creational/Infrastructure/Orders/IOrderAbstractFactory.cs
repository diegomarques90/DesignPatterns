using DesignPatterns.Creational.Core.Enums;
using DesignPatterns.Creational.Infrastructure.Deliveries;
using DesignPatterns.Creational.Infrastructure.Payments;

namespace DesignPatterns.Creational.Infrastructure.Orders
{
    public interface IOrderAbstractFactory
    {
        IPaymentService GetPaymentService(PaymentMethod paymentMethod);
        IDeliveryService GetDeliveryService();
    }
}
