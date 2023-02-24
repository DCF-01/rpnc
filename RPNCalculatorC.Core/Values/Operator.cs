using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorC.Core.Values
{
    public struct Operator : IValue
    {
        public double Value { get; }
        public string StringValue { get; }

        public Operator(string value)
        {
            StringValue = value;
            Value = 0;
        }

        public void ChangeSign(){}
    }
}
