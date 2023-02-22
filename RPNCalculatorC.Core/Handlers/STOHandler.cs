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

        public void Handle(string req)
        {
            if (req.Trim().ToLower() == "STO")
            {
                this.context.Calculator.SetState(CalculatorState.Save);
            }
            else
            {
                base.Handle(req);
            }
        }
    }
}
