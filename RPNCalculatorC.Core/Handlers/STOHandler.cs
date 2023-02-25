using RPNCalculatorC.Core.Memento;

namespace RPNCalculatorC.Core.Handlers
{
    public class STOHandler : BaseHandler, IHandler
    {
        private List<CalculatorState> allowedStates = new List<CalculatorState>() { CalculatorState.Normal, CalculatorState.DEG, CalculatorState.RAD };
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
