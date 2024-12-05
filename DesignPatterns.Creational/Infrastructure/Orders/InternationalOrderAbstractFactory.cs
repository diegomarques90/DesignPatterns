using DesignPatterns.Core.Enums;
using DesignPatterns.Infrastructure.Deliveries;
using DesignPatterns.Infrastructure.Payments;

namespace DesignPatterns.Infrastructure.Orders
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
