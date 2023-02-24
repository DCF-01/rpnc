using RPNCalculatorC.Core.Memento;
using RPNCalculatorC.Core.Values;

namespace RPNCalculatorC.Core.Handlers
{
    public class OperatorHandler : BaseHandler, IHandler
    {
        public static List<string> Operators = new() { "-", "+", "/", "x", "X", "*" };
        public static List<string> TrigOperators = new() { "sin", "cos", "tan", "asin", "acos", "atan" };

        public OperatorHandler(DataContext dataContext) : base(dataContext)
        {
        }

        public void Handle(IRequest req)
        {   
            if ((Operators.Contains(req.Value) || TrigOperators.Contains(req.Value)) && this.context.Calculator.State == CalculatorState.PROG)
            {
                this.context.sb.Add(req);
            }

            else if (Operators.Contains(req.Value) && base.context.CurrentStack.Count >= 2 && this.context.Calculator.State == CalculatorState.Normal)
            {
                var op = new Operator(req.Value);
                this.context.CurrentStack.Push(op);

                var res = this.context.Calculator.Evaluator.Evaluate(this.context.CurrentStack);
                this.context.CurrentStack.Push(new Number res);
                this.context.sb.Clear();
            }
            else if(TrigOperators.Contains(req.Value) && base.context.CurrentStack.Count >= 1 )
            {
               

                this.context.CurrentStack.Push(req.Value);

                var res = this.context.Calculator.Evaluator.EvaluateTrig(this.context.CurrentStack).ToString();
                this.context.CurrentStack.Push(res);
                this.context.sb.Clear();
            }
            
            base.Handle(req);
        }

        private double DegreesToRadians(double el) => (Math.PI / 180) * el;
        
    }
}
