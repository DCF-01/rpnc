using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorC.Core.Handlers
{
    public abstract class BaseHandler : IHandler
    {
        protected DataContext context { get; set; }
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
        }

        public void SetNext(IHandler handler)
        {
            next = handler;
        }

        /*protected void GetViewState(string inputBoxString = "")
        {
            var stack = new Stack<string>(new Stack<string>(this.context.CurrentStack));
            stack.TryPop(out var val1);
            stack.TryPop(out var val2);
            stack.TryPop(out var val3);

            context.ViewStack = new[] { this.context.sb.ToString(), val1 ?? string.Empty, val2 ?? string.Empty, val3 ?? string.Empty };
        }*/
    }
}
