using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorC.Core.Values
{
    public struct Deg : IValue
    {
        public double Value { get; private set; }

        public Deg(double value)
        {
            Value = value;
        }

        public static Deg operator +(Deg a, Deg b)
        {
            return new Deg(a.Value + b.Value);
        }

        public static Deg operator -(Deg a, Deg b)
        {
            return new Deg(a.Value - b.Value);
        }

        public static Deg operator *(Deg a, double b)
        {
            return new Deg(a.Value * b);
        }

        public static Deg operator /(Deg a, double b)
        {
            return new Deg(a.Value / b);
        }

        public static Rad operator +(Deg a, Rad b)
        {
            return new Rad((a.Value + b.Value) * (Math.PI / 180.0));
        }

        public static Rad operator -(Deg a, Rad b)
        {
            return new Rad((a.Value - b.Value) * (Math.PI / 180.0));
        }

        public override string ToString()
        {
            return this.Value.ToString() + "deg";
        }

        public void ChangeSign()
        {
            this.Value *= -1;
        }
    }
}
