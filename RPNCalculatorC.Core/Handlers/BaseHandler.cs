using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPNCalculatorC.Core.Handlers.Interfaces;
using RPNCalculatorC.Core.Memento;

namespace RPNCalculatorC.Core.Handlers
{
    public abstract class BaseHandler : IHandler
    {
        protected DataContext context { get; set; }
        protected MementoCaretaker mementoCaretaker => MementoCaretaker.GetInstance();
        private IHandler next { get; set; }
        public BaseHandler(DataContext dataContext)
        {
            context = dataContext;
        }

        public void Handle(IRequest req)
        {
            if(this.next != null)
            {
                this.next.Handle(req);
            }
            else
            {
                if ((req.Value != "undo") && (req.Value != "redo"))
                {
                    mementoCaretaker.PushToStack(context);

                    if(context.Calculator.IsUndo)
                    {
                        mementoCaretaker.ResetRedo();
                        context.Calculator.IsUndo = false;
                    }
                }
                
            }
        }

        public void SetNext(IHandler handler)
        {
            next = handler;
        }
    }
}
