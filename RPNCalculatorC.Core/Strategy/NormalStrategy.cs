using RPNCalculatorC.Core.Memento;
using RPNCalculatorC.Core.Handlers;

namespace RPNCalculatorC.Core.Strategy
{
    public class NormalStrategy : IStrategy
    {
        public void Eval(DataContext dataContext, string req)
        {
            var stateHandler = new StateHandler(dataContext);
            var CEHandler = new CEHandler(dataContext);
            var EnterHandler = new EnterHandler(dataContext);
            var NumberHandler = new NumberHandler(dataContext);
            var OperatorHandler = new OperatorHandler(dataContext);
            var SWAPHandler = new SWAPHandler(dataContext);
            var DROPHandler = new DROPHandler(dataContext);
            var CHSHandler = new CHSHandler(dataContext);

            stateHandler.SetNext(CEHandler);
            CEHandler.SetNext(EnterHandler);
            EnterHandler.SetNext(NumberHandler);
            NumberHandler.SetNext(OperatorHandler);
            OperatorHandler.SetNext(SWAPHandler);
            SWAPHandler.SetNext(DROPHandler);
            DROPHandler.SetNext(CHSHandler);

            stateHandler.Handle(req);
        }
    }
}
