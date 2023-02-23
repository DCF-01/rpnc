using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorC.Core.Memento
{
    public class DataContextMemento
    {
        private DataContext _state;
        public DataContextMemento(DataContext state)
        {
            var newState = new DataContext();
            newState.CurrentStack = new Stack<string>(new Stack<string>(state.CurrentStack));
            newState.sb = new StringBuilder(state.sb.ToString());
            newState.Storage = state.Storage.ToArray();
            //newState.ViewStack = state.ViewStack.ToArray();

            _state = newState;
        }

        public DataContext GetState()
        {
            return _state;
        }
    }
}
