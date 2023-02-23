using RPNCalculatorC.Core.Memento;
using RPNCalculatorC.Core.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorC.Core.Handlers
{
    public class StateHandler : BaseHandler, IHandler
    {
        public StateHandler(DataContext dataContext) : base(dataContext)
        {
        }

        public void Handle(IRequest req)
        {
            if (req.Value == "prog")
            {
                this.context.Calculator.SetStrategy(new ProgStrategy());
            }
            else if (req.Value == "normal")
            {
                this.context.Calculator.SetStrategy(new NormalStrategy());
            }
            base.Handle(req);
        }
    }
}
