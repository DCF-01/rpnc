using RPNCalculatorC.Core.Handlers.Interfaces;
using RPNCalculatorC.Core.Memento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorC.Core.Handlers
{
    /// <summary>
    /// We register this Handler at the end of the chain
    /// It calls the Observers to Notify them that the display state should be updated
    /// This is done after executing every request
    /// </summary>
    public class UpdateDisplayHandler : BaseHandler, IHandler
    {
        public UpdateDisplayHandler(DataContext dataContext) : base(dataContext)
        {
        }

        public void Handle(IRequest req)
        {
            this.context.RequestObservable.NotifyObservers();
            base.Handle(req);

        }
    }
}
