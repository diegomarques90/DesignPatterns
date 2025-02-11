using Newtonsoft.Json;
using System.Text;

namespace DesignPatterns.Infrastructure.Integrations
{
    public class AntiFraudFacade : IAntiFraudFacade
    {
        public AntiFraudResultModel Check(AntiFraudModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "http://urltestapi.com/antifraud";

            using var client = new HttpClient();

            var antiFraudRequestResult = client.PostAsync(url, content);
            var antiFraudResultString = antiFraudRequestResult.Result.Content.ReadAsStringAsync().Result;
            
            return JsonConvert.DeserializeObject<AntiFraudResultModel>(antiFraudResultString);
        }
    }
}
