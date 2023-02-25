using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorC.Core.Handlers.Interfaces
{
    public interface IHandler
    {
        void Handle(IRequest req);
        void SetNext(IHandler handler);
    }
}
