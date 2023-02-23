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
        public IStrategy Strategy { get; private set; } = new NormalStrategy();
        public CalculatorState State { get; private set; } = CalculatorState.Normal;
        public Evaluator Evaluator = new Evaluator();
        public void SetStrategy(IStrategy strategy)
        {
            this.Strategy = strategy;

            if(strategy is NormalStrategy)
            {
                this.State = CalculatorState.Normal;
            }

            if(strategy is ProgStrategy)
            {
                this.State = CalculatorState.PROG;
            }
        }

        public void SetState(CalculatorState calculatorState)
        {
            State = calculatorState;
        }

        public void ExecStrategy(DataContext dataContext, string req)
        {
            this.Strategy.Execute(dataContext, req);
        }
    }
}
