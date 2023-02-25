using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPNCalculatorC.Core.Handlers.Interfaces;
using RPNCalculatorC.Core.Memento;
using RPNCalculatorC.Core.Strategy.Enums;

namespace RPNCalculatorC.Core.Handlers
{
    public class EnterHandler : BaseHandler, IHandler
    {
        /// <summary>
        /// The input string is pushed onto the stack. Only done if in Normal mode, NOT Prog state
        /// </summary>
        /// <param name="dataContext"></param>
        public EnterHandler(DataContext dataContext) : base(dataContext)
        {
        }

        public void Handle(IRequest req)
        {
            if (req.Value == "enter" && 
                this.context.Calculator.State == CalculatorState.Normal)
            {
                var inputItem = string.Join("", this.context.DisplayInput.Select(x => x.Value).ToList());

                if (!string.IsNullOrWhiteSpace(inputItem))
                {
                    this.context.CurrentStack.Push(inputItem);
                    this.context.DisplayInput.Clear();
                }
            }
            
                base.Handle(req);
            

        }
    }
}
