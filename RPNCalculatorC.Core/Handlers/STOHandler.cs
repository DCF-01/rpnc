using RPNCalculatorC.Core.Handlers.Interfaces;
using RPNCalculatorC.Core.Memento;
using RPNCalculatorC.Core.Strategy.Enums;

namespace RPNCalculatorC.Core.Handlers
{
    /// <summary>
    /// Sets state to Store to prepare for the next key press which stores the displayed value
    /// </summary>
    public class STOHandler : BaseHandler, IHandler
    {

        private List<CalculatorState> allowedStates = new List<CalculatorState>() { CalculatorState.Normal };
        public STOHandler(DataContext dataContext) : base(dataContext)
        {
        }

        public void Handle(IRequest req)
        {
            if (req.Value == "sto" && allowedStates.Contains(this.context.Calculator.State))
            {
                this.context.Calculator.SetState(CalculatorState.Store);
            }
            base.Handle(req);
        }
    }
}
