using DesignPatterns.Application.Models;
using DesignPatterns.Core.Enums;

namespace DesignPatterns.Infrastructure.Payments.Interfaces
{
    public interface IPaymentMethodsFactory
    {
        PaymentMethodViewModel GetPaymentMethod(PaymentMethod paymentMethod);
        void AddPaymentMethod(PaymentMethod key, PaymentMethodViewModel value);
        void RemovePaymentMethod(PaymentMethod key);
    }
}
