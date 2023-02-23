using RPNCalculatorC.Core.Memento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorC.Core.Handlers
{
    public class UNDOHandler : BaseHandler, IHandler
    {
        public UNDOHandler(DataContext dataContext) : base(dataContext)
        {
        }

        public void Handle(string req)
        {
            if (req.Trim().ToLower() == "undo")
            {
                var undoState = MementoCaretaker.Undo();

                if(undoState != null)
                {
                    this.context.Restore(undoState);
                }
            }
            
                base.Handle(req);
            
        }
    }
}
