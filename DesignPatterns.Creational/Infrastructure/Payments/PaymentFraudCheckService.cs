using DesignPatterns.Application.Models;
using DesignPatterns.Infrastructure.Payments.Interfaces;
using DesignPatterns.Infrastructure.Payments.Models;

namespace DesignPatterns.Infrastructure.Payments
{
    public class PaymentFraudCheckService : IPaymentFraudCheckService
    {
        public bool IsFraud(OrderInputModel model)
        {
            return false;
        }

        public bool IsFraudV2(decimal totalAmount, Guid customerId, string customerName, string document)
        {
            return false;
        }

        public bool IsFraudV2UsingCommand(FraudCheckModel command)
        {
            return false;
        }
    }
}
