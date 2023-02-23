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
        private IHandler next { get; set; }
        protected bool isFirst { get; set; }
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
                    MementoCaretaker.PushToStack(context);
                }
            }
        }

        public void SetNext(IHandler handler)
        {
            next = handler;
        }
    }
}
