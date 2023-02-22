using RPNCalculatorC.Core.Memento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorC.Core.Strategy
{
    public class Calculator
    {
        public IStrategy strategy { get; private set; } = new NormalStrategy();
        public CalculatorState state { get; private set; } = CalculatorState.Normal;
        public void SetStrategy(IStrategy strategy)
        {
            this.strategy = strategy;

            if(strategy is NormalStrategy)
            {
                this.state = CalculatorState.Normal;
            }

            if(strategy is ProgStrategy)
            {
                this.state = CalculatorState.PROG;
            }
        }

        public void SetState(CalculatorState calculatorState)
        {
            state = calculatorState;
        }

        public void Exec(DataContext dataContext, string req)
        {
            this.strategy.Eval(dataContext, req);
        }
    }
}
