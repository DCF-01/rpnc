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

                if (this.context.CalculatorState == CalculatorState.Save)
                {
                    this.context.Storage[x] = this.context.sb.ToString();
                }
            }
            else
            {
                base.Handle(req);
            }
        }
    }
}
