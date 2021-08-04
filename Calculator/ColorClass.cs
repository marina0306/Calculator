using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    static class ColorClass
    {
        private static string color = "white";

        public static string getColor()
        {
            return color;
        }

        public static void setColor(string col)
        {
            color = col;
        }
    }
}
