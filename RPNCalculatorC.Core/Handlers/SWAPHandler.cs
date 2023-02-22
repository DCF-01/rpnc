using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorC.Core.Handlers
{
    public class SWAPHandler : BaseHandler, IHandler
    {
        public SWAPHandler(DataContext dataContext) : base(dataContext)
        {
        }

        public void Handle(string req)
        {
            if (req.Trim().ToLower() == "swap")
            {
                if(base.context.CurrentStack.Count < 2)
                {
                    return;
                }


                base.context.CurrentStack.TryPop(out var el1);
                base.context.CurrentStack.TryPop(out var el2);

                base.context.CurrentStack.Push(el1);
                base.context.CurrentStack.Push(el2);
            }
            else
            {
                base.Handle(req);
            }
        }
    }
}
