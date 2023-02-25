using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPNCalculatorC.Core.Strategy;
using RPNCalculatorC.Core.Handlers;

namespace RPNCalculatorC.Core.Memento
{
    /// <summary>
    /// Stores the intance of DataContext in the _state field
    /// Provides a way to restore / get that state
    /// </summary>
    public class DataContextMemento
    {
        private DataContext _state;
        public DataContextMemento(DataContext state)
        {
            var newState = new DataContext();
            newState.CurrentStack = new Stack<string>(new Stack<string>(state.CurrentStack));
            newState.DisplayInput = state.DisplayInput.ToList();
            newState.Storage = state.Storage.ToArray();
            newState.RequestObservable = state.RequestObservable;

            newState.Calculator = new Calculator();
            newState.Calculator.SetStrategy(state.Calculator.Strategy);
            newState.Calculator.SetState(state.Calculator.State);
            newState.Calculator.SetInputState(state.Calculator.Evaluator.InputState);

            _state = newState;
        }

        public DataContext GetState()
        {
            return _state;
        }
    }
}
