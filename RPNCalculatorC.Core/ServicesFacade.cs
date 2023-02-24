using RPNCalculatorC.Core.Handlers;
using RPNCalculatorC.Core.Memento;
using RPNCalculatorC.Core.Values;

namespace RPNCalculatorC.Core
{
    public class ServicesFacade
    {
        public static DataContext DataContext = new DataContext();

        public string[] Calc(string req)
        {
            IRequest request = new Request(req.Trim().ToLower());

            if (request.Value == "reset")
            {
                ResetAppState();
                Calc("");
                return GetViewState();
            }

            DataContext.Calculator.ExecStrategy(DataContext, request);

            return GetViewState();
        }

        protected string[] GetViewState(string message = "")
        {
            var stack = new Stack<IValue>(new Stack<IValue>(DataContext.CurrentStack));
            stack.TryPop(out var val1);
            stack.TryPop(out var val2);
            stack.TryPop(out var val3);

            return new[] {
                string.Join("", DataContext.sb.Select(x => x.Value).ToList()),
                val1.ToString() ?? string.Empty,
                val2.ToString() ?? string.Empty,
                val3.ToString() ?? string.Empty,
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
