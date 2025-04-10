using DesignPatterns.Application.Models;
using DesignPatterns.Core.Enums;
using DesignPatterns.Infrastructure.Payments;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : Controller
    {
        private const string INVALID_PAYMENT_METHOD = "Não foi passada uma forma de pagamento válida.";

        [HttpGet("payment-methods-without-flyweight/{paymentMethod}")]
        public IActionResult GetPaymentMethodDetailsWithoutFlyweight(PaymentMethod? paymentMethod)
        {
            PaymentMethodViewModel model;

            if (!paymentMethod.HasValue)
                return BadRequest(INVALID_PAYMENT_METHOD);

            if (paymentMethod == PaymentMethod.CreditCard)
                model = new PaymentMethodViewModel("Sobre o Cartão de Crédito.", 1, null);
            else if (paymentMethod == PaymentMethod.PaymentSlip)
                model = new PaymentMethodViewModel("Sobre o Boleto.", 10, 1000);
            else if (paymentMethod == PaymentMethod.PayPal)
                model = new PaymentMethodViewModel("Sobre o PayPal.", 16.5m, null);
            else
                return BadRequest(INVALID_PAYMENT_METHOD);

            return Ok(model);
        }


        [HttpGet("payment-methods-with-flyweight/{paymentMethod}")]
        public IActionResult GetPaymentMethodWithFlyweight(PaymentMethod? paymentMethod, [FromServices] PaymentMethodsFactory factory)
        {
            if (!paymentMethod.HasValue || paymentMethod == PaymentMethod.Unknow)
                return BadRequest(INVALID_PAYMENT_METHOD);

            var model = factory.GetPaymentMethod(paymentMethod.Value);

            return Ok(model);
        }
    }
}
