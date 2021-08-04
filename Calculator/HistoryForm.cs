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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            color(ColorClass.getColor());
            Stack<String> list = HistoryList.getList();
            foreach(String str in list)
            {
                textBox1.Text += str + Environment.NewLine;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void color(string color)
        {
            if(color == "white")
            {
                coloring("InactiveBorder", "ControlText", "ButtonHighlight", "WindowText", 0, 0, 0, 0, 0, 0, 0, 0, 0);
            }
            else if (color == "black")
            {
                coloring("", "ButtonFace", "WindowFrame", "White", 64, 64, 64, 0, 0, 0, 0, 0, 0);
            }
            else if (color == "colorful")
            {
                coloring("", "Maroon", "", "", 255, 255, 192, 255, 192, 128, 128, 64, 0);
            }
        }

        private void coloring(string bgrd, string lbl, string txtbx, string txt, int bgrdR, int bgrdG, int bgrdB,
            int txtbxR, int txtbxG, int txtbxB, int txtR, int txtG, int txtB)
        {
            if (bgrd == "")
            {
                BackColor = Color.FromArgb(bgrdR, bgrdG, bgrdB);
            }
            else
            {
                BackColor = Color.FromName(bgrd);
            }

            label1.ForeColor = Color.FromName(lbl);

            if (txtbx == "")
            {
                textBox1.BackColor = Color.FromArgb(txtbxR, txtbxG, txtbxB);
            }
            else
            {
                textBox1.BackColor = Color.FromName(txtbx);
            }

            if(txt == "")
            {
                textBox1.ForeColor = Color.FromArgb(txtR, txtG, txtB);
            }
            else
            {
                textBox1.ForeColor = Color.FromName(txt);
            }
        }
    }
}
