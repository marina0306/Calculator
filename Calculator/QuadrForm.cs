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
    public partial class QuadrForm : Form
    {
        double a,b,c,D,x1,x2;

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        public QuadrForm()
        {
            InitializeComponent();
            
        }

        private void QuadrForm_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedState = comboBox1.SelectedItem.ToString();
            switch (selectedState)
            {
                case "Простой калькулятор":
                    this.Dispose();
                    break;
                case "История":
                    HistoryForm historyForm = new HistoryForm();
                    this.Dispose();
                    historyForm.ShowDialog();
                    break;
                case "Сравнение чисел":
                    CompareForm compareForm = new CompareForm();
                    this.Dispose();
                    compareForm.ShowDialog();
                    break;
                case "2СС/10CC":
                    Conversion conversion = new Conversion();
                    this.Dispose();
                    conversion.ShowDialog();
                    break;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                a = double.Parse(textBox1.Text);
            }
            else a = 0;
            if (textBox2.Text != null)
            {
                b = double.Parse(textBox2.Text);
            }
            else b = 0;
            if (textBox3.Text != null)
            {
                c = double.Parse(textBox3.Text);
            }
            else c = 0;
            if (a == 0 && b == 0)
            {
                textBox5.Text = "Любое число";
                textBox7.Text = "Коэффициент при x равен 0, решением уравнения будет любое число";
            }
            else if (a == 0)
            {
                x1 = -c / b;
                textBox5.Text = x1.ToString();
                textBox7.Text = "Уравнение является линейным, имеет одно решение";
            }
            else
            {
                D = b * b - 4 * a * c;
                textBox4.Text = D.ToString();
                if (D < 0)
                {
                    textBox7.Text = "Дискриминант отрицательный. Решения нет.";
                }
                else if (D == 0)
                {
                    textBox7.Text = "Т.к. D=0, уравнение имеет 1 решение";
                    x1 = (b * (-1)) / 2 * a;
                    textBox5.Text = x1.ToString();
                }
                else
                {
                    textBox7.Text = "Уравнение имеет два решения";
                    x1 = (b * (-1) - Math.Sqrt(D)) / (2 * a);
                    textBox5.Text = x1.ToString();
                    x2 = (b * (-1) + Math.Sqrt(D)) / (2 * a);
                    textBox6.Text = x2.ToString();
                }
            }
        }
    }
}
