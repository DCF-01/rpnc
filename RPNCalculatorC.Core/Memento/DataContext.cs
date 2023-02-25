using RPNCalculatorC.Core.Strategy;
using RPNCalculatorC.Core.Handlers;
using RPNCalculatorC.Core.Observer;

namespace RPNCalculatorC.Core.Memento
{
    public class DataContext
    {
        public Stack<string> CurrentStack { get; set; } = new();
        public List<IRequest> sb = new();
        public Calculator Calculator = new Calculator();
        public string[] Storage = new string[10];
        public IObservable RequestObservable { get; set; }

        public DataContextMemento Save()
        {
            return new DataContextMemento(this);
        }

        public void Restore(DataContextMemento memento)
        {
            var state = memento.GetState();
            this.CurrentStack = state.CurrentStack;
            this.sb = state.sb;
            this.Storage = state.Storage;
            this.Calculator = state.Calculator;
            this.RequestObservable = state.RequestObservable;
        }
    }
}
