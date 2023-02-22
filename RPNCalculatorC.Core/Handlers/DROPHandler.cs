using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorC.Core.Handlers
{
    internal class DROPHandler : BaseHandler, IHandler
    {
        public DROPHandler(DataContext dataContext) : base(dataContext)
        {
        }

        public void Handle(string req)
        {
            if(req.Trim().ToLower() == "drop")
            {
                base.context.CurrentStack.TryPop(out var el1);
            }
            else
            {
                base.Handle(req);
            }
        }
    }
}
