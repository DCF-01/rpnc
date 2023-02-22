using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPNCalculatorC.Core.Memento;

namespace RPNCalculatorC.Core.Handlers
{
    public class SWAPHandler : BaseHandler, IHandler
    {
        public SWAPHandler(DataContext dataContext) : base(dataContext)
        {
        }

        public void Handle(string req)
        {
            if (req.Trim().ToLower() == "swap" && this.context.Calculator.State == CalculatorState.Normal)
            {
                if(this.context.CurrentStack.Count < 2)
                {
                    return;
                }


                this.context.CurrentStack.TryPop(out var el1);
                this.context.CurrentStack.TryPop(out var el2);

                this.context.CurrentStack.Push(el1);
                this.context.CurrentStack.Push(el2);
            }
            else
            {
                base.Handle(req);
            }
        }
    }
}
