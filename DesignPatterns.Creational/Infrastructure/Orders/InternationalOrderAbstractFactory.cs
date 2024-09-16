using DesignPatterns.Creational.Core.Enums;
using DesignPatterns.Creational.Infrastructure.Deliveries;
using DesignPatterns.Creational.Infrastructure.Payments;

namespace DesignPatterns.Creational.Infrastructure.Orders
{
    public class InternationalOrderAbstractFactory : IOrderAbstractFactory
    {
        private readonly InternationalDeliveryService _internationalDeliveryService;
        private readonly IPaymentService _paymentService;

        public InternationalOrderAbstractFactory(InternationalDeliveryService internationalDeliveryService, CreditCardService creditCardService)
        {
            _internationalDeliveryService = internationalDeliveryService;
            _paymentService = creditCardService;
        }

        public IDeliveryService GetDeliveryService() => _internationalDeliveryService;

        public IPaymentService GetPaymentService(PaymentMethod paymentMethod) => _paymentService;
    }
}
