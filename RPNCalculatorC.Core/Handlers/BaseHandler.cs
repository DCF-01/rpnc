using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void Handle(string req)
        {
            if(this.next != null)
            {
                this.next.Handle(req);
            }
            else
            {
                if ((req.Trim().ToLower() != "undo") && (req.Trim().ToLower() != "redo"))
                {
                    mementoCaretaker.PushToStack(context);

                    if(context.Calculator.State == CalculatorState.Undo)
                    {
                        mementoCaretaker.ResetRedo();
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
