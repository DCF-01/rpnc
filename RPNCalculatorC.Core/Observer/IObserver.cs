using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorC.Core.Observer
{
    public interface IObserver
    {
        void Notify();
    }
}
