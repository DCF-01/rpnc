
namespace RPNCalculatorC.Core.Observer
{
    /// <summary>
    /// Observable class, implements methods for notifying observers and registering and removing them
    /// </summary>
    public class RequestObservable : IObservable
    {
        List<IObserver> _observers = new();

        public void NotifyObservers()
        {
            foreach (var obs in _observers)
            {
                obs.Notify();
            }
        }

        public void RegisterObserver(IObserver observer)
        {
            if (observer != null)
            {
                _observers.Add(observer);
            }
        }

        public void RegisterObserverRange(ICollection<IObserver> observers)
        {
            if (observers != null)
            {
                _observers.AddRange(observers);
            }
        }

        public void RemoveObserver(IObserver observer)
        {
            if (observer != null)
            {
                _observers.Remove(observer);
            }
        }

        public ICollection<IObserver> GetObservers()
        {
            if(_observers != null)
            {
                return _observers;
            }
            return new List<IObserver>();
        }
    }
}
