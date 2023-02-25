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
    internal class DROPHandler : BaseHandler, IHandler
    {
        /// <summary>
        /// Dtop the number at the top of the stack
        /// </summary>
        /// <param name="dataContext"></param>
        public DROPHandler(DataContext dataContext) : base(dataContext)
        {
        }

        public void Handle(IRequest req)
        {
            if(req.Value == "drop" && this.context.Calculator.State == CalculatorState.Normal)
            {
                this.context.CurrentStack.TryPop(out var el);
            }
            
            base.Handle(req);
        }
    }
}
