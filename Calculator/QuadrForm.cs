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
        public QuadrForm()
        {
            InitializeComponent();
        }

        private void QuadrForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(textBox1.Text);
            double b = Convert.ToDouble(textBox2.Text);
            double c = Convert.ToDouble(textBox3.Text);

            double x1;
            double x2;

            if (a == 0 && b == 0)
            {
                textBox4.Text = "Нет";
                textBox5.Text = "Любое число";
                textBox6.Text = "Нет";
                textBox7.Text = "Коэффициент при x равен 0, решением уравнения будет любое число";
            }
            else if (a == 0)
            {
                x1 = -c / b;
                textBox4.Text = "Нет";
                textBox5.Text = x1.ToString();
                textBox6.Text = "Нет";
                textBox7.Text = "Уравнение является линейным, имеет одно решение";
            }
            else
            {
                double discriminant = Math.Pow(b, 2) - 4 * a * c;
                textBox4.Text = discriminant.ToString();

                if (discriminant > 0)
                {
                    x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                    x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                    textBox5.Text = x1.ToString();
                    textBox6.Text = x2.ToString();
                }
                else if (discriminant == 0)
                {
                    x1 = -b / (2 * a);
                    textBox5.Text = x1.ToString();
                    textBox6.Text = "Нет";
                    textBox7.Text = "Дискриминант равен 0, уравнение имеет 1 корень";
                }
                else
                {
                    textBox5.Text = "Нет";
                    textBox6.Text = "Нет";
                    textBox7.Text = "Дискриминант меньше 0, корней нет";
                }
            }
        }
    }
}
