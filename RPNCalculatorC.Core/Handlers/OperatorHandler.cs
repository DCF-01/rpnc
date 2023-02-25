using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPNCalculatorC.Core.Handlers.Interfaces;
using RPNCalculatorC.Core.Memento;
using RPNCalculatorC.Core.Strategy.Enums;

namespace RPNCalculatorC.Core.Handlers
{
    /// <summary>
    /// Handles all operator related requests
    /// If the state is Prog any Operator is appended to the display string (if length does not exceed 20)
    /// If the state is Normal, then we perform the following:
    /// For Operators (+,-,x,/) we require that 2 items are on the stack, then we apply the operator
    /// For TrigOperators (sin, cos, tan, asin, acos, atan) we require that 1 item is on the stack, then we apply the operator
    /// For TrigOperators, if the InputState is DEG we convert to RAD then apply the operator
    /// </summary>
    public class OperatorHandler : BaseHandler, IHandler
    {
        public static List<string> Operators = new() { "-", "+", "/", "x", "X", "*" };
        public static List<string> TrigOperators = new() { "sin", "cos", "tan", "asin", "acos", "atan" };
        public static List<InputState> InputStates = new() { InputState.DEG, InputState.RAD };

        public OperatorHandler(DataContext dataContext) : base(dataContext)
        {
        }

        public void Handle(IRequest req)
        {   
            if ((Operators.Contains(req.Value) || TrigOperators.Contains(req.Value)) && this.context.Calculator.State == CalculatorState.PROG && base.context.DisplayInput.Count < 20)
            {
                this.context.DisplayInput.Add(req);
            }

            else if (Operators.Contains(req.Value) && base.context.CurrentStack.Count >= 2 && this.context.Calculator.State == CalculatorState.Normal)
            {
                this.context.CurrentStack.Push(req.Value);

                var res = this.context.Calculator.Evaluator.Evaluate(this.context.CurrentStack).ToString();
                this.context.CurrentStack.Push(res);
                this.context.DisplayInput.Clear();
            }
            else if(TrigOperators.Contains(req.Value) && base.context.CurrentStack.Count >= 1)
            {
                /*//if input is in deg convert to RAD first then continue
                //STD state is treated as RAD
                if (this.context.Calculator.Evaluator.InputState == InputState.DEG)
                {
                    var el = this.context.CurrentStack.Pop();
                    double radians = DegreesToRadians(double.Parse(el));
                    this.context.CurrentStack.Push(radians.ToString());
                }*/
                
                this.context.CurrentStack.Push(req.Value);

                var res = this.context.Calculator.Evaluator.EvaluateTrig(this.context.CurrentStack).ToString();
                this.context.CurrentStack.Push(res);
                this.context.DisplayInput.Clear();
            }
            
            base.Handle(req);
        }

        private double DegreesToRadians(double el) => (Math.PI / 180) * el;
        
    }
}
