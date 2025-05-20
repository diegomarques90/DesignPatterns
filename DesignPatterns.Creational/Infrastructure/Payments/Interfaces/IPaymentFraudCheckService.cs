using DesignPatterns.Application.Models;
using DesignPatterns.Infrastructure.Payments.Models;

namespace DesignPatterns.Infrastructure.Payments.Interfaces
{
    public interface IPaymentFraudCheckService
    {
        bool IsFraud(OrderInputModel model);
        bool IsFraudV2(decimal totalAmount, Guid customerId, string customerName, string document);
        bool IsFraudV2UsingCommand(FraudCheckModel command);
    }
}
