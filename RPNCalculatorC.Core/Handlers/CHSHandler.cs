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
            if(req.Value == "chs" && this.context.CurrentStack.Count >= 1 && this.context.Calculator.State == CalculatorState.Normal)
            {
                int x = int.Parse(this.context.CurrentStack.Pop()) * -1;
                this.context.CurrentStack.Push(x.ToString());
            }
            
                base.Handle(req);
            
        }
    }
}
