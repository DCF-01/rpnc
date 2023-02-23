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

        public void Handle(IRequest req)
        {
            if (req.Value == "undo")
            {
                var undoState = this.mementoCaretaker.Undo();

                if (undoState != null)
                {
                    this.context.Restore(undoState);
                    this.context.Calculator.IsUndo = true;
                }
            }
            base.Handle(req);
        }
    }
}
