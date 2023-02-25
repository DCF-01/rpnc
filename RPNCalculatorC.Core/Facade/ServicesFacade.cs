﻿using RPNCalculatorC.Core.Handlers;
using RPNCalculatorC.Core.Handlers.Interfaces;
using RPNCalculatorC.Core.Memento;
using RPNCalculatorC.Core.Observer;

namespace RPNCalculatorC.Core.Facade
{
    /// <summary>
    /// Provides the DataContext
    /// Exposes a Calc method with takes an input string and attepmts to normalize it for processing
    /// On reset request resets the state of the application
    /// </summary>
    public class ServicesFacade
    {
        public static DataContext DataContext = new DataContext();


        public void Calc(string req)
        {
            if (string.IsNullOrWhiteSpace(req))
            {
                return;
            }

            IRequest request = new Request(req.Trim().ToLower());

            if (request.Value == "reset")
            {
                ResetAppState();
                Calc("");
                return;
            }

            DataContext.Calculator.ExecStrategy(DataContext, request);
        }

        /// <summary>
        /// Sesets the state of the app
        /// </summary>
        private void ResetAppState()
        {
            var observable = DataContext.RequestObservable;
            DataContext = new DataContext();
            DataContext.RequestObservable = observable;

            MementoCaretaker.Reset();
        }
    }
}