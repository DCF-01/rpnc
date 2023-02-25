using RPNCalculatorC.Core.Memento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorC.Core.Handlers
{
    internal class UpdateDisplayHandler : BaseHandler, IHandler
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
