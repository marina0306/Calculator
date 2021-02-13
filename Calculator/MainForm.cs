using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class MainForm : Form
    {
        double num1, num2;

        string operation = "";

        bool startNextNum = false;

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
