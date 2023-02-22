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

        public void Handle(string req)
        {
            if (req.Trim().ToLower() == "RCL" && this.context.Calculator.State == CalculatorState.Normal)
            {
                this.context.Calculator.SetState(CalculatorState.Recall);
            }
            else
            {
                base.Handle(req);
            }
        }
    }
}
