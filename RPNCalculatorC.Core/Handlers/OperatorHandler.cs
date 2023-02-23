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
                this.context.sb.Append(req);
            }

            else if (Operators.Contains(req) && base.context.CurrentStack.Count >= 2 && this.context.Calculator.State == CalculatorState.Normal)
            {
                var eval = new Evaluator();
                this.context.CurrentStack.Push(req);

                var res = this.context.Calculator.Evaluator.Evaluate(this.context.CurrentStack).ToString();
                this.context.CurrentStack.Push(res);
                this.context.sb.Clear();
                //MementoCaretaker.PushToStack(this.context);
            }
            
                base.Handle(req);
            
        }
    }
}
