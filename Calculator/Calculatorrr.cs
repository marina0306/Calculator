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
    public partial class Calculatorrr : Form
    {

        private double num1, num2, memory = 0;

        private string operation = "", history = "";

        private bool startNextNum = false;

        double a, b, c, D, x1, x2;

        ConverterDeAndBi converterDeAndBi = new ConverterDeAndBi();
        ConverterDeAndBi converter = new ConverterDeAndBi();

        private bool binaryCount = false;

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Substring(0, textBox1.TextLength - 1);
        }

        public Calculatorrr()
        {
            InitializeComponent();
        }

        private void digit_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "ОШИБКА")
            {
                textBox1.Text = "";
            }
            if (startNextNum)
            {
                textBox1.Text = "";
            }

            if(textBox1.Text.Length < 8)
            {
                textBox1.Text += ((Button)sender).Text;
            }
            startNextNum = false;
        }

        private void operation_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "ОШИБКА")
            {
                textBox1.Text = "0";
            }
            operation = ((Button)sender).Text;
            startNextNum = true;
            num1 = Double.Parse(textBox1.Text);
        }

        // Фокус всегда на "=", чтобы нажатие на Enter работало как "="
        private void button19_Leave(object sender, EventArgs e)
        {
            if (this.ActiveControl != comboBox1)
            {
                ((Control)sender).Focus();
            }
        }

        private void buttonPlMin_Click(object sender, EventArgs e)
        {
            double d = Double.Parse(textBox1.Text);
            d *= -1;
            textBox1.Text = d.ToString();
        }

        private void Calculatorrr_Load(object sender, EventArgs e)
        {
            textBox8.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (textBox8.Text != "")
            {
                string textA = textBox8.Text.Remove(0, 1);

                foreach (char a in textA)
                {
                    if (a == '-')
                    {
                        MessageBox.Show("Число a введено некорректно");
                        return;
                    }
                }

                a = double.Parse(textBox8.Text);
            }
            else textBox8.Text = "0";
            if (textBox2.Text != "")
            {
                string textB = textBox2.Text.Remove(0, 1);
                foreach (char b in textB)
                {
                    if (b == '-')
                    {
                        MessageBox.Show("Число b введено некорректно");
                        return;
                    }
                }

                b = double.Parse(textBox2.Text);
            }
            else textBox2.Text = "0";
            if (textBox3.Text != "")
            {
                string textC = textBox3.Text.Remove(0, 1);

                foreach (char c in textC)
                {
                    if (c == '-')
                    {
                        MessageBox.Show("Число c введено некорректно");
                        return;
                    }
                }

                c = double.Parse(textBox3.Text);
            }
            else textBox3.Text = "0";

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

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '0' && e.KeyChar != '1' && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (textBox11.Text != "" && textBox10.Text != "")
            {
                double a = converterDeAndBi.binaryToDecimal(textBox10.Text, textBox10.Text.Length);
                double b = Double.Parse(textBox11.Text);
                if (a.Equals(b))
                {
                    textBox9.Text = "Числа равны";
                }
                else
                    textBox9.Text = "Числа не равны";
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите числа");
            }
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string selectedState = comboBox1.SelectedItem.ToString();
                if (textBox14.Text != "")
                {
                    switch (selectedState)
                    {
                        case "Десятичная":
                            {
                                string number = textBox14.Text;
                                foreach(char c in number)
                                {
                                    if (c != '0' && c != '1')
                                    {
                                        MessageBox.Show("Введенное число не является двоичным");
                                        return;
                                    }
                                }
                                textBox13.Text = converter.binaryToDecimal(textBox14.Text, textBox14.Text.Length).ToString();
                                break;
                            }
                        case "Двоичная":
                            textBox13.Text = converter.ConvertTo2(textBox14.Text);
                            break;

                    }
                }
                else
                {
                    MessageBox.Show("Введите число");
                }
            }
            else
            {
                MessageBox.Show("Выберите систему счисления");
            }
        }

        private void colorForm(string bgrd, int bgrdR, int bgrdG, int bgrdB, string txtBgrd, 
            int txtBgrdR, int txtBgrdG, int txtBgrdB, BorderStyle txtBord, string txtFont, 
            int txtFontR, int txtFontG, int txtFontB, string btnBgrd, int btnBgrdR, int btnBgrdG, 
            int btnBgrdB, string btnBord, string btnFont, string eqBgrd, int eqBgrdR, int eqBgrdG, 
            int eqBgrdB, string eqBord, int eqBordR, int eqBordG, int eqBordB, string lbl)
        {
            if (bgrd == "")
            {
                Calculator.BackColor = Color.FromArgb(bgrdR, bgrdG, bgrdB);
                Quadr.BackColor = Color.FromArgb(bgrdR, bgrdG, bgrdB);
                Compare.BackColor = Color.FromArgb(bgrdR, bgrdG, bgrdB);
                CountSyst.BackColor = Color.FromArgb(bgrdR, bgrdG, bgrdB);
            }
            else
            {
                Calculator.BackColor = Color.FromName(bgrd);
                Quadr.BackColor = Color.FromName(bgrd);
                Compare.BackColor = Color.FromName(bgrd);
                CountSyst.BackColor = Color.FromName(bgrd);
            }

            if(txtBgrd == "")
            {
                textBox1.BackColor = Color.FromArgb(txtBgrdR, txtBgrdG, txtBgrdB);
                textBox2.BackColor = Color.FromArgb(txtBgrdR, txtBgrdG, txtBgrdB);
                textBox3.BackColor = Color.FromArgb(txtBgrdR, txtBgrdG, txtBgrdB);
                textBox4.BackColor = Color.FromArgb(txtBgrdR, txtBgrdG, txtBgrdB);
                textBox5.BackColor = Color.FromArgb(txtBgrdR, txtBgrdG, txtBgrdB);
                textBox6.BackColor = Color.FromArgb(txtBgrdR, txtBgrdG, txtBgrdB);
                textBox7.BackColor = Color.FromArgb(txtBgrdR, txtBgrdG, txtBgrdB);
                textBox8.BackColor = Color.FromArgb(txtBgrdR, txtBgrdG, txtBgrdB);
                textBox9.BackColor = Color.FromArgb(txtBgrdR, txtBgrdG, txtBgrdB);
                textBox10.BackColor = Color.FromArgb(txtBgrdR, txtBgrdG, txtBgrdB);
                textBox11.BackColor = Color.FromArgb(txtBgrdR, txtBgrdG, txtBgrdB);
                textBox13.BackColor = Color.FromArgb(txtBgrdR, txtBgrdG, txtBgrdB);
                textBox14.BackColor = Color.FromArgb(txtBgrdR, txtBgrdG, txtBgrdB);
                comboBox1.BackColor = Color.FromArgb(txtBgrdR, txtBgrdG, txtBgrdB);
            }
            else
            {
                textBox1.BackColor = Color.FromName(txtBgrd);
                textBox2.BackColor = Color.FromName(txtBgrd);
                textBox3.BackColor = Color.FromName(txtBgrd);
                textBox4.BackColor = Color.FromName(txtBgrd);
                textBox5.BackColor = Color.FromName(txtBgrd);
                textBox6.BackColor = Color.FromName(txtBgrd);
                textBox7.BackColor = Color.FromName(txtBgrd);
                textBox8.BackColor = Color.FromName(txtBgrd);
                textBox9.BackColor = Color.FromName(txtBgrd);
                textBox10.BackColor = Color.FromName(txtBgrd);
                textBox11.BackColor = Color.FromName(txtBgrd);
                textBox13.BackColor = Color.FromName(txtBgrd);
                textBox14.BackColor = Color.FromName(txtBgrd);
                comboBox1.BackColor = Color.FromName(txtBgrd);
            }

            textBox1.BorderStyle = txtBord;
            textBox2.BorderStyle = txtBord;
            textBox3.BorderStyle = txtBord;
            textBox4.BorderStyle = txtBord;
            textBox5.BorderStyle = txtBord;
            textBox6.BorderStyle = txtBord;
            textBox7.BorderStyle = txtBord;
            textBox8.BorderStyle = txtBord;
            textBox9.BorderStyle = txtBord;
            textBox10.BorderStyle = txtBord;
            textBox11.BorderStyle = txtBord;
            textBox13.BorderStyle = txtBord;
            textBox14.BorderStyle = txtBord;

            if (txtFont == "")
            {
                textBox1.ForeColor = Color.FromArgb(txtFontR, txtFontG, txtFontB);
                textBox2.ForeColor = Color.FromArgb(txtFontR, txtFontG, txtFontB);
                textBox3.ForeColor = Color.FromArgb(txtFontR, txtFontG, txtFontB);
                textBox4.ForeColor = Color.FromArgb(txtFontR, txtFontG, txtFontB);
                textBox5.ForeColor = Color.FromArgb(txtFontR, txtFontG, txtFontB);
                textBox6.ForeColor = Color.FromArgb(txtFontR, txtFontG, txtFontB);
                textBox7.ForeColor = Color.FromArgb(txtFontR, txtFontG, txtFontB);
                textBox8.ForeColor = Color.FromArgb(txtFontR, txtFontG, txtFontB);
                textBox9.ForeColor = Color.FromArgb(txtFontR, txtFontG, txtFontB);
                textBox10.ForeColor = Color.FromArgb(txtFontR, txtFontG, txtFontB);
                textBox11.ForeColor = Color.FromArgb(txtFontR, txtFontG, txtFontB);
                textBox13.ForeColor = Color.FromArgb(txtFontR, txtFontG, txtFontB);
                textBox14.ForeColor = Color.FromArgb(txtFontR, txtFontG, txtFontB);
                comboBox1.ForeColor = Color.FromArgb(txtFontR, txtFontG, txtFontB);
            }
            else
            {
                textBox1.ForeColor = Color.FromName(txtFont);
                textBox2.ForeColor = Color.FromName(txtFont);
                textBox3.ForeColor = Color.FromName(txtFont);
                textBox4.ForeColor = Color.FromName(txtFont);
                textBox5.ForeColor = Color.FromName(txtFont);
                textBox6.ForeColor = Color.FromName(txtFont);
                textBox7.ForeColor = Color.FromName(txtFont);
                textBox8.ForeColor = Color.FromName(txtFont);
                textBox9.ForeColor = Color.FromName(txtFont);
                textBox10.ForeColor = Color.FromName(txtFont);
                textBox11.ForeColor = Color.FromName(txtFont);
                textBox13.ForeColor = Color.FromName(txtFont);
                textBox14.ForeColor = Color.FromName(txtFont);
                comboBox1.ForeColor = Color.FromName(txtFont);
            }

            if (btnBgrd == "")
            {
                button1.BackColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button2.BackColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button3.BackColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button4.BackColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button5.BackColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button6.BackColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button7.BackColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button8.BackColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button9.BackColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button10.BackColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button11.BackColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button12.BackColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button13.BackColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button14.BackColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button15.BackColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button16.BackColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button17.BackColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button18.BackColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button20.BackColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button21.BackColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button22.BackColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button23.BackColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button25.BackColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button26.BackColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button27.BackColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button28.BackColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                buttonPlMin.BackColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);

                button1.FlatAppearance.BorderColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button2.FlatAppearance.BorderColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button3.FlatAppearance.BorderColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button4.FlatAppearance.BorderColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button5.FlatAppearance.BorderColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button6.FlatAppearance.BorderColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button7.FlatAppearance.BorderColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button8.FlatAppearance.BorderColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button9.FlatAppearance.BorderColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button10.FlatAppearance.BorderColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button11.FlatAppearance.BorderColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button12.FlatAppearance.BorderColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button13.FlatAppearance.BorderColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button14.FlatAppearance.BorderColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button15.FlatAppearance.BorderColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button16.FlatAppearance.BorderColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button17.FlatAppearance.BorderColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button18.FlatAppearance.BorderColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button20.FlatAppearance.BorderColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button21.FlatAppearance.BorderColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button22.FlatAppearance.BorderColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button23.FlatAppearance.BorderColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button25.FlatAppearance.BorderColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button26.FlatAppearance.BorderColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button27.FlatAppearance.BorderColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                button28.FlatAppearance.BorderColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
                buttonPlMin.FlatAppearance.BorderColor = Color.FromArgb(btnBgrdR, btnBgrdG, btnBgrdB);
            }
            else
            {
                button1.BackColor = Color.FromName(btnBgrd);
                button2.BackColor = Color.FromName(btnBgrd);
                button3.BackColor = Color.FromName(btnBgrd);
                button4.BackColor = Color.FromName(btnBgrd);
                button5.BackColor = Color.FromName(btnBgrd);
                button6.BackColor = Color.FromName(btnBgrd);
                button7.BackColor = Color.FromName(btnBgrd);
                button8.BackColor = Color.FromName(btnBgrd);
                button9.BackColor = Color.FromName(btnBgrd);
                button10.BackColor = Color.FromName(btnBgrd);
                button11.BackColor = Color.FromName(btnBgrd);
                button12.BackColor = Color.FromName(btnBgrd);
                button13.BackColor = Color.FromName(btnBgrd);
                button14.BackColor = Color.FromName(btnBgrd);
                button15.BackColor = Color.FromName(btnBgrd);
                button16.BackColor = Color.FromName(btnBgrd);
                button17.BackColor = Color.FromName(btnBgrd);
                button18.BackColor = Color.FromName(btnBgrd);
                button20.BackColor = Color.FromName(btnBgrd);
                button21.BackColor = Color.FromName(btnBgrd);
                button22.BackColor = Color.FromName(btnBgrd);
                button23.BackColor = Color.FromName(btnBgrd);
                button25.BackColor = Color.FromName(btnBgrd);
                button26.BackColor = Color.FromName(btnBgrd);
                button27.BackColor = Color.FromName(btnBgrd);
                button28.BackColor = Color.FromName(btnBgrd);
                buttonPlMin.BackColor = Color.FromName(btnBgrd);

                button1.FlatAppearance.BorderColor = Color.FromName(btnBgrd);
                button2.FlatAppearance.BorderColor = Color.FromName(btnBgrd);
                button3.FlatAppearance.BorderColor = Color.FromName(btnBgrd);
                button4.FlatAppearance.BorderColor = Color.FromName(btnBgrd);
                button5.FlatAppearance.BorderColor = Color.FromName(btnBgrd);
                button6.FlatAppearance.BorderColor = Color.FromName(btnBgrd);
                button7.FlatAppearance.BorderColor = Color.FromName(btnBgrd);
                button8.FlatAppearance.BorderColor = Color.FromName(btnBgrd);
                button9.FlatAppearance.BorderColor = Color.FromName(btnBgrd);
                button10.FlatAppearance.BorderColor = Color.FromName(btnBgrd);
                button11.FlatAppearance.BorderColor = Color.FromName(btnBgrd);
                button12.FlatAppearance.BorderColor = Color.FromName(btnBgrd);
                button13.FlatAppearance.BorderColor = Color.FromName(btnBgrd);
                button14.FlatAppearance.BorderColor = Color.FromName(btnBgrd);
                button15.FlatAppearance.BorderColor = Color.FromName(btnBgrd);
                button16.FlatAppearance.BorderColor = Color.FromName(btnBgrd);
                button17.FlatAppearance.BorderColor = Color.FromName(btnBgrd);
                button18.FlatAppearance.BorderColor = Color.FromName(btnBgrd);
                button20.FlatAppearance.BorderColor = Color.FromName(btnBgrd);
                button21.FlatAppearance.BorderColor = Color.FromName(btnBgrd);
                button22.FlatAppearance.BorderColor = Color.FromName(btnBgrd);
                button23.FlatAppearance.BorderColor = Color.FromName(btnBgrd);
                button25.FlatAppearance.BorderColor = Color.FromName(btnBgrd);
                button26.FlatAppearance.BorderColor = Color.FromName(btnBgrd);
                button27.FlatAppearance.BorderColor = Color.FromName(btnBgrd);
                button28.FlatAppearance.BorderColor = Color.FromName(btnBgrd);
                buttonPlMin.FlatAppearance.BorderColor = Color.FromName(btnBgrd);
            }

            button1.ForeColor = Color.FromName(btnFont);
            button2.ForeColor = Color.FromName(btnFont);
            button3.ForeColor = Color.FromName(btnFont);
            button4.ForeColor = Color.FromName(btnFont);
            button5.ForeColor = Color.FromName(btnFont);
            button6.ForeColor = Color.FromName(btnFont);
            button7.ForeColor = Color.FromName(btnFont);
            button8.ForeColor = Color.FromName(btnFont);
            button9.ForeColor = Color.FromName(btnFont);
            button10.ForeColor = Color.FromName(btnFont);
            button11.ForeColor = Color.FromName(btnFont);
            button12.ForeColor = Color.FromName(btnFont);
            button13.ForeColor = Color.FromName(btnFont);
            button14.ForeColor = Color.FromName(btnFont);
            button15.ForeColor = Color.FromName(btnFont);
            button16.ForeColor = Color.FromName(btnFont);
            button17.ForeColor = Color.FromName(btnFont);
            button18.ForeColor = Color.FromName(btnFont);
            button19.ForeColor = Color.FromName(btnFont);
            button20.ForeColor = Color.FromName(btnFont);
            button21.ForeColor = Color.FromName(btnFont);
            button22.ForeColor = Color.FromName(btnFont);
            button23.ForeColor = Color.FromName(btnFont);
            button25.ForeColor = Color.FromName(btnFont);
            button26.ForeColor = Color.FromName(btnFont);
            button27.ForeColor = Color.FromName(btnFont);
            button28.ForeColor = Color.FromName(btnFont);
            buttonPlMin.ForeColor = Color.FromName(btnFont);

            if (eqBgrd == "")
            {
                button19.BackColor = Color.FromArgb(eqBgrdR, eqBgrdG, eqBgrdB);
                button19.FlatAppearance.BorderColor = Color.FromArgb(eqBgrdR, eqBgrdG, eqBgrdB);
            }
            else
            {
                button19.BackColor = Color.FromName(eqBgrd);
                button19.FlatAppearance.BorderColor = Color.FromName(eqBgrd);
            }

            label1.ForeColor = Color.FromName(lbl);
            label2.ForeColor = Color.FromName(lbl);
            label3.ForeColor = Color.FromName(lbl);
            label4.ForeColor = Color.FromName(lbl);
            label5.ForeColor = Color.FromName(lbl);
            label6.ForeColor = Color.FromName(lbl);
            label7.ForeColor = Color.FromName(lbl);
            label8.ForeColor = Color.FromName(lbl);
            label9.ForeColor = Color.FromName(lbl);
            label10.ForeColor = Color.FromName(lbl);
            label11.ForeColor = Color.FromName(lbl);
            label13.ForeColor = Color.FromName(lbl);
            label14.ForeColor = Color.FromName(lbl);
            label15.ForeColor = Color.FromName(lbl);
            label16.ForeColor = Color.FromName(lbl);
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (binaryCount)
            {
                binaryCount = false;

                button28.Text = "Bin";

                button14.Enabled = true;
                button15.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button17.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button12.Enabled = true;
                buttonPlMin.Enabled = true;
                button11.Enabled = true;
            } 
            else
            {
                binaryCount = true;

                button28.Text = "Dec";

                button14.Enabled = false;
                button15.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button17.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
                button12.Enabled = false;
                buttonPlMin.Enabled = false;
                button11.Enabled = false;
            }
        }

        private void светлаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorClass.setColor("white");

            colorForm("InactiveBorder", 0, 0, 0, "ButtonHighlight", 0, 0, 0, BorderStyle.None, "WindowText",
                    0, 0, 0, "GradientInactiveCaption", 0, 0, 0, "GradientInactiveCaption", "ControlText", "GradientActiveCaption", 0, 0, 0, "", 64, 64, 64, "ControlText");

            светлаяToolStripMenuItem.Checked = true;
            темнаяToolStripMenuItem.Checked = false;
            цветнаяToolStripMenuItem.Checked = false;
        }

        private void темнаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorClass.setColor("black");

            colorForm("", 64, 64, 64, "WindowFrame", 0, 0, 0, BorderStyle.None, "White", 0, 0, 0, "Black",
                    0, 0, 0, "Black", "ButtonFace", "DimGray", 64, 64, 64, "", 64, 64, 64, "ButtonFace");

            светлаяToolStripMenuItem.Checked = false;
            темнаяToolStripMenuItem.Checked = true;
            цветнаяToolStripMenuItem.Checked = false;
        }

        private void цветнаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorClass.setColor("colorful");

            colorForm("", 255, 255, 192, "", 255, 192, 128, BorderStyle.None, "", 128, 64, 0, "",
                    255, 128, 128, "Red", "White", "Red", 0, 0, 0, "Red", 0, 0, 0, "Maroon");

            светлаяToolStripMenuItem.Checked = false;
            темнаяToolStripMenuItem.Checked = false;
            цветнаяToolStripMenuItem.Checked = true;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            string res;
            if (memory.ToString().Length > 8)
            {
                MessageBox.Show("Ваше число выходит за заданный диапазон. Простите, но я маленький калькулятор " +
                    ":с. Поэтому я выведу первые 8 символов. \nВ памяти это число хранится полностью: " + memory.ToString());

                res = memory.ToString();
                if(res[7] == ',')
                {
                    res = res.Remove(7);
                }
            }
            else
            {
                res = memory.ToString();
            }
            
            textBox1.Text = res;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            double number = Double.Parse(textBox1.Text);
            double newNumber = number / 100;

            textBox1.Text = newNumber.ToString();

            history = number.ToString() + "% = " + newNumber;
            HistoryList.setList(history);
            history = "";
            Stack<String> list = HistoryList.getList();
        }

        private void историяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistoryForm historyForm = new HistoryForm();
            historyForm.Show();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            double number = Double.Parse(textBox1.Text);
            memory -= number;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            memory = 0;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            double number = Double.Parse(textBox1.Text);
            memory += number;
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

        private void equals_Click(object sender, EventArgs e)
        {
            if (operation != "")
            {
                string result;
                num2 = Double.Parse(textBox1.Text);
                history = num1.ToString() + " " + operation + " " + num2.ToString();

                if (binaryCount)
                {
                    result = calculateBinary(num1.ToString(), num2.ToString());
                }
                else
                {
                    if (operation == "÷" && num2 == 0)
                    {
                        result = "ОШИБКА";
                    }
                    else
                    {
                        result = calculate().ToString();
                    }
                }

                if(result.Length > 8)
                {
                    MessageBox.Show("Ваше число выходит за заданный диапазон. Простите, но я маленький калькулятор " +
                        "и не могу это посчитать :с. Поэтому я выведу первые 8 символов. \nА вот число полностью: " + result.ToString());

                    result = result.Remove(8);

                    if(result[7] == ',')
                    {
                        result = result.Remove(7);
                    }
                }

                history += " = " + result;
                HistoryList.setList(history);
                textBox1.Text = result.ToString();
                history = "";
                operation = "";

                Stack<String> list = HistoryList.getList();
            }
        }

        private string calculateBinary(string num1, string num2)
        {
            string result = "";
            int s = 0;

            int i = num1.Length - 1, j = num2.Length - 1;
            while (i >= 0 || j >= 0 || s == 1)
            {

                s += ((i >= 0) ? num1[i] - '0' : 0);
                s += ((j >= 0) ? num2[j] - '0' : 0);

                result = (char)(s % 2 + '0') + result;

                s /= 2;

                i--; j--;
            }
            return result;
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
                    {
                        return Math.Round(num1 / num2, 7, MidpointRounding.AwayFromZero);
                    }
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
    }
}
