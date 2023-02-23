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
                var res = this.context.Calculator.Evaluator.EvaluateExpression(this.context.sb.ToString());
                this.context.sb.Clear();
                this.context.sb.Append(res.ToString());
            }
            
                base.Handle(req);
            
        }
    }
}
