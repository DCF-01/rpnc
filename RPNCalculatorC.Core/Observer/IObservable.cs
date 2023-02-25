using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorC.Core.Observer
{
    /// <summary>
    /// Observable interface, methods for notifying observers and registering and removing them
    /// </summary>
    public interface IObservable
    {
        void NotifyObservers();
        void RemoveObserver(IObserver observer);
        void RegisterObserver(IObserver observer);
        void RegisterObserverRange(ICollection<IObserver> observers);
        ICollection<IObserver> GetObservers();
    }
}
