using RPNCalculatorC.Core;

namespace RPNCalculatorC
{
    public partial class Form1 : Form
    {
        public static ServicesFacade ServicesFacade = new();
        public Form1()
        {
            InitializeComponent();
            ServicesFacade.Calc("");
        }

        private void buttonClick(object sender, EventArgs e)
        {
            var a = (sender as Button).Text;
            var res = ServicesFacade.Calc(a);


            richTextBox1.Text = res[0];
            richTextBox2.Text = res[1];
            richTextBox3.Text = res[2];
            richTextBox4.Text = res[3];
            richTextBox5.Text = res[4];
            richTextBox6.Text = res[5];

        }
    }
}