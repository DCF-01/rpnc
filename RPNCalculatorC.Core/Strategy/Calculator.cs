using RPNCalculatorC.Core.Memento;
using RPNCalculatorC.Core.Strategy.Enums;
using RPNCalculatorC.Core.Handlers.Interfaces;

namespace RPNCalculatorC.Core.Strategy
{
    public class Calculator
    {
        /// <summary>
        /// The calculator holds 2 states, 1 strategy (this sets and executes the Chain of Responsibility / handlers chain)
        /// It has a reference to an Evaluator which holds the logic for calculating normal,trig expressions and stacks
        /// </summary>
        public IStrategy Strategy { get; private set; } = new NormalStrategy();
        public CalculatorState State { get; private set; } = CalculatorState.Normal;
        //public InputState InputState { get; private set; } = InputState.STD;
        public bool IsUndo { get; set; } = false;
        public Evaluator Evaluator = new Evaluator();
        //We set the strategy for execution of handlers (different for Normal and Prog mode)
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

        public void SetInputState(InputState inputState)
        {
            Evaluator.SetInputState(inputState);
        }

        public void ExecStrategy(DataContext dataContext, IRequest req)
        {
            this.Strategy.Execute(dataContext, req);
        }
    }
}
