using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPNCalculatorC.Core.Memento;

namespace RPNCalculatorC.Core.Handlers
{
    public class CEHandler : BaseHandler, IHandler
    {
        public CEHandler(DataContext dataContext) : base(dataContext)
        {
        }

        public void Handle(string req)
        {
            if (req == "CE")
            {
                this.context.CurrentStack.Clear();
                this.context.sb.Clear();
            }
            else
            {
                base.Handle(req);
            }
        }
    }
}
