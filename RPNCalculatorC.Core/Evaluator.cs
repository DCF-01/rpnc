using RPNCalculatorC.Core.Handlers;
using RPNCalculatorC.Core.Values;

namespace RPNCalculatorC.Core
{
    public class Evaluator
    {
        public static List<string> Operators = new() { "-", "+", "/", "x", "X", "*" };
        public static List<string> TrigOperators = new() { "sin", "cos", "tan", "asin", "acos", "atan" };
        public double DegreesToRadians(double el) => (Math.PI / 180) * el;


        public double EvaluateExpression(List<IRequest> expression)
        {
            var stack = new Stack<double>();

            for (int i = 0; i < expression.Count; i++)
            {
                if (double.TryParse(expression[i].Value, out var res))
                {
                    stack.Push(res);
                }
                else if(Operators.Contains(expression[i].Value))
                {
                    var x = stack.Pop();
                    var y = stack.Pop();

                    var calcStack = new Stack<IValue>();
                    calcStack.Push(x);
                    calcStack.Push(y.ToString());
                    calcStack.Push(expression[i].Value);


                    stack.Push(Evaluate(calcStack));
                }
                else if (TrigOperators.Contains(expression[i].Value))
                {
                    var x = stack.Pop();

                    var calcStack = new Stack<IValue>();
                    calcStack.Push(x.ToString());
                    calcStack.Push(expression[i].Value);

                    stack.Push(EvaluateTrig(calcStack));
                }
            }

            return stack.Pop();
        }

        public IValue Evaluate(Stack<IValue> stack)
        {
            var op = stack.Pop();

            IValue x = stack.Pop();
            IValue y = stack.Pop();
            IValue res;
            switch (op.ToString().Trim().ToLower())
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
            var op = stack.Pop();
            IValue x = stack.Pop();

            if(x is Deg)
            {
                x = new Rad(DegreesToRadians(x.Value));
            }

            IValue res;
            switch (op.ToString().Trim().ToLower())
            {
                case "sin":
                    res = Math.Sin(x.Value);
                    break;
                case "cos":
                    res = Math.Cos(x);
                    break;
                case "tan":
                    res = Math.Tan(x);
                    break;
                case "asin":
                    res = Math.Asin(x);
                    break;
                case "acos":
                    res = Math.Acos(x);
                    break;
                case "atan":
                    res = Math.Atan(x);
                    break;
                default:
                    throw new ArgumentException("not an operand or operator");
            }

            return res;
        }

    }
}
