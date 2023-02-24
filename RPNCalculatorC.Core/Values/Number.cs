using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorC.Core.Values
{
    public readonly struct Number : IValue
    {
        public readonly double Value { get; }
        public Number(double val)
        {
            Value = val;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
