using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorC.Core.Handlers
{
    internal class CHSHandler : BaseHandler, IHandler
    {
        public CHSHandler(DataContext dataContext) : base(dataContext)
        {
        }

        public void Handle(string req)
        {
            if(req.Trim().ToLower() == "chs" && base.context.CurrentStack.Count >= 1)
            {
                int x = int.Parse(base.context.CurrentStack.Pop()) * -1;
                base.context.CurrentStack.Push(x.ToString());
            }
            else
            {
                base.Handle(req);
            }
        }
    }
}
