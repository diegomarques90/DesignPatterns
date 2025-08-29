using DesignPatterns.Application.ChainOfResponsibility;
using DesignPatterns.Application.Configuration;
using DesignPatterns.Application.Models;
using DesignPatterns.Core.Enums;
using DesignPatterns.Infrastructure.Orders;
using DesignPatterns.Infrastructure.Orders.Models;
using DesignPatterns.Infrastructure.Payments.Interfaces;
using DesignPatterns.Infrastructure.Payments.Models;
using DesignPatterns.Infrastructure.Products;
using DesignPatterns.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.Controllers
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

        [HttpGet]
        [Route("singletonExample")]
        public IActionResult SingletonExample()
        {
            return Ok(BusinessHour.GetInstance());
        }

        [HttpPost]
        [Route("processOrderWithSyncToCrm")]
        public IActionResult ProcessOrderWithSyncToCrm([FromServices] IPaymentServiceFactory paymentServiceFactory, OrderInputModel model)
        {
            var paymentService = paymentServiceFactory.GetService(model.PaymentInfo.PaymentMethod);
            paymentService.Process(model);
            return NoContent();
        }

        [HttpPost]
        [Route("not-using-chain")]
        public IActionResult NotUsingCoR(OrderInputModel model, [FromServices] IProductRepository productRepository, [FromServices] IPaymentFraudCheckService fraudCheckService, [FromServices] ICustomerRepository customerRepository)
        {
            var itemsDictionary = model.Items.ToDictionary(d => d.ProductId, d => d.Quantity);
            var hasStock = productRepository.HasStock(itemsDictionary);

            if (!hasStock)
                return BadRequest();

            var customer = customerRepository.GetCustomerById(model.Customer.Id);
            var customerAllowedToBuy = customer.IsAllowedToBuy();

            if (!customerAllowedToBuy)
                return BadRequest();

            var isFraud = fraudCheckService.IsFraud(model);

            if (isFraud)
                return BadRequest();

            return NoContent();
        }

        [HttpPost]
        [Route("using-chain")]
        public IActionResult UsingCoR(OrderInputModel model, [FromServices] IProductRepository productRepository, [FromServices] IPaymentFraudCheckService fraudCheckService, [FromServices] ICustomerRepository customerRepository)
        {
            var validateStockHandler = new ValidateStockHandler(productRepository);
            var validadeCustomerHandler = new ValidateCustomerHandler(customerRepository);
            var checkForFraudHandler = new CheckForFraudHandler(fraudCheckService);

            validateStockHandler
                .SetNext(validadeCustomerHandler)
                .SetNext(checkForFraudHandler);

            bool success = validateStockHandler.Handle(model);

            if (!success)
                return BadRequest();

            return NoContent();
        }

        [HttpPost("not-using-command")]
        public IActionResult PostNotUsingCommand(OrderInputModel model, [FromServices] IPaymentFraudCheckService fraudCheckService)
        {
            var total = model.Items.Sum(i => i.Quantity * i.Price);
            var isFraud = fraudCheckService.IsFraudV2(total, model.Customer.Id, model.Customer.FullName, model.Customer.Document);

            if (isFraud)
                return BadRequest("Order is fraud");

            var message = new
            {
                total,
                customerId = model.Customer.Id,
                fullName = model.Customer.FullName,
                document = model.Customer.Document
            };

            //Poderia chamar serviço de mensageria para enviar o objeto como JSON
            //Também poderiamos guardar log desse objeto

            return Ok(message);
        }

        [HttpPost("using-command")]
        public IActionResult PostUsingCommand(OrderInputModel model, [FromServices] IPaymentFraudCheckService fraudCheckService)
        {
            var total = model.Items.Sum(i => i.Quantity * i.Price);
            var command = new FraudCheckModel(total, model.Customer.Id, model.Customer.FullName, model.Customer.Document);

            var isFraud = fraudCheckService.IsFraudV2UsingCommand(command);

            if (isFraud)
                return BadRequest("Order is fraud");

            //Poderia chamar o serviço de mensageria para enviar o objeto command como JSON
            //Também poderiamos guardar log desse objeto

            return NoContent();

        }
    }
}
