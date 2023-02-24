using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPNCalculatorC.Core.Memento;

namespace RPNCalculatorC.Core.Handlers
{
    internal class CHSHandler : BaseHandler, IHandler
    {
        public CHSHandler(DataContext dataContext) : base(dataContext)
        {
        }

        public void Handle(IRequest req)
        {
            if (req.Value == "chs" && this.context.ValuesStack.Count >= 1 && this.context.Calculator.State == CalculatorState.Normal)
            {
                this.context.ValuesStack.Peek().ChangeSign();
            }
            base.Handle(req);
        }
    }
}
