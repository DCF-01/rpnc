using RPNCalculatorC.Core.Handlers;
using RPNCalculatorC.Core.Memento;
using RPNCalculatorC.Core.Strategy;

namespace RPNCalculatorC.Core
{
    public class ServicesFacade
    {
        public static DataContext DataContext = new DataContext();

        public string[] Calc(string req)
        {
            if (req.Trim().ToLower() == "reset")
            {
                ResetAppState();
                Calc("");
                return GetViewState();
            }

            DataContext.Calculator.ExecStrategy(DataContext, req);

            return GetViewState();
        }

        protected string[] GetViewState(string message = "")
        {
            var stack = new Stack<string>(new Stack<string>(DataContext.CurrentStack));
            stack.TryPop(out var val1);
            stack.TryPop(out var val2);
            stack.TryPop(out var val3);

            return new[] {
                DataContext.sb.ToString(),
                val1 ?? string.Empty,
                val2 ?? string.Empty,
                val3 ?? string.Empty,
                message,
                DataContext.Calculator.State.ToString()
            };
        }

        private void ResetAppState()
        {
            DataContext = new DataContext();
            MementoCaretaker.Reset();
        }
    }
}
