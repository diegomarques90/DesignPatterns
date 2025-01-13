using DesignPatterns.Application.Models;
using DesignPatterns.Infrastructure.Integrations;

namespace DesignPatterns.Infrastructure.Payments.Decorators
{
    public class PaymentServiceDecorator : IPaymentService
    {
        private readonly IPaymentService _paymentService;
        private readonly ICoreCrmIntegrationService _crmService;

        public PaymentServiceDecorator(IPaymentService paymentService, ICoreCrmIntegrationService crmService)
        {
            _paymentService = paymentService;
            _crmService = crmService;
        }

        public object Process(OrderInputModel inputModel)
        {
            var result = _paymentService.Process(inputModel);
            _crmService.Sync(inputModel);

            return result;
        }
    }
}
