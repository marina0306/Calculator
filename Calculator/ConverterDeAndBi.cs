using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class ConverterDeAndBi
    {
        public string ConvertTo2(string num, int round = 5)
        {
            string result = ""; 
            int left = 0; 
            int right = 0; 
            string[] temp1 = num.Split(new char[] { '.', ',' });
            left = Convert.ToInt32(temp1[0]);
            if (temp1.Count() > 1)
            {
                right = Convert.ToInt32(num.Split(new char[] { '.', ',' })[1]); 
            }

            while (true)
            {
                result += left % 2;
                left = left / 2;
                if (left == 0)
                    break;
            }
            result = new string(result.ToCharArray().Reverse().ToArray()); 
            while (true)
            {
                int i = 0;
                if (result[i] == '0')
                    result = result.Remove(i, 1);
                else break;
            }
            if (right == 0)
                return result;

            result += '.';

            int count = right.ToString().Count(); 

            for (int i = 0; i < round; i++)
            {
                right = right * 2;
                if (right.ToString().Count() > count)
                {
                    string buf = right.ToString();
                    buf = buf.Remove(0, 1);
                    right = Convert.ToInt32(buf);

                    result += '1';
                }
                else
                {
                    result += '0';
                }
            }
            return result;
        }



        public  double binaryToDecimal(string binary, int len)
        {

            // Fetch the radix point 
            int point = binary.IndexOf(',');

            // Update point if not found 
            if (point == -1)
                point = len;

            double intDecimal = 0,
                   fracDecimal = 0,
                   twos = 1;

            // Convert integral part of binary to decimal 
            // equivalent 
            for (int i = point - 1; i >= 0; i--)
            {
                intDecimal += (binary[i] - '0') * twos;
                twos *= 2;
            }

            // Convert fractional part of binary to 
            // decimal equivalent 
            twos = 2;
            for (int i = point + 1; i < len; i++)
            {
                fracDecimal += (binary[i] - '0') / twos;
                twos *= 2.0;
            }

            // Add both integral and fractional part 
            return intDecimal + fracDecimal;
        }
    }
}
