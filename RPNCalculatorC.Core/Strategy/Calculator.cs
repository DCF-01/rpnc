using RPNCalculatorC.Core.Memento;
using RPNCalculatorC.Core.Handlers;

namespace RPNCalculatorC.Core.Strategy
{
    public class Calculator
    {
        public IStrategy Strategy { get; private set; } = new NormalStrategy();
        public CalculatorState State { get; private set; } = CalculatorState.Normal;
        public bool IsUndo { get; set; } = false;
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

        public void ExecStrategy(DataContext dataContext, IRequest req)
        {
            this.Strategy.Execute(dataContext, req);
        }
    }
}
