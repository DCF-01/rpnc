using RPNCalculatorC.Core.Handlers;
using RPNCalculatorC.Core.Values;
using System.Text;

namespace RPNCalculatorC.Core
{
    public class Evaluator
    {
        public static List<string> Operators = new() { "-", "+", "/", "x", "X", "*" };
        public static List<string> TrigOperators = new() { "sin", "cos", "tan", "asin", "acos", "atan" };
        public double DegreesToRadians(double el) => (Math.PI / 180) * el;


        public IValue EvaluateExpression(Stack<IValue> stack)
        {
            var operands = new Stack<IValue>();

            while (stack.Count > 0)
            {
                var token = stack.Pop();

                if (token is not Operator)
                {
                    stack.Push(token);
                }
                else
                {
                    string op = ((Operator)token).StringValue;

                    if (Operators.Contains(op))
                    {
                        var x = stack.Pop();
                        var y = stack.Pop();

                        var calcStack = new Stack<IValue>();
                        calcStack.Push(x);
                        calcStack.Push(y);
                        calcStack.Push(token);


                        stack.Push(Evaluate(calcStack));
                    }
                    else if (TrigOperators.Contains(op))
                    {
                        var x = stack.Pop();

                        var calcStack = new Stack<IValue>();
                        calcStack.Push(x);
                        calcStack.Push(token);

                        stack.Push(EvaluateTrig(calcStack));
                    }
                }
            }

            return stack.Pop();
        }

        public IValue Evaluate(Stack<IValue> stack)
        {
            var op = (Operator)stack.Pop();

            IValue x = stack.Pop();
            IValue y = stack.Pop();
            IValue res;
            switch (op.StringValue)
            {
                case "+":
                    res = x + y;
                    break;
                case "-":
                    res = x - y;
                    break;
                case "x":
                    res = x * y;
                    break;
                case "/":
                    res = x / y;
                    break;
                default:
                    throw new ArgumentException("not an operand or operator");
            }

            return res;
        }

        public IValue EvaluateTrig(Stack<IValue> stack)
        {
            Operator op = (Operator)stack.Pop();
            IValue x = stack.Pop();

            if (x is Deg)
            {
                x = new Rad(DegreesToRadians(x.Value));
            }

            double res;
            switch (op.StringValue)
            {
                case "sin":
                    res = Math.Sin(x.Value);
                    break;
                case "cos":
                    res = Math.Cos(x.Value);
                    break;
                case "tan":
                    res = Math.Tan(x.Value);
                    break;
                case "asin":
                    res = Math.Asin(x.Value);
                    break;
                case "acos":
                    res = Math.Acos(x.Value);
                    break;
                case "atan":
                    res = Math.Atan(x.Value);
                    break;
                default:
                    throw new ArgumentException("not an operand or operator");
            }

            return new Rad(res);
        }

        //evaluate the expression stack
        public IValue ToSingleValueNumber(Stack<IValue> stack)
        {
            var tempStack = new Stack<IValue>();

            var sb = new Queue<string>();
            while (stack.Count > 0)
            {
                var token = stack.Pop();

                if (token is Deg or Rad)
                {
                    break;
                }
                else
                {
                    sb.Prepend(token.Value.ToString());
                }
            }

            return new Deg(double.Parse(string.Join("", sb.ToList())));
        }

        public IValue ToSingleValueDeg(Stack<IValue> stack)
        {
            var tempStack = new Stack<IValue>();

            var sb = new Queue<string>();
            while (stack.Count > 0)
            {
                var token = stack.Pop();

                if (token is Deg or Rad)
                {
                    break;
                }
                else
                {
                    sb.Prepend(token.Value.ToString());
                }
            }

            return new Deg(double.Parse(string.Join("", sb.ToList())));
        }

        public IValue ToSingleValueRad(Stack<IValue> stack)
        {
            var tempStack = new Stack<IValue>();

            var sb = new Queue<string>();
            while (stack.Count > 0)
            {
                var token = stack.Pop();

                if (token is Deg or Rad)
                {
                    break;
                }
                else
                {
                    sb.Prepend(token.Value.ToString());
                }
            }

            return new Rad(double.Parse(string.Join("", sb.ToList())));
        }
    }
}
