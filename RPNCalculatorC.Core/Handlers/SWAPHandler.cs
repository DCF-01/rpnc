using RPNCalculatorC.Core.Handlers.Interfaces;
using RPNCalculatorC.Core.Memento;
using RPNCalculatorC.Core.Strategy.Enums;

namespace RPNCalculatorC.Core.Handlers
{
    /// <summary>
    /// Swap the positions of the last two items at the top of the stack
    /// </summary>
    public class SWAPHandler : BaseHandler, IHandler
    {
        public SWAPHandler(DataContext dataContext) : base(dataContext)
        {
        }

        public void Handle(IRequest req)
        {
            if (req.Value == "swap" && this.context.Calculator.State == CalculatorState.Normal)
            {
                if (this.context.CurrentStack.Count < 2)
                {
                    return;
                }

                this.context.CurrentStack.TryPop(out var el1);
                this.context.CurrentStack.TryPop(out var el2);

                this.context.CurrentStack.Push(el1);
                this.context.CurrentStack.Push(el2);
            }
            base.Handle(req);
        }
    }
}
