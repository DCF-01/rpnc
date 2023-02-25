using RPNCalculatorC.Core.Strategy;
using RPNCalculatorC.Core.Observer;
using RPNCalculatorC.Core.Handlers.Interfaces;

namespace RPNCalculatorC.Core.Memento
{
    /// <summary>
    /// Hols the CurrentStack (input string stack which we evaluate depending on the request and state)
    /// </summary>
    public class DataContext
    {
        public Stack<string> CurrentStack { get; set; } = new();
        //Store for the Requests that are sent and are NOT on the main stack
        public List<IRequest> DisplayInput = new();
        //The calculator holds 2 states, 1 strategy (this sets and executes the Chain of Responsibility / handlers chain)
        //It has a reference to an Evaluator which holds the logic for calculating normal,trig expressions and stacks
        public Calculator Calculator = new Calculator();
        //Storage for the STO and RCL operations
        public string[] Storage = new string[10];
        //The observable to which we register observers (the RequestChainObserver which updates the display state)
        public IObservable RequestObservable { get; set; }
        //A method that returns a new memento - for UNDO / REDO
        public DataContextMemento Save()
        {
            return new DataContextMemento(this);
        }
        //Restore the state to the state of a previous saved memento
        public void Restore(DataContextMemento memento)
        {
            var state = memento.GetState();
            this.CurrentStack = state.CurrentStack;
            this.DisplayInput = state.DisplayInput;
            this.Storage = state.Storage;
            this.Calculator = state.Calculator;
            this.RequestObservable = state.RequestObservable;
        }
    }
}
