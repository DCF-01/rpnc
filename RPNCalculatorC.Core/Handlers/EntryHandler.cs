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

        public void Handle(string req)
        {
            if ((req.Trim().ToLower() != "undo") && (req.Trim().ToLower() != "redo"))
            {
                //MementoCaretaker.PushToStack(this.context);
            }
            base.Handle(req);
        }
    }
}
