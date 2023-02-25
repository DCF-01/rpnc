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

        public void Handle(IRequest req)
        {
            if (req.Value == "ce")
            {
                this.context.CurrentStack.Clear();
                this.context.sb.Clear();
                //MementoCaretaker.PushToStack(this.context);
            }
            
            base.Handle(req);
        }
    }
}
