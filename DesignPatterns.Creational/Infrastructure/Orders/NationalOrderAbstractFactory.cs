using DesignPatterns.Creational.Core.Enums;
using DesignPatterns.Creational.Infrastructure.Deliveries;
using DesignPatterns.Creational.Infrastructure.Payments;

namespace DesignPatterns.Creational.Infrastructure.Orders
{
    public class NationalOrderAbstractFactory : IOrderAbstractFactory
    {
        private readonly NationalDeliveryService _nationalDeliveryService;

        private readonly IPaymentServiceFactory _paymentServiceFactory;

        public NationalOrderAbstractFactory(NationalDeliveryService nationalDeliveryService, IPaymentServiceFactory paymentServiceFactory)
        {
            _nationalDeliveryService = nationalDeliveryService;
            _paymentServiceFactory = paymentServiceFactory;
        }

        public IDeliveryService GetDeliveryService() => _nationalDeliveryService;

        public IPaymentService GetPaymentService(PaymentMethod paymentMethod) => _paymentServiceFactory.GetService(paymentMethod);
    }
}
