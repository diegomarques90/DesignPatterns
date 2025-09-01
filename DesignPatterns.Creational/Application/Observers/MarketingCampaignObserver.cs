namespace DesignPatterns.Application.Observers
{
    public class MarketingCampaignObserver : IDealsObserver
    {
        public void Update(IDealsSubject subject)
        {
            Console.WriteLine("Sending an email to subscribers about new deals.");
        }
    }
}
