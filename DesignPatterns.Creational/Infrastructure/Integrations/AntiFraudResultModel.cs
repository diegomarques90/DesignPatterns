namespace DesignPatterns.Infrastructure.Integrations
{
    public class AntiFraudResultModel
    {
        public AntiFraudResultModel(bool checkResult, string comments)
        {
            CheckResult = checkResult;
            Comments = comments;
        }

        public bool CheckResult { get; set; }
        public string Comments { get; set; }
    }
}
