using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorC.Core.Handlers
{
    public interface IHandler
    {
        void Handle(string req);
        void SetNext(IHandler handler);
    }
}
