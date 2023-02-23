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

        public void Handle(IRequest req)
        {
            if (req.Value == "exec" && this.context.Calculator.State == CalculatorState.PROG)
            {
                var res = this.context.Calculator.Evaluator.EvaluateExpression(this.context.sb);
                this.context.sb.Clear();
                this.context.sb.Add(new Request(res.ToString()));
            }
            
                base.Handle(req);
            
        }
    }
}
