using RPNCalculatorC.Core.Memento;

namespace RPNCalculatorC.Core.Handlers
{
    public class NumberHandler : BaseHandler, IHandler
    {
        public NumberHandler(DataContext dataContext) : base(dataContext)
        {
        }

        public void Handle(string req)
        {
            if (int.TryParse(req, out var x))
            {
                if (this.context.Calculator.State == CalculatorState.Store)
                {
                    this.context.Storage[x] = this.context.sb.ToString();
                    this.context.Calculator.SetState(CalculatorState.Normal);
                }
                else if(this.context.Calculator.State == CalculatorState.Recall)
                {
                    this.context.sb.Clear();
                    this.context.sb.Append(this.context.Storage[x]);
                    this.context.Calculator.SetState(CalculatorState.Normal);
                }
                else
                {
                    this.context.sb.Append(req);
                }
                //MementoCaretaker.PushToStack(this.context);
            }
            
                base.Handle(req);
            
        }
    }
}
