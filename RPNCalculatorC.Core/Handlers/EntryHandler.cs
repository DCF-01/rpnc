using RPNCalculatorC.Core.Memento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorC.Core.Handlers
{
    public class EntryHandler : BaseHandler, IHandler
    {
        public EntryHandler(DataContext dataContext) : base(dataContext)
        {
        }

        public void Handle(IRequest req)
        {
            if ((req.Value != "undo") && (req.Value != "redo"))
            {
                //MementoCaretaker.PushToStack(this.context);
            }
            base.Handle(req);
        }
    }
}
