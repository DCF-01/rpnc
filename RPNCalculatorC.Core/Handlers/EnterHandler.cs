using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPNCalculatorC.Core.Memento;

namespace RPNCalculatorC.Core.Handlers
{
    public class EnterHandler : BaseHandler, IHandler
    {
        public EnterHandler(DataContext dataContext) : base(dataContext)
        {
        }

        public void Handle(IRequest req)
        {
            if (req.Value == "enter" && this.context.Calculator.State == CalculatorState.Normal)
            {
                var strToPush = this.context.sb.ToString();

                if (!string.IsNullOrWhiteSpace(strToPush))
                {
                    var res = this.context.Calculator.Evaluator.ToSingleValueNumber(this.context.sb);
                    this.context.ValuesStack.Push(res);
                    this.context.sb.Clear();
                }
            }
            
                base.Handle(req);
            

        }
    }
}
