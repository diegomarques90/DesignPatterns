using DesignPatterns.Application.Models;
using DesignPatterns.Core.Enums;
using DesignPatterns.Infrastructure.Payments.Interfaces;

namespace DesignPatterns.Infrastructure.Payments
{
    public class PaymentMethodsFactory : IPaymentMethodsFactory
    {
        private Dictionary<PaymentMethod, PaymentMethodViewModel> _paymentMethods;

        public PaymentMethodsFactory()
        {
            _paymentMethods = new Dictionary<PaymentMethod, PaymentMethodViewModel>
            {
                { PaymentMethod.CreditCard, new PaymentMethodViewModel("Sobre o Cartão de Crédito.", 1, null) },
                { PaymentMethod.PaymentSlip, new PaymentMethodViewModel("Sobre o Boleto.", 10, 1000) },
                { PaymentMethod.PayPal, new PaymentMethodViewModel("Sobre o PayPal.", 16.5m, null) }
            };
        }

        public PaymentMethodViewModel GetPaymentMethod(PaymentMethod paymentMethod)
        {
            if (!_paymentMethods.ContainsKey(paymentMethod))
                throw new Exception("A forma de pagamento já foi excluída ou não foi cadastrada.");

            return _paymentMethods[paymentMethod];
        }

        public void AddPaymentMethod(PaymentMethod key, PaymentMethodViewModel value)
        {
            if (_paymentMethods.ContainsKey(key))
                throw new Exception("A forma de pagamento já existe.");

            _paymentMethods.Add(key, value);
        }

        public void RemovePaymentMethod(PaymentMethod key)
        {
            if (!_paymentMethods.ContainsKey(key))
                throw new Exception("A forma de pagamento não existe ou já foi excluída.");

            _paymentMethods.Remove(key);
        }
    }
}
