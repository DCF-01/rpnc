using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPNCalculatorC.Core.Handlers.Interfaces;
using RPNCalculatorC.Core.Memento;
using RPNCalculatorC.Core.Strategy.Enums;

namespace RPNCalculatorC.Core.Handlers
{
    /// <summary>
    /// Changes the sign of the number at the top of the stack
    /// </summary>
    public class CHSHandler : BaseHandler, IHandler
    {
        public CHSHandler(DataContext dataContext) : base(dataContext)
        {
        }

        public void Handle(IRequest req)
        {
            if(req.Value == "chs" && this.context.CurrentStack.Count >= 1 && this.context.Calculator.State == CalculatorState.Normal)
            {
                double x = double.Parse(this.context.CurrentStack.Pop()) * -1;
                this.context.CurrentStack.Push(x.ToString());
            }
            base.Handle(req);
        }
    }
}
