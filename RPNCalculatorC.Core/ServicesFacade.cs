using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPNCalculatorC.Core.Handlers;

namespace RPNCalculatorC.Core
{
    public class ServicesFacade
    {
        /*public static Stack<string> CurrentStack { get; set; } = new();
        public static StringBuilder sb = new();
        public Evaluator Evaluator = new Evaluator();
        public static List<string> Operators = new() { "-", "+", "/", "*" };*/
        public static DataContext dataContext = new DataContext();

        public string[] Calc(string s)
        {



            var CEHandler = new CEHandler(dataContext);
            var EnterHandler = new EnterHandler(dataContext);
            var NumberHandler = new NumberHandler(dataContext);
            var OperatorHandler = new OperatorHandler(dataContext);
            var SWAPHandler = new SWAPHandler(dataContext);
            var DROPHandler = new DROPHandler(dataContext);
            var CHSHandler = new CHSHandler(dataContext);

            CEHandler.SetNext(EnterHandler);
            EnterHandler.SetNext(NumberHandler);
            NumberHandler.SetNext(OperatorHandler);
            OperatorHandler.SetNext(SWAPHandler);
            SWAPHandler.SetNext(DROPHandler);
            DROPHandler.SetNext(CHSHandler);

            //start the chain
            CEHandler.Handle(s);

            /*if (s == "CE")
            {
                CurrentStack.Clear();
                sb.Clear();
                return FormatResult(string.Empty);
            }*/

            /*if (s.Trim().ToLower() == "enter")
            {
                CurrentStack.Push(sb.ToString());
                sb.Clear();

                var l = CurrentStack.ToList();
                l.Reverse();
                return FormatResult(CurrentStack.Peek());
            }*/

            /*if (int.TryParse(s, out var x))
            {
                sb.Append(s);
                return FormatResult(sb.ToString());
            }*/

            /*CurrentStack.Push(s);
            var res = Evaluator.Evaluate(CurrentStack).ToString();
            CurrentStack.Push(res);
            return FormatResult(res);*/

            

            return GetViewState();
        }

        protected string[] GetViewState()
        {
            var stack = new Stack<string>(new Stack<string>(dataContext.CurrentStack));
            stack.TryPop(out var val1);
            stack.TryPop(out var val2);
            stack.TryPop(out var val3);

            return new[] { dataContext.sb.ToString(), val1 ?? string.Empty, val2 ?? string.Empty, val3 ?? string.Empty };
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
