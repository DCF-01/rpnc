﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPNCalculatorC.Core.Strategy;

namespace RPNCalculatorC.Core.Memento
{
    public class DataContext
    {
        public Stack<string> CurrentStack { get; set; } = new();
        public StringBuilder sb = new();
        //public string[] ViewStack = new string[4];
        public Calculator Calculator = new Calculator();
        public string[] Storage = new string[10];

        public DataContextMemento Save()
        {
            return new DataContextMemento(this);
        }

        /*public void SetState(CalculatorState calculatorState)
        {
            CalculatorState = calculatorState;
        }*/

        public void Restore(DataContextMemento memento)
        {
            var state = memento.GetState();
            this.CurrentStack = state.CurrentStack;
            this.sb = state.sb;
            this.Storage = state.Storage;
            this.Calculator = state.Calculator;
            //this.ViewStack = state.ViewStack;

        }
    }
}
