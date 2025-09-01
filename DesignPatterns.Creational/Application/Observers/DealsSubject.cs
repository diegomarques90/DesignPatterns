
namespace DesignPatterns.Application.Observers
{
    public class DealsSubject : IDealsSubject
    {
        private readonly List<IDealsObserver> _observers;
        public DealsSubject()
        {
            CurrentDeals = new List<string>();
            _observers = new List<IDealsObserver>();
        }
        public List<string> CurrentDeals { get; private set; }

        public void Attach(IDealsObserver observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
        }

        public void Detach(IDealsObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }

        public void SetDeals(List<string> deals)
        {
            CurrentDeals = deals;
            Notify();
        }
    }
}
