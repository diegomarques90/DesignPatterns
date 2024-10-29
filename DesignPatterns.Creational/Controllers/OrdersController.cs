using DesignPatterns.Creational.Application.Models;
using DesignPatterns.Creational.Core.Enums;
using DesignPatterns.Creational.Infrastructure.Orders;
using DesignPatterns.Creational.Infrastructure.Orders.Models;
using DesignPatterns.Creational.Infrastructure.Payments;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        [Route("processOrderWithAbstractFactory")]
        public IActionResult ProcessOrderWithAbstractFactory([FromServices] InternationalOrderAbstractFactory internationalOrderAbstractFactory, [FromServices] NationalOrderAbstractFactory nationalOrderAbstractFactory, OrderInputModel model)
        {
            IOrderAbstractFactory orderAbstractFactory;

            if (model.IsInternational.HasValue)
                orderAbstractFactory = internationalOrderAbstractFactory;
            else
                orderAbstractFactory = nationalOrderAbstractFactory;

            orderAbstractFactory
                .GetPaymentService(model.PaymentInfo.PaymentMethod)
                .Process(model);

            orderAbstractFactory
                .GetDeliveryService()
                .Deliver(model);

            return NoContent();
        }

        [HttpGet]
        [Route("cloneOrderById")]
        public IActionResult CloneOrderById(Guid orderToCloneId)
        {
            //utilizando o builder para criar um objeto OrderInputModel.
            //Em um cenário real, teríamos a chamada de um serviço que faria a busca da order pelo Id informado na requisição
            var order = new OrderBuilder()
                .WithCustomer()
                .WithItems()
                .IsInternational(false)
                .Build();
            
            var clonedOrder = order.Clone();

            return Ok(clonedOrder);
        }
    }
}
