using ExpressionEvaluator.Core;

namespace ExpressionEvaluator.UI.Win
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            TxtPlay.Text += "7";
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            TxtPlay.Text += "8";
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            TxtPlay.Text += "9";
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            TxtPlay.Text += "4";
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            TxtPlay.Text += "5";
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            TxtPlay.Text += "6";
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            TxtPlay.Text += "1";
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            TxtPlay.Text += "2";
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            TxtPlay.Text += "3";
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            TxtPlay.Text += "0";
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            TxtPlay.Text += ".";
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            TxtPlay.Text += "/";
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            TxtPlay.Text += "*";
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            TxtPlay.Text += "+";
        }

        private void button17_Click_1(object sender, EventArgs e)
        {
            TxtPlay.Text += "-";
        }

        private void button19_Click_1(object sender, EventArgs e)
        {
            TxtPlay.Text += "(";
        }

        private void button20_Click_1(object sender, EventArgs e)
        {
            TxtPlay.Text += ")";
        }

        private void button22_Click(object sender, EventArgs e)
        {
            TxtPlay.Text += "^";
        }

        private void button21_Click_1(object sender, EventArgs e)
        {
            TxtPlay.Text += $"={Evaluator.Evaluate(TxtPlay.Text)}";
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            TxtPlay.Text = TxtPlay.Text.Substring(0, TxtPlay.Text.Length - 1);
        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            TxtPlay.Text = string.Empty;
        }

        private void FuctionEvaluator_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void TxtPlay_Click(object sender, EventArgs e)
        {

        }

        private void TxtPlay_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
