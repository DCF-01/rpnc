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

        public void Handle(string req)
        {
            if (req.Trim().ToLower() == "prog")
            {
                this.context.Calculator.SetStrategy(new ProgStrategy());
            }
            else if(req.Trim().ToLower() == "normal")
            {
                this.context.Calculator.SetStrategy(new NormalStrategy());
            }
            /*else if(req.Trim().ToLower() == "save")
            {
                this.context.Calculator.SetState(CalculatorState.Store);
            }*/
            
                base.Handle(req);
            
        }
    }
}
