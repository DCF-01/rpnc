using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPNCalculatorC.Core.Memento;

namespace RPNCalculatorC.Core.Handlers
{
    internal class CHSHandler : BaseHandler, IHandler
    {
        public CHSHandler(DataContext dataContext) : base(dataContext)
        {
        }

        public void Handle(string req)
        {
            if(req.Trim().ToLower() == "chs" && this.context.CurrentStack.Count >= 1 && this.context.CalculatorState == CalculatorState.Normal)
            {
                int x = int.Parse(this.context.CurrentStack.Pop()) * -1;
                this.context.CurrentStack.Push(x.ToString());
            }
            else
            {
                base.Handle(req);
            }
        }
    }
}
