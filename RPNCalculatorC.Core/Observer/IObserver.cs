using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorC.Core.Observer
{
    /// <summary>
    /// Observer interface, exposes a method for the IObservable to call
    /// </summary>
    public interface IObserver
    {
        void Notify();
    }
}
