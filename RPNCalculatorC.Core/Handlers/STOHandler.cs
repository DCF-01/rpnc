using RPNCalculatorC.Core.Memento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorC.Core.Handlers
{
    public class STOHandler : BaseHandler, IHandler
    {
        public STOHandler(DataContext dataContext) : base(dataContext)
        {
        }

        public void Handle(IRequest req)
        {
            if (req.Value == "sto" && this.context.Calculator.State == CalculatorState.Normal)
            {
                this.context.Calculator.SetState(CalculatorState.Store);
            }
            base.Handle(req);
        }
    }
}
