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
                this.context.sb.Push(new Operator(req.Value));
            }

            else if (Operators.Contains(req.Value) && base.context.ValuesStack.Count >= 2 && this.context.Calculator.State == CalculatorState.Normal)
            {
                var op = new Operator(req.Value);
                this.context.ValuesStack.Push(op);

                var res = this.context.Calculator.Evaluator.Evaluate(this.context.ValuesStack);
                this.context.ValuesStack.Push(new Number(res.Value));
                this.context.sb.Clear();
            }
            else if(TrigOperators.Contains(req.Value) && base.context.ValuesStack.Count >= 1 )
            {
                var op = new Operator(req.Value);
                this.context.ValuesStack.Push(op);

                var res = this.context.Calculator.Evaluator.EvaluateTrig(this.context.ValuesStack);
                this.context.ValuesStack.Push(res);
                this.context.sb.Clear();
            }
            
            base.Handle(req);
        }

        private double DegreesToRadians(double el) => (Math.PI / 180) * el;
        
    }
}
