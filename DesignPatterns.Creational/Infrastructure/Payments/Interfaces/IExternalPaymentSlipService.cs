using DesignPatterns.Application.Models;
using DesignPatterns.Infrastructure.Payments.Models;

namespace DesignPatterns.Infrastructure.Payments.Interfaces
{
    public interface IExternalPaymentSlipService
    {
        ExternalPaymentSlipModel GeneratePaymentSlip(OrderInputModel model);
    }
}
