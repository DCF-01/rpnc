﻿using RPNCalculatorC.Core.Handlers.Interfaces;
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
    /// If state is Normal we retrieve the stored value and put in in the display string
    /// </summary>
    public class RCLHandler : BaseHandler, IHandler
    {
        public RCLHandler(DataContext dataContext) : base(dataContext)
        {
        }

        public void Handle(IRequest req)
        {

            if (req.Value == "rcl" && this.context.Calculator.State == CalculatorState.Normal)
            {
                this.context.Calculator.SetState(CalculatorState.Recall);
            }

            base.Handle(req);
        }
    }
}
