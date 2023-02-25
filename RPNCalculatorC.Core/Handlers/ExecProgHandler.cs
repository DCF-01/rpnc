using RPNCalculatorC.Core.Handlers.Interfaces;
using RPNCalculatorC.Core.Memento;
using RPNCalculatorC.Core.Strategy.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorC.Core.Handlers
{
    /// <summary>
    /// Execute the Prog input string and display the result
    /// </summary>
    public class ExecProgHandler : BaseHandler, IHandler
    {
        public ExecProgHandler(DataContext dataContext) : base(dataContext)
        {
        }

        public void Handle(IRequest req)
        {
            if (req.Value == "exec" && this.context.Calculator.State == CalculatorState.PROG)
            {
                var res = this.context.Calculator.Evaluator.EvaluateExpression(this.context.DisplayInput);
                this.context.DisplayInput.Clear();
                this.context.DisplayInput.Add(new Request(res.ToString()));
            }
            
                base.Handle(req);
            
        }
    }
}
