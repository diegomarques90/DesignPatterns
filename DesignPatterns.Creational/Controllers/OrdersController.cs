using DesignPatterns.Creational.Application.Models;
using Microsoft.AspNetCore.Mvc;
using DesignPatterns.Creational.Core.Enums;
using DesignPatterns.Creational.Infrastructure.Payments;
using System.Runtime.CompilerServices;

namespace DesignPatterns.Creational.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IPaymentServiceFactory _paymentServiceFactory;

        public OrdersController(IPaymentServiceFactory paymentServiceFactory)
        {
            _paymentServiceFactory = paymentServiceFactory;    
        }

        [HttpPost]
        [Route("withoutFactoryMethod")]
        public IActionResult PostWithoutFactoryMethod(OrderInputModel inputModel)
        {
            switch (inputModel.PaymentInfo.PaymentMethod)
            {
                case PaymentMethod.CreditCard:
                    //processa pagamento de cartão de crédito com um gateway de pagamento;
                    break;
                case PaymentMethod.PaymentSlip:
                    //Gera o boleto e notificação para o cliente
                    break;
                default:
                    return BadRequest("Forma de pagamento inválida.");
            }

            return NoContent();
        }

        [HttpPost]
        [Route("withFactoryMethod")]
        public IActionResult PostWithFactoryMethod(OrderInputModel inputModel)
        {
            var paymentService = _paymentServiceFactory.GetService(inputModel.PaymentInfo.PaymentMethod);
            paymentService.Process(inputModel);

            return NoContent();
        }
    }
}
