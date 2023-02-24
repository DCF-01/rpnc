using RPNCalculatorC.Core.Memento;
using RPNCalculatorC.Core.Values;

namespace RPNCalculatorC.Core.Handlers
{
    public class TrigHandler : BaseHandler, IHandler
    {
        public static List<string> Operators = new() { "sin", "cos", "tan", "x", "X", "*" };
        public TrigHandler(DataContext dataContext) : base(dataContext)
        {
        }

        /*public void Handle(IRequest req)
        {
            if (req.Value == "rad")
            {
                if (this.context.Calculator.State == CalculatorState.RAD)
                {
                    this.context.Calculator.SetState(CalculatorState.Normal);
                }
                else
                {
                    this.context.Calculator.SetState(CalculatorState.RAD);
                }
            }
            else if (req.Value == "deg")
            {
                if (this.context.Calculator.State == CalculatorState.DEG)
                {
                    this.context.Calculator.SetState(CalculatorState.Normal);
                }
                else
                {
                    this.context.Calculator.SetState(CalculatorState.DEG);
                }
            }

            base.Handle(req);

        }*/

        public void Handle(IRequest req)
        {
            if (req.Value == "deg" && this.context.ValuesStack.Count > 1 && this.context.sb.Peek() is not Deg or Rad)
            {
                var res = this.context.Calculator.Evaluator.ToSingleValueDeg(this.context.sb);
                this.context.ValuesStack.Push(res);
            }
            else if (req.Value == "rad" && this.context.ValuesStack.Count > 1 && this.context.sb.Peek() is not Deg or Rad)
            {
                var res = this.context.Calculator.Evaluator.ToSingleValueRad(this.context.sb);
                this.context.ValuesStack.Push(res);
            }

            base.Handle(req);

        }
    }
}
