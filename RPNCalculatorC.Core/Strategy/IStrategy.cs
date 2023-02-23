using RPNCalculatorC.Core.Memento;
using RPNCalculatorC.Core.Handlers;

namespace RPNCalculatorC.Core.Strategy
{
    public interface IStrategy
    {
        void Execute(DataContext dataContext, IRequest req);
    }
}
