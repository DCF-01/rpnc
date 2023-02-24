using RPNCalculatorC.Core.Memento;
using RPNCalculatorC.Core.Handlers;

namespace RPNCalculatorC.Core.Strategy
{
    public class NormalStrategy : IStrategy
    {
        public void Execute(DataContext dataContext, IRequest req)
        {
            var trigHandler = new TrigHandler(dataContext);
            var stateHandler = new StateHandler(dataContext);
            var CEHandler = new CEHandler(dataContext);
            var EnterHandler = new EnterHandler(dataContext);
            var NumberHandler = new NumberHandler(dataContext);
            var OperatorHandler = new OperatorHandler(dataContext);
            var SWAPHandler = new SWAPHandler(dataContext);
            var DROPHandler = new DROPHandler(dataContext);
            var CHSHandler = new CHSHandler(dataContext);
            var STOHandler = new STOHandler(dataContext);
            var RCLHandler = new RCLHandler(dataContext);
            var UNDOHandler = new UNDOHandler(dataContext);
            var REDOHandler = new REDOHandler(dataContext);

            trigHandler.SetNext(stateHandler);
            stateHandler.SetNext(CEHandler);
            CEHandler.SetNext(EnterHandler);
            EnterHandler.SetNext(NumberHandler);
            NumberHandler.SetNext(OperatorHandler);
            OperatorHandler.SetNext(SWAPHandler);
            SWAPHandler.SetNext(DROPHandler);
            DROPHandler.SetNext(CHSHandler);
            CHSHandler.SetNext(STOHandler);
            STOHandler.SetNext(RCLHandler);
            RCLHandler.SetNext(UNDOHandler);
            UNDOHandler.SetNext(REDOHandler);

            trigHandler.Handle(req);
        }
    }
}
