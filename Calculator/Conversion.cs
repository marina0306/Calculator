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
    public partial class Conversion : Form
    {

        ConverterDeAndBi converterDeAndBi = new ConverterDeAndBi();
        public Conversion()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedState = comboBox2.SelectedItem.ToString();
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
                case "Решение квадратных уравнений":
                    QuadrForm quadrForm = new QuadrForm();
                    this.Dispose();
                    quadrForm.ShowDialog();
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string selectedState = comboBox1.SelectedItem.ToString();
                int i;
                if (textBox1.Text != "")
                {
                    switch (selectedState)
                    {
                        case "Двоичная":
                            textBox2.Text = converterDeAndBi.binaryToDecimal(textBox1.Text, textBox1.Text.Length).ToString();
                            break;
                        case "Десятичная":
                            textBox2.Text = converterDeAndBi.ConvertTo2(textBox1.Text);
                            break;

                    }
                }
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



    }
}
