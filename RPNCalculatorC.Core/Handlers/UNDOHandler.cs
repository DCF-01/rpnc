using RPNCalculatorC.Core.Handlers.Interfaces;
using RPNCalculatorC.Core.Memento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorC.Core.Handlers
{
    /// <summary>
    /// Call the memento caretaker and restore the undo stack state
    /// We set IsUndo in case the user performs an operaton after an UNDO request
    /// In that case the REDO stack is cleared to avoid a conflicted stack. Chrome url input undo/redo works similarly
    /// </summary>
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
