using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class MainForm : Form
    {
        private double num1, num2;

        private string operation = "";

        private bool startNextNum = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void digit_Click(object sender, EventArgs e)
        {
            if (startNextNum)
            {
                textBox1.Text = "";
            }
            textBox1.Text += ((Button)sender).Text;
            startNextNum = false;
        }

        private void operation_Click(object sender, EventArgs e)
        {
            operation = ((Button)sender).Text;
            startNextNum = true;
            num1 = Double.Parse(textBox1.Text);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Substring(0, textBox1.TextLength - 1);
        }

        private void equals_Click(object sender, EventArgs e)
        {
            num2 = Double.Parse(textBox1.Text);
            num1 = calculate();
            textBox1.Text = num1.ToString();
            operation = "";
        }

        private double calculate()
        {
            switch (operation)
            {
                case "+": 
                    return num1 + num2;
                case "-":
                    return num1 - num2;
                case "×":
                    return num1 * num2;
                case "÷":
                    return num1 / num2;
                case "%":
                    return num1 % num2;
                default:
                    return num1;
            }
        }

        // Обработка нажатий на клавиатуре
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 || 
                e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
            {
                KeysConverter kc = new KeysConverter();
                Button button = new Button();
                string keyText = kc.ConvertToString(e.KeyCode);
                button.Text = keyText.Substring(keyText.Length - 1, 1);
                digit_Click(button, e);
            }
            else
            {
                switch (e.KeyCode)
                {
                    case Keys.Decimal:
                        digit_Click(button11, e);
                        break;
                    case Keys.Back:
                        button16_Click(button16, e);
                        break;
                    case Keys.Delete:
                        button13_Click(button13, e);
                        break;
                    case Keys.Add:
                        operation_Click(button18, e);
                        break;
                    case Keys.Subtract:
                        operation_Click(button17, e);
                        break;
                    case Keys.Multiply:
                        operation_Click(button15, e);
                        break;
                    case Keys.Divide:
                        operation_Click(button14, e);
                        break;
                }
            }
        }

        // Фокус всегда на "=", чтобы нажатие на Enter работало как "="
        private void button19_Leave(object sender, EventArgs e)
        {
            if (this.ActiveControl != comboBox1)
            {
                ((Control)sender).Focus();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            if (str.Equals(""))
            {
                textBox1.Text = "0";
            }
            else if (str.StartsWith("0") && !str.EndsWith(",") && str.Length == 2)
            {
                textBox1.Text = textBox1.Text.Substring(1, 1);
            }
        }
    }
}
