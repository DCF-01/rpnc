using RPNCalculatorC.Core.Memento;
using RPNCalculatorC.Core.Handlers.Interfaces;

namespace RPNCalculatorC.Core.Strategy
{
    /// <summary>
    /// Strategy Interface, exposes an Execute method that executes the strategy
    /// that the Calculator holds (DataContext -> Calculator) 
    /// </summary>
    public interface IStrategy
    {
        void Execute(DataContext dataContext, IRequest req);
    }
}
