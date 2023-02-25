using RPNCalculatorC.Core.Handlers.Interfaces;
using RPNCalculatorC.Core.Memento;
using RPNCalculatorC.Core.Strategy.Enums;

namespace RPNCalculatorC.Core.Handlers
{
    /// <summary>
    /// Handle all number inputs
    /// If Calculator State is Store or Recall, do appropriate logic
    /// otherwise append to the display string
    /// Rule for not allowing more than 20 items in prog
    /// </summary>
    public class NumberHandler : BaseHandler, IHandler
    {
        public NumberHandler(DataContext dataContext) : base(dataContext)
        {
        }

        public void Handle(IRequest req)
        {
            if (double.TryParse(req.Value, out var x) || req.Value == ".")
            {
                if (this.context.Calculator.State == CalculatorState.Store)
                {
                    this.context.Storage[(int)x] = String.Join("", this.context.DisplayInput.Select(x => x.Value).ToList());
                    this.context.Calculator.SetState(CalculatorState.Normal);
                }
                else if (this.context.Calculator.State == CalculatorState.Recall)
                {
                    this.context.DisplayInput.Clear();
                    this.context.DisplayInput.Add(new Request(this.context.Storage[(int)x]));
                    this.context.Calculator.SetState(CalculatorState.Normal);
                }
                else if (this.context.Calculator.State == CalculatorState.PROG)
                {
                    if (this.context.DisplayInput.Count < 20)
                    {
                        this.context.DisplayInput.Add(req);
                    }
                }
                else
                {
                    this.context.DisplayInput.Add(req);
                }
            }
            base.Handle(req);
        }
    }
}
