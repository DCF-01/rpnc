using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorC.Core.Memento
{
    public class DataContext
    {
        public Stack<string> CurrentStack { get; set; } = new();
        public StringBuilder sb = new();
        public string[] ViewStack;

        public DataContextMemento Save()
        {
            return new DataContextMemento(this);
        }

        public void Restore(DataContextMemento memento)
        {
            var state = memento.GetState();
            this.CurrentStack = state.CurrentStack;
            this.sb = state.sb;
            this.ViewStack = state.ViewStack;

        }
    }
}
