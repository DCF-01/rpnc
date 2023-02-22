using RPNCalculatorC.Core.Memento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPNCalculatorC.Core.Handlers;

namespace RPNCalculatorC.Core.Strategy
{
    internal class ProgStrategy : IStrategy
    {
        public void Execute(DataContext dataContext, string req)
        {
            var stateHandler = new StateHandler(dataContext);
            var ceHandler = new CEHandler(dataContext);
            var numberHandler = new NumberHandler(dataContext);
            var operatorHandler = new OperatorHandler(dataContext);
            var execProgHandler = new ExecProgHandler(dataContext);

            stateHandler.SetNext(ceHandler);
            ceHandler.SetNext(numberHandler);
            numberHandler.SetNext(operatorHandler);
            operatorHandler.SetNext(execProgHandler);

            stateHandler.Handle(req);
        }
    }
}
