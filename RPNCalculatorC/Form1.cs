using RPNCalculatorC.Core;

namespace RPNCalculatorC
{
    public partial class Form1 : Form
    {
        public static ServicesFacade ServicesFacade = new();
        public static bool Inv = false;
        public Form1()
        {
            InitializeComponent();
            ServicesFacade.Calc("");
        }

        private void buttonClick(object sender, EventArgs e)
        {
            var requestStr = (sender as Button).Text;
            var displayResult = ServicesFacade.Calc(requestStr);


            richTextBox1.Text = displayResult[0];
            richTextBox2.Text = displayResult[1];
            richTextBox3.Text = displayResult[2];
            richTextBox4.Text = displayResult[3];
            richTextBox5.Text = displayResult[4];
            richTextBox6.Text = displayResult[5];

        }

        private void buttonToggleInv(object sender, EventArgs e)
        {
            button28.Text = button28.Text == "SIN" ? "ASIN" : "SIN";
            button35.Text = button35.Text == "COS" ? "ACOS" : "COS";
            button33.Text = button33.Text == "TAN" ? "ATAN" : "TAN";
        }

    }
}