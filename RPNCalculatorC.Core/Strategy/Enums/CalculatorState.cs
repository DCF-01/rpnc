using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorC.Core.Strategy.Enums
{
    /// <summary>
    /// State of the Calculator
    /// </summary>
    public enum CalculatorState
    {
        Normal,
        PROG,
        Store,
        Recall
    }
}
