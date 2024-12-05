using DesignPatterns.Application.Models;

namespace DesignPatterns.Infrastructure.Payments
{
    public class CreditCardService : IPaymentService
    {
        public object Process(OrderInputModel inputModel)
        {
            return "Transação processada e aprovada.";
        }
    }
}
