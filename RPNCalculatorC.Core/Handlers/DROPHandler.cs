using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPNCalculatorC.Core.Memento;

namespace RPNCalculatorC.Core.Handlers
{
    internal class DROPHandler : BaseHandler, IHandler
    {
        public DROPHandler(DataContext dataContext) : base(dataContext)
        {
        }

        public void Handle(IRequest req)
        {
            if(req.Value == "drop" && this.context.Calculator.State == CalculatorState.Normal)
            {
                this.context.ValuesStack.TryPop(out var el);
            }
            
            base.Handle(req);
        }
    }
}
