using RPNCalculatorC.Core.Memento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorC.Core.Handlers
{
    public class RCLHandler : BaseHandler, IHandler
    {
        public RCLHandler(DataContext dataContext) : base(dataContext)
        {
        }

        public void Handle(IRequest req)
        {

            if (req.Value == "rcl" && this.context.Calculator.State == CalculatorState.Normal)
            {
                this.context.Calculator.SetState(CalculatorState.Recall);
            }

            base.Handle(req);
        }
    }
}
