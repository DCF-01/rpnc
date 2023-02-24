using RPNCalculatorC.Core.Strategy;
using RPNCalculatorC.Core.Handlers;
using RPNCalculatorC.Core.Values;

namespace RPNCalculatorC.Core.Memento
{
    public class DataContext
    {
        public Stack<IValue> ValuesStack { get; set; } = new();
        public Stack<IValue> sb = new();
        public Calculator Calculator = new Calculator();
        public Stack<IValue>[] Storage = new Stack<IValue>[10];

        public DataContextMemento Save()
        {
            return new DataContextMemento(this);
        }

        public void Restore(DataContextMemento memento)
        {
            var state = memento.GetState();
            this.ValuesStack = state.ValuesStack;
            this.sb = state.sb;
            this.Storage = state.Storage;
            this.Calculator = state.Calculator;
        }
    }
}
