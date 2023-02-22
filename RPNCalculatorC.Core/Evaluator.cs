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

        public int EvaluateExpression(string expression)
        {
            var stack = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (int.TryParse(expression[i].ToString(), out var res))
                {
                    stack.Push(res);
                }
                else
                {
                    var a = stack.Pop();
                    var b = stack.Pop();

                    switch (expression[i].ToString().Trim().ToLower())
                    {
                        case "+":
                            stack.Push(a + b);
                            break;
                        case "-":
                            stack.Push(a - b);
                            break;
                        case "x":
                            stack.Push(a * b);
                            break;
                        case "/":
                            stack.Push(a / b);
                            break;
                        default:
                            throw new ArgumentException("not an operand or operator");
                    }
                }
            }

            return stack.Pop();
        }
    }
}
