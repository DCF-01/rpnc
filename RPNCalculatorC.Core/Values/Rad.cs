using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorC.Core.Values
{
    public struct Rad : IValue
    {
        public double Value { get; private set; }

        public Rad(double value)
        {
            Value = value;
        }


        public static Rad operator +(Rad a, Rad b)
        {
            return new Rad(a.Value + b.Value);
        }

        public static Rad operator -(Rad a, Rad b)
        {
            return new Rad(a.Value - b.Value);
        }

        public static Rad operator *(Rad a, double b)
        {
            return new Rad(a.Value * b);
        }

        public static Rad operator /(Rad a, double b)
        {
            return new Rad(a.Value / b);
        }

        public static Deg operator +(Rad a, Deg b)
        {
            return new Deg(a.Value * (180.0 / Math.PI) + b.Value);
        }

        public static Deg operator -(Rad a, Deg b)
        {
            return new Deg(a.Value * (180.0 / Math.PI) - b.Value);
        }

        public override string ToString()
        {
            return this.Value.ToString() + "rad";
        }

        public void ChangeSign()
        {
            this.Value *= -1;
        }
    }
}
