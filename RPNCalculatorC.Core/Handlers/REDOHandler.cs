using RPNCalculatorC.Core.Memento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorC.Core.Handlers
{
    public class REDOHandler : BaseHandler, IHandler
    {
        public REDOHandler(DataContext dataContext) : base(dataContext)
        {
        }
        public void Handle(string req)
        {
            if (req.Trim().ToLower() == "redo")
            {
                var redoState = MementoCaretaker.Redo();

                if (redoState != null)
                {
                    this.context.Restore(redoState);
                }

            }
            
                base.Handle(req);
            
        }
    }
}
