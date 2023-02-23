using RPNCalculatorC.Core.Handlers;

namespace RPNCalculatorC.Core
{
    public class Evaluator
    {
        public static List<string> Operators = new() { "-", "+", "/", "x", "X", "*" };
        public static List<string> TrigOperators = new() { "sin", "cos", "tan", "asin", "acos", "atan" };
        

        /*public double Evaluate(Stack<string> stack)
        {
            var op = stack.Pop();

            double res = 0;
            if (Operators.Contains(op))
            {
                var x = int.Parse(stack.Pop());
                var y = int.Parse(stack.Pop());

                res = CalcResult(op.Trim().ToLower(), x, y);
            }
            else if (TrigOperators.Contains(op))
            {
                double x = int.Parse(stack.Pop());

                res = CalcTrigResult(op, x);
            }

            return res;
            
        }*/

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

                    var calcStack = new Stack<string>();
                    calcStack.Push(x.ToString());
                    calcStack.Push(y.ToString());
                    calcStack.Push(expression[i].Value);


                    stack.Push(Evaluate(calcStack));
                }
                else if (TrigOperators.Contains(expression[i].Value))
                {
                    var x = stack.Pop();

                    var calcStack = new Stack<string>();
                    calcStack.Push(x.ToString());
                    calcStack.Push(expression[i].Value);

                    stack.Push(EvaluateTrig(calcStack));
                }
            }

            return stack.Pop();
        }

        public double Evaluate(Stack<string> stack)
        {
            var op = stack.Pop();

            double x = double.Parse(stack.Pop());
            double y = double.Parse(stack.Pop());
            double res = 0;
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

        public double EvaluateTrig(Stack<string> stack)
        {
            var op = stack.Pop();
            double x = double.Parse(stack.Pop());

            double res = 0;
            switch (op.ToString().Trim().ToLower())
            {
                case "sin":
                    res = Math.Sin(x);
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
