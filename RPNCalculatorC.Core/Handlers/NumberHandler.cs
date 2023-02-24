using RPNCalculatorC.Core.Memento;
using RPNCalculatorC.Core.Values;

namespace RPNCalculatorC.Core.Handlers
{
    public class NumberHandler : BaseHandler, IHandler
    {
        public NumberHandler(DataContext dataContext) : base(dataContext)
        {
        }

        public void Handle(IRequest req)
        {
            if (double.TryParse(req.Value, out var x))
            {
                if (this.context.Calculator.State == CalculatorState.Store)
                {
                    this.context.Storage[(int)x] = new Stack<IValue>(new Stack<IValue>(this.context.sb));
                    this.context.Calculator.SetState(CalculatorState.Normal);
                }
                else if (this.context.Calculator.State == CalculatorState.Recall)
                {
                    this.context.sb = this.context.Storage[(int)x];
                    this.context.Calculator.SetState(CalculatorState.Normal);
                }
                else
                {
                    this.context.sb.Push(new Number(x));
                }
            }
            else if (req.Value == "deg" && this.context.sb.Count > 0 && this.context.sb.Peek() is not Deg or Rad) 
            {
                var res = this.context.Calculator.Evaluator.ToSingleValueDeg(this.context.sb);
                this.context.ValuesStack.Push(res);
            }
            else if (req.Value == "rad" && this.context.sb.Count > 0 && this.context.sb.Peek() is not Deg or Rad)
            {
                var res = this.context.Calculator.Evaluator.ToSingleValueRad(this.context.sb);
                this.context.ValuesStack.Push(res);
            }

            base.Handle(req);
        }
    }
}
