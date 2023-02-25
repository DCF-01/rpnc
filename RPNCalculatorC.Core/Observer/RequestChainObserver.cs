namespace RPNCalculatorC.Core.Observer
{
    /// <summary>
    /// Observer that stores a delegate and exposes a method for executing it
    /// which is done in the chain of responsibility handler
    /// </summary>
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
