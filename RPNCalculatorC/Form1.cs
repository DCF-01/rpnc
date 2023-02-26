using RPNCalculatorC.Core.Facade;
using RPNCalculatorC.Core.Observer;

namespace RPNCalculatorC
{
    public partial class Form1 : Form
    {
        private ServicesFacade _servicesFacade = new();
        //public static bool Inv = false;
        public Form1()
        {
            InitializeComponent();
            if (_servicesFacade.DataContext.RequestObservable == null)
            {
                SetupObservable();
            }
        }

        /// <summary>
        /// Setup the observalbe which upon each request chain should execute a Notify() for the RequestChainObserver()
        /// </summary>
        private void SetupObservable()
        {
            var observable = new RequestObservable();
            observable.RegisterObserver(new RequestChainObserver(GetViewState));
            _servicesFacade.DataContext.RequestObservable = observable;
        }

        /// <summary>
        /// Simple method that arranges the DataContext input for the View to display
        /// </summary>
        /// <param name="message"></param>
        private void GetViewState(string message = "")
        {
            var stack = new Stack<string>(new Stack<string>(_servicesFacade.DataContext.CurrentStack));
            stack.TryPop(out var val1);
            stack.TryPop(out var val2);
            stack.TryPop(out var val3);
            stack.TryPop(out var val4);

            richTextBox1.Text = string.Join("", _servicesFacade.DataContext.DisplayInput.Select(x => x.Value).ToList());
            richTextBox2.Text = val1 ?? string.Empty;
            richTextBox3.Text = val2 ?? string.Empty;
            richTextBox4.Text = val3 ?? string.Empty;
            richTextBox5.Text = message;
            richTextBox6.Text = _servicesFacade.DataContext.Calculator.State.ToString();
            richTextBox7.Text = val4 ?? string.Empty;
            richTextBox8.Text = _servicesFacade.DataContext.Calculator.Evaluator.InputState.ToString() ?? string.Empty;
        }

        /// <summary>
        /// Handler that every button except the INV registers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClick(object sender, EventArgs e)
        {
            try
            {
                var requestStr = (sender as Button).Text;
                this._servicesFacade.Calc(requestStr);
            }
            catch(Exception ex)
            {
                GetViewState(ex.Message);
            }
        }

        /// <summary>
        /// Toggle the visibility of the trig functions and their INV
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonToggleInv(object sender, EventArgs e)
        {
            button28.Text = button28.Text == "SIN" ? "ASIN" : "SIN";
            button35.Text = button35.Text == "COS" ? "ACOS" : "COS";
            button33.Text = button33.Text == "TAN" ? "ATAN" : "TAN";
        }

    }
}