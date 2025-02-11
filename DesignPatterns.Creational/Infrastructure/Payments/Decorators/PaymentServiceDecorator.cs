using DesignPatterns.Application.Models;
using DesignPatterns.Infrastructure.Integrations;
using Newtonsoft.Json;
using System.Text;

namespace DesignPatterns.Infrastructure.Payments.Decorators
{
    public class PaymentServiceDecorator : IPaymentService
    {
        private readonly IPaymentService _paymentService;
        private readonly ICoreCrmIntegrationService _crmService;
        private readonly IAntiFraudFacade _antiFraudFacade;

        public PaymentServiceDecorator(IPaymentService paymentService, ICoreCrmIntegrationService crmService, IAntiFraudFacade antiFraudFacade)
        {
            _paymentService = paymentService;
            _crmService = crmService;
            _antiFraudFacade = antiFraudFacade;
        }

        public object Process(OrderInputModel inputModel)
        {
            var antiFraudModel = new AntiFraudModel(inputModel.Customer.Document, inputModel.TotalPrice);

            #region [Sem implementar o pattern facade]
            //var json = JsonConvert.SerializeObject(antiFraudModel);
            //var content = new StringContent(json, Encoding.UTF8, "application/json");
            //var url = "http://urltestapi.com/antifraud";

            //using var client = new HttpClient();
            
            //var antiFraudRequestResult = client.PostAsync(url, content);
            //var antiFraudResultString = antiFraudRequestResult.Result.Content.ReadAsStringAsync().Result;
            //var antiFraudResult = JsonConvert.DeserializeObject<AntiFraudResultModel>(antiFraudResultString);

            #endregion


            #region [Com a implementação do pattern facade]
            var antiFraudResult = _antiFraudFacade.Check(antiFraudModel);
            #endregion

            if (antiFraudResult is null || antiFraudResult.CheckResult)
                throw new InvalidOperationException(antiFraudResult?.Comments);

            var result = _paymentService.Process(inputModel);

            _crmService.Sync(inputModel);

            return result;
        }
    }
}
