using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPNCalculatorC.Core.Memento;

namespace RPNCalculatorC.Core.Handlers
{
    public class OperatorHandler : BaseHandler, IHandler
    {
        public static List<string> Operators = new() { "-", "+", "/", "x", "X", "*" };

        public OperatorHandler(DataContext dataContext) : base(dataContext)
        {
        }

        public void Handle(string req)
        {   
            if (Operators.Contains(req) && this.context.Calculator.State == CalculatorState.PROG)
            {
                base.context.CurrentStack.Push(req);
            }

            else if (Operators.Contains(req) && base.context.CurrentStack.Count >= 2 && this.context.Calculator.State == CalculatorState.Normal)
            {
                var eval = new Evaluator();
                base.context.CurrentStack.Push(req);
                var res = eval.Evaluate(base.context.CurrentStack).ToString();
                base.context.CurrentStack.Push(res);
                base.context.sb.Clear();
            }
            else
            {
                base.Handle(req);
            }
        }
    }
}
