using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPNCalculatorC.Core.Memento;
using RPNCalculatorC.Core.Memento;

namespace RPNCalculatorC.Core.Handlers
{
    internal class DROPHandler : BaseHandler, IHandler
    {
        public DROPHandler(DataContext dataContext) : base(dataContext)
        {
        }

        public void Handle(string req)
        {
            if(req.Trim().ToLower() == "drop" && this.context.CalculatorState == CalculatorState.Normal)
            {
                this.context.CurrentStack.TryPop(out var el1);
            }
            else
            {
                base.Handle(req);
            }
        }
    }
}
