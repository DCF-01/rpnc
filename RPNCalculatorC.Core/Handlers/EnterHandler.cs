using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorC.Core.Handlers
{
    public class EnterHandler : BaseHandler, IHandler
    {
        public EnterHandler(DataContext dataContext) : base(dataContext)
        {
        }

        public void Handle(string req)
        {
            if (req.Trim().ToLower() == "enter")
            {
                this.context.CurrentStack.Push(this.context.sb.ToString());
                this.context.sb.Clear();

                /*var l = this.context.CurrentStack.ToList();
                l.Reverse();*/
            }
            else
            {
                base.Handle(req);
            }

        }
    }
}
