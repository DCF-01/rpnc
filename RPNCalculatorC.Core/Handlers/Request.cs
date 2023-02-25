using RPNCalculatorC.Core.Handlers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorC.Core.Handlers
{
    /// <summary>
    /// Concrete class of IRequest, trim and lower the input string for easier checking
    /// </summary>
    public class Request : IRequest
    {
        public Request(string str)
        {
            Value = str.Trim().ToLower();
        }
        public string Value { get; private set; }
        public override string ToString()
        {
            return this.Value;
        }
    }
}
