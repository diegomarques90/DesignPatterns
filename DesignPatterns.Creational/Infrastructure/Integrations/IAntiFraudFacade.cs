namespace DesignPatterns.Infrastructure.Integrations
{
    public interface IAntiFraudFacade
    {
        AntiFraudResultModel Check(AntiFraudModel model);
    }
}
