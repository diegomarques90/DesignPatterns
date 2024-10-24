using DesignPatterns.Creational.Application.Models;
using DesignPatterns.Creational.Infrastructure.Payments.Models;

namespace DesignPatterns.Creational.Infrastructure.Payments
{
    public class PaymentSlipService : IPaymentService
    {
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

            return "Dados do boleto.";
        }
    }
}
