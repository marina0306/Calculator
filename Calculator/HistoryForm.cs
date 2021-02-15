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
    public partial class HistoryForm : Form
    {
        public HistoryForm()
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
                case "2СС/10CC":
                    Conversion conversion = new Conversion();
                    this.Dispose();
                    conversion.ShowDialog();
                    break;
            }
        }
    }
}
