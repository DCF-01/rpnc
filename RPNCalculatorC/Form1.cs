using RPNCalculatorC.Core;

namespace RPNCalculatorC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonClick(object sender, EventArgs e)
        {
            var a = (sender as Button).Text;

            richTextBox1.Text = a;

            var servicesFacade = new ServicesFacade();

            var res = servicesFacade.Calc(a);


            richTextBox1.Text = res[0];
            richTextBox2.Text = res[1];
            richTextBox3.Text = res[2];
            richTextBox4.Text = res[3];

        }
    }
}