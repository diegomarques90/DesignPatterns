using DesignPatterns.Creational.Application.Models;

namespace DesignPatterns.Creational.Infrastructure.Payments
{
    public class PaymentSlipService : IPaymentService
    {
        public object Process(OrderInputModel inputModel)
        {
            return "Dados do boleto.";
        }
    }
}
