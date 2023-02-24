using RPNCalculatorC.Core.Memento;
using RPNCalculatorC.Core.Values;
using System.Text;

namespace RPNCalculatorC.Core.Handlers
{
    public class EnterHandler : BaseHandler, IHandler
    {
        public EnterHandler(DataContext dataContext) : base(dataContext)
        {
        }

        public void Handle(IRequest req)
        {
            if (req.Value == "enter" && this.context.Calculator.State == CalculatorState.Normal)
            {
                var strToPush = this.context.sb.ToString();

                if (!string.IsNullOrWhiteSpace(strToPush))
                {
                    var res = ParseInput(strToPush);
                    this.context.CurrentStack.Push(res);
                    this.context.sb.Clear();
                }
            }
            base.Handle(req);
        }

        private IValue ParseInput(string inputString)
        {
            var first = inputString[0].ToString();
            if (first == "deg" || first == "rad")
            {
                return null;
            }

            var sb = new StringBuilder();
            foreach (var chr in inputString)
            {
                if (chr.ToString() == "deg")
                {
                    return new Deg(double.Parse(sb.ToString()));
                }
                else if (chr.ToString() == "rad")
                {
                    return new Rad(double.Parse(sb.ToString()));
                }
                sb.Append(chr.ToString());
            }

            return new Number(double.Parse(sb.ToString()));
        }
    }
}
