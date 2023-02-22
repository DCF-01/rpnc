using RPNCalculatorC.Core.Handlers;
using RPNCalculatorC.Core.Memento;
using RPNCalculatorC.Core.Strategy;

namespace RPNCalculatorC.Core
{
    public class ServicesFacade
    {
        /*public static Stack<string> CurrentStack { get; set; } = new();
        public static StringBuilder sb = new();
        public Evaluator Evaluator = new Evaluator();
        public static List<string> Operators = new() { "-", "+", "/", "*" };*/
        public static DataContext DataContext = new DataContext();

        public string[] Calc(string s)
        {

            DataContext.Calculator.ExecStrategy(DataContext, s);

            return GetViewState();
        }

        protected string[] GetViewState()
        {
            var stack = new Stack<string>(new Stack<string>(DataContext.CurrentStack));
            stack.TryPop(out var val1);
            stack.TryPop(out var val2);
            stack.TryPop(out var val3);

            return new[] { DataContext.sb.ToString(), val1 ?? string.Empty, val2 ?? string.Empty, val3 ?? string.Empty };
        }

        /*private string[] FormatResult(string str)
        {
            var stack = new Stack<string>(new Stack<string>(CurrentStack));
            stack.TryPop(out var val1);
            stack.TryPop(out var val2);
            stack.TryPop(out var val3);

            return new[] { str, val1 ?? string.Empty, val2 ?? string.Empty, val3 ?? string.Empty };
        }*/
    }
}
