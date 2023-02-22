using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorC.Core.Handlers
{
    public class CEHandler : BaseHandler, IHandler
    {
        public CEHandler(DataContext dataContext) : base(dataContext)
        {
        }

        public void Handle(string req)
        {
            if (req == "CE")
            {
                base.context.CurrentStack.Clear();
                base.context.sb.Clear();
            }
            else
            {
                base.Handle(req);
            }
        }
    }
}
