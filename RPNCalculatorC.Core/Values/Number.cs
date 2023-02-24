using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorC.Core.Values
{
    public struct Number : IValue
    {
        public  double Value { get; private set; }
        public Number(double val)
        {
            Value = val;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }

        public void ChangeSign()
        {
            this.Value *= -1;
        }
    }
}
