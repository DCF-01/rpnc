using RPNCalculatorC.Core.Handlers.Interfaces;
using RPNCalculatorC.Core.Memento;
using RPNCalculatorC.Core.Strategy;
using RPNCalculatorC.Core.Strategy.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorC.Core.Handlers
{
    /// <summary>
    /// Handle the CalculatorState toggle request
    /// </summary>
    public class StateHandler : BaseHandler, IHandler
    {
        public StateHandler(DataContext dataContext) : base(dataContext)
        {
        }

        public void Handle(IRequest req)
        {
            if (req.Value == "prog" && this.context.Calculator.State == CalculatorState.Normal)
            {
                this.context.Calculator.SetStrategy(new ProgStrategy());
            }
            else if (req.Value == "prog" && this.context.Calculator.State == CalculatorState.PROG)
            {
                this.context.Calculator.SetStrategy(new NormalStrategy());
            }
            base.Handle(req);
        }
    }
}
