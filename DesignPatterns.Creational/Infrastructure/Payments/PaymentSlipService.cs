using DesignPatterns.Application.Models;
using DesignPatterns.Infrastructure.Payments.Adapters;
using DesignPatterns.Infrastructure.Payments.Interfaces;
using DesignPatterns.Infrastructure.Payments.Models;

namespace DesignPatterns.Infrastructure.Payments
{
    public class PaymentSlipService : IPaymentService
    {
        private readonly IExternalPaymentSlipService _externalService;

        public PaymentSlipService(IExternalPaymentSlipService externalService)
        {
            _externalService = externalService;
        }

        public object Process(OrderInputModel inputModel)
        {
            //Criação do objeto antes de aplicar o padrão builder
            var paymentSlip = new PaymentSlipModel(
                "12312.23214521-1.232152131", "12324124", DateTime.Now, DateTime.Now.AddDays(3), 1234.0m,
                new Payer("Pagador", "123.567.899-10", "Rua do Pagador"),
                new Receiver("Recebedor", "987.654.321-01", "Rua do Recebedor")
            );

            //Criação do objeto com padrão builder
            var builder = new PaymentSlipBuilder();

            var paymentSlipWithBuilder = builder
                .WithPayer(new Payer("Pagador", "123.567.899-10", "Rua do Pagador"))
                .WithReceiver(new Receiver("Recebedor", "987.654.321-01", "Rua do Recebedor"))
                .WithPaymentDocument("12312.23214521-1.232152131", "12324124", 1234.0m)
                .WithDates(DateTime.Now, DateTime.Now.AddDays(3))
                .Build();

            //Aplicação do padrão Adapter
            var paymentSlipServiceAdapter = new PaymentSlipServiceAdapter(_externalService);
            var paymentSlipModel = paymentSlipServiceAdapter.GeneratePaymentSlip(inputModel);

            return "Dados do boleto.";
        }
    }
}