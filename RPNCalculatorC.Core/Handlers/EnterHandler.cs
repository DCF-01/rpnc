using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPNCalculatorC.Core.Memento;

namespace RPNCalculatorC.Core.Handlers
{
    public class EnterHandler : BaseHandler, IHandler
    {
        public EnterHandler(DataContext dataContext) : base(dataContext)
        {
        }

        public void Handle(string req)
        {
            if (req.Trim().ToLower() == "enter" && this.context.Calculator.State == CalculatorState.Normal)
            {
                var strToPush = this.context.sb.ToString();

                if (!string.IsNullOrWhiteSpace(strToPush))
                {
                    this.context.CurrentStack.Push(this.context.sb.ToString());
                    this.context.sb.Clear();
                    //MementoCaretaker.PushToStack(this.context);
                }
            }
            
                base.Handle(req);
            

        }
    }
}
