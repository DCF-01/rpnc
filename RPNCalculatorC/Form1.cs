using RPNCalculatorC.Core;
using RPNCalculatorC.Core.Observer;

namespace RPNCalculatorC
{
    public partial class Form1 : Form
    {
        private ServicesFacade _servicesFacade = new();
        public static bool Inv = false;
        public Form1()
        {
            InitializeComponent();
            if (ServicesFacade.DataContext.RequestObservable == null)
            {
                SetupObservable();
            }


            //_servicesFacade.Calc("");
        }

        private void SetupObservable()
        {
            var observable = new RequestObservable();
            observable.RegisterObserver(new RequestChainObserver(GetViewState));
            ServicesFacade.DataContext.RequestObservable = observable;
        }

        private void GetViewState(string message = "")
        {
            var stack = new Stack<string>(new Stack<string>(ServicesFacade.DataContext.CurrentStack));
            stack.TryPop(out var val1);
            stack.TryPop(out var val2);
            stack.TryPop(out var val3);
            stack.TryPop(out var val4);

            richTextBox1.Text = string.Join("", ServicesFacade.DataContext.sb.Select(x => x.Value).ToList());
            richTextBox2.Text = val1 ?? string.Empty;
            richTextBox3.Text = val2 ?? string.Empty;
            richTextBox4.Text = val3 ?? string.Empty;
            richTextBox5.Text = message;
            richTextBox6.Text = ServicesFacade.DataContext.Calculator.State.ToString();
            richTextBox7.Text = val4 ?? string.Empty; ;
        }

        private void buttonClick(object sender, EventArgs e)
        {
            var requestStr = (sender as Button).Text;
            this._servicesFacade.Calc(requestStr);
        }

        private void buttonToggleInv(object sender, EventArgs e)
        {
            button28.Text = button28.Text == "SIN" ? "ASIN" : "SIN";
            button35.Text = button35.Text == "COS" ? "ACOS" : "COS";
            button33.Text = button33.Text == "TAN" ? "ATAN" : "TAN";
        }

    }
}