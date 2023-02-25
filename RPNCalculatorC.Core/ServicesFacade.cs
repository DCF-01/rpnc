using RPNCalculatorC.Core.Handlers;
using RPNCalculatorC.Core.Memento;
using RPNCalculatorC.Core.Observer;

namespace RPNCalculatorC.Core
{
    public class ServicesFacade
    {
        public static DataContext DataContext = new DataContext();
        

        public void Calc(string req)
        {
            /*if(DataContext.RequestObservable == null)
            {
                SetupObservable();
            }*/

            IRequest request = new Request(req.Trim().ToLower());

            if (request.Value == "reset")
            {
                ResetAppState();
                Calc("");
                return;
            }

            DataContext.Calculator.ExecStrategy(DataContext, request);
        }

       /* protected void GetViewState(string message = "")
        {
            var stack = new Stack<string>(new Stack<string>(DataContext.CurrentStack));
            stack.TryPop(out var val1);
            stack.TryPop(out var val2);
            stack.TryPop(out var val3);
            stack.TryPop(out var val4);

            displayBox1 = string.Join("", DataContext.sb.Select(x => x.Value).ToList());
            displayBox2 = val1 ?? string.Empty;
            displayBox3 = val2 ?? string.Empty;
            displayBox4 = val3 ?? string.Empty;
            displayBox5 = message;
            displayBox6 = DataContext.Calculator.State.ToString();
            displayBox7 = val4 ?? string.Empty; ;
        }*/

        private void ResetAppState()
        {
            var observable = DataContext.RequestObservable;
            DataContext = new DataContext();
            DataContext.RequestObservable = observable;

            MementoCaretaker.Reset();
        }

        /*private void SetupObservable() 
        {
            var observable = new RequestObservable();
            observable.RegisterObserver(new RequestChainObserver(GetViewState));
            DataContext.RequestObservable = observable;
        }*/
    }
}
