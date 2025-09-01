namespace DesignPatterns.Application.Observers
{
    public interface IDealsObserver
    {
        void Update(IDealsSubject subject);
    }
}
