using RPNCalculatorC.Core.Memento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorC.Core.Handlers
{
    internal class ExecProgHandler : BaseHandler, IHandler
    {
        public static string[] Operators = new string[] { "s" };
        public ExecProgHandler(DataContext dataContext) : base(dataContext)
        {
        }

        public void Handle(string req)
        {
            if (req.Trim().ToLower() == "exec" && this.context.Calculator.State == CalculatorState.PROG)
            {
                this.context.Calculator.ExecStrategy(this.context, this.context.sb.ToString());
            }
            else
            {
                base.Handle(req);
            }
        }
    }
}
