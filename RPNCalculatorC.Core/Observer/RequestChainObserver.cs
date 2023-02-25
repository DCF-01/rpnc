namespace RPNCalculatorC.Core.Observer
{
    public class RequestChainObserver : IObserver
    {
        public Action<string> StoredDelegate { get; init; }
        public void Notify()
        {
            StoredDelegate.Invoke("");
        }

        public RequestChainObserver(Action<string> action)
        {
            StoredDelegate = action;
        }
    }
}
