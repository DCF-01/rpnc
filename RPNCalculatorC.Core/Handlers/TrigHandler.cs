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
    /// Toggle InputState: RAD and DEG
    /// </summary>
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
                if (this.context.Calculator.Evaluator.InputState != InputState.RAD)
                {
                    this.context.Calculator.SetInputState(InputState.RAD);
                }
                else
                {
                    this.context.Calculator.SetInputState(InputState.STD);
                }
            }
            else if (req.Value == "deg")
            {
                if (this.context.Calculator.Evaluator.InputState != InputState.DEG)
                {
                    this.context.Calculator.SetInputState(InputState.DEG);
                }
                else
                {
                    this.context.Calculator.SetInputState(InputState.STD);
                }
            }

            base.Handle(req);
        }
    }
}
