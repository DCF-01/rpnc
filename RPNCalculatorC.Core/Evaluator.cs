using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorC.Core
{
    public class Evaluator
    {
        public int Evaluate(Stack<string> stack)
        {
            var el = stack.Pop();
            int a;
            int b;

            if (!int.TryParse(el, out a))
            {
                a = Evaluate(stack);
                b = Evaluate(stack);

                switch (el.Trim().ToLower())
                {
                    case "+":
                        a += b;
                        break;
                    case "-":
                        a -= b;
                        break;
                    case "x":
                        a *= b;
                        break;
                    case "/":
                        a /= b;
                        break;
                    default:
                        throw new ArgumentException("not an operand or operator");
                }
            }

            //stack.Push(a.ToString());

            return a;
        }
    }
}
