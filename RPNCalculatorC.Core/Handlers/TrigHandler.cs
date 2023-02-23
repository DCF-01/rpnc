using RPNCalculatorC.Core.Memento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorC.Core.Handlers
{
    public class TrigHandler : BaseHandler, IHandler
    {
        public static List<string> Operators = new() { "sin", "cos", "tan", "x", "X", "*" };
        public TrigHandler(DataContext dataContext) : base(dataContext)
        {
        }

        public void Handle(IRequest req)
        {
            if (req.Value == "rad")
            {
                if (this.context.Calculator.State == CalculatorState.RAD)
                {
                    this.context.Calculator.SetState(CalculatorState.Normal);
                }
                else
                {
                    this.context.Calculator.SetState(CalculatorState.RAD);
                }
            }
            else if (req.Value == "deg")
            {
                if (this.context.Calculator.State == CalculatorState.DEG)
                {
                    this.context.Calculator.SetState(CalculatorState.Normal);
                }
                else
                {
                    this.context.Calculator.SetState(CalculatorState.DEG);
                }
            }

            base.Handle(req);

        }
    }
}
