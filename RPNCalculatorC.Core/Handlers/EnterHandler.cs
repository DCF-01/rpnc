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
            if (req.Value == "enter" && 
                (this.context.Calculator.State == CalculatorState.Normal || 
                this.context.Calculator.State == CalculatorState.DEG || 
                this.context.Calculator.State == CalculatorState.RAD))
            {
                var strToPush = this.context.sb.ToString();

                if (!string.IsNullOrWhiteSpace(strToPush))
                {
                    this.context.CurrentStack.Push(string.Join("", this.context.sb.Select(x => x.Value).ToList()));
                    this.context.sb.Clear();
                }
            }
            
                base.Handle(req);
            

        }
    }
}
