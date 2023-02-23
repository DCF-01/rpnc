using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorC.Core
{
    public enum CalculatorState
    {
        Normal,
        PROG,
        Store,
        Recall,
        RAD,
        DEG
    }
}
