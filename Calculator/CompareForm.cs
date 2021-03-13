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
    public partial class CompareForm : Form
    {

        ConverterDeAndBi converterDeAndBi = new ConverterDeAndBi();
        public CompareForm()
        {
            InitializeComponent();
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
                case "Решение квадратных уравнений":
                    QuadrForm quadrForm = new QuadrForm();
                    this.Dispose();
                    quadrForm.ShowDialog();
                    break;
                case "2СС/10CC":
                    Conversion conversion = new Conversion();
                    this.Dispose();
                    conversion.ShowDialog();
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null && textBox2.Text != null) {
                double a  = converterDeAndBi.binaryToDecimal(textBox2.Text, textBox2.Text.Length);
                double b = Double.Parse(textBox1.Text);
                if (a.Equals(b)) {
                    textBox3.Text = "Числа равны";
                }
                else
                    textBox3.Text = "Числа не равны";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
