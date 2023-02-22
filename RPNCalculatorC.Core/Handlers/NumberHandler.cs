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
                this.context.sb.Append(req);

                if (this.context.Calculator.State == CalculatorState.Save)
                {
                    this.context.Storage[x] = this.context.sb.ToString();
                    this.context.Calculator.SetState(CalculatorState.Normal);
                }
                else if(this.context.Calculator.State == CalculatorState.Recall)
                {
                    this.context.Storage[x] = this.context.sb.ToString();
                    this.context.Calculator.SetState(CalculatorState.Normal);
                }
            }
            else
            {
                base.Handle(req);
            }
        }
    }
}
