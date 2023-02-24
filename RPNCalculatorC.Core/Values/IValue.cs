using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorC.Core.Values
{
    public interface IValue
    {
        public double Value { get; }
        public static IValue operator +(IValue a, IValue b) => a + b;
        public static IValue operator -(IValue a, IValue b) => a - b;
        public static IValue operator /(IValue a, IValue b) => a / b;
        public static IValue operator *(IValue a, IValue b) => a * b;
    }
}
