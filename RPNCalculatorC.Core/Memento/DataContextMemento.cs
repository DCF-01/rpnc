using System;
using RPNCalculatorC.Core.Strategy;
using RPNCalculatorC.Core.Values;

namespace RPNCalculatorC.Core.Memento
{
    public class DataContextMemento
    {
        private DataContext _state;
        public DataContextMemento(DataContext state)
        {
            var newState = new DataContext();
            newState.ValuesStack = new Stack<IValue>(new Stack<IValue>(state.ValuesStack));
            newState.sb = new Stack<IValue>(new Stack<IValue>(state.sb));
            newState.Storage = state.Storage.ToArray();

            newState.Calculator = new Calculator();
            newState.Calculator.SetStrategy(state.Calculator.Strategy);
            newState.Calculator.SetState(state.Calculator.State);

            _state = newState;
        }

        public DataContext GetState()
        {
            return _state;
        }
    }
}
