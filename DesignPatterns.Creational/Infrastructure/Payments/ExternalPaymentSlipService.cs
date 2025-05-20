using DesignPatterns.Application.Models;
using DesignPatterns.Infrastructure.Payments.Interfaces;
using DesignPatterns.Infrastructure.Payments.Models;

namespace DesignPatterns.Infrastructure.Payments
{
    public class ExternalPaymentSlipService : IExternalPaymentSlipService
    {
        public ExternalPaymentSlipModel GeneratePaymentSlip(OrderInputModel model)
        {
            return new ExternalPaymentSlipModel
            {
            };
        }
    }
}
