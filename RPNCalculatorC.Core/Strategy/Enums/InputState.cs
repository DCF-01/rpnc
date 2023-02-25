using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorC.Core.Strategy.Enums
{
    /// <summary>
    /// Input is std,rad or deg
    /// When performing trig deg is calculated to rad first
    /// If state is STD then input is treated as RAD when performing trig
    /// </summary>
    public enum InputState
    {
        STD,
        RAD,
        DEG
    }
}
