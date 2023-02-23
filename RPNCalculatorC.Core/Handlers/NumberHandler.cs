using RPNCalculatorC.Core.Memento;

namespace RPNCalculatorC.Core.Handlers
{
    public class NumberHandler : BaseHandler, IHandler
    {
        public NumberHandler(DataContext dataContext) : base(dataContext)
        {
        }

        public void Handle(IRequest req)
        {
            if (int.TryParse(req.Value, out var x))
            {
                if (this.context.Calculator.State == CalculatorState.Store)
                {
                    this.context.Storage[x] = String.Join("", this.context.sb.Select(x => x.Value).ToList());
                    this.context.Calculator.SetState(CalculatorState.Normal);
                }
                else if (this.context.Calculator.State == CalculatorState.Recall)
                {
                    this.context.sb.Clear();
                    this.context.sb.Add(new Request(this.context.Storage[x]));
                    this.context.Calculator.SetState(CalculatorState.Normal);
                }
                else
                {
                    this.context.sb.Add(req);
                }
            }
            base.Handle(req);
        }
    }
}
