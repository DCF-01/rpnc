using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorC.Core.Handlers.Interfaces
{
    //each event from the View is a request and has a string value
    public interface IRequest
    {
        string Value { get; }
    }
}
