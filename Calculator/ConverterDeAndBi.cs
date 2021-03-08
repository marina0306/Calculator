using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class ConverterDeAndBi
    {


        //Привет! Я класс, который отвечаед за переводы счисления. Я маленький, спизженный из кусочков, но хороший и трудолюбивый. 
        //А самое главное, я умею работать с дробными числами. 
        //Используй ConvertTo2 если надо перевести из двоичной системы в десятичную
        //И binaryToDecima если наоборот. (2 число это длинна строки двочного числа) 
        //Будь акуратен работая со мной, потому что я не различаю точку и запятую. Используй запятую, работая со мной, пожалуйста. 


        public string ConvertTo2(string num, int round = 5)
        {
            string result = ""; //Результат
            int left = 0; //Целая часть
            int right = 0; //Дробная часть
            string[] temp1 = num.Split(new char[] { '.', ',' }); //Нужна для разделения целой и дробной частей
            left = Convert.ToInt32(temp1[0]);
            //Проверяем имеется ли у нас дробная часть
            if (temp1.Count() > 1)
            {
                right = Convert.ToInt32(num.Split(new char[] { '.', ',' })[1]); //Дробная часть
            }
            //Алгоритм перевода целой части в двоичную систему
            while (true)
            {
                result += left % 2; //В ответ помещаем остаток от деления. В конце программы мы перевернём строку, так как в обратном порядке записываются остатки
                left = left / 2; //Так как Left целое число, то при делении например числа 2359 на 2, мы получим не 1179,5 а 1179
                if (left == 0)
                    break;
            }
            result = new string(result.ToCharArray().Reverse().ToArray()); //Реверсирование строки
            /*Не углублялся в ситуацию, но вдруг при реверсе появятся первые символы нули, а ведь их мы не пишем!
            Не знаю есть ли необходимость в этом цикле */
            while (true)
            {
                int i = 0;
                if (result[i] == '0')
                    result = result.Remove(i, 1);
                else break;
            }
            //Прокеряем есть ли у нас дробная часть, можно было бы проверить и так if(temp1.count()>1)
            if (right == 0)
                return result;

            //Добавляем разделить целой части от дробной
            result += '.';

            int count = right.ToString().Count(); // Нам нужно знать кол-во цифр, при превышении которого дописывается единичка

            for (int i = 0; i < round; i++)
            {
                /*Умножаем число на 2 и проверяем, стало ли оно больше по количеству цифр, если да,
                то в результат идёт "1" и первая цифра у right удаляется */
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
