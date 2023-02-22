using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPNCalculatorC.Core.Memento;

namespace RPNCalculatorC.Core.Strategy
{
    public interface IStrategy
    {
        void Execute(DataContext dataContext, string req);
    }
}
