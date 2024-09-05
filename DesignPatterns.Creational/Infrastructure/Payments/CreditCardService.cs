using DesignPatterns.Creational.Application.Models;

namespace DesignPatterns.Creational.Infrastructure.Payments
{
    public class CreditCardService : IPaymentService
    {
        public object Process(OrderInputModel inputModel)
        {
            return "Transação processada e aprovada.";
        }
    }
}
