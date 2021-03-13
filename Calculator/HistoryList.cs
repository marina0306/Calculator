using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    static class HistoryList
    {
        private static Stack<String> history = new Stack<String>();

        public static Stack<String> getList()
        {
            return history;
        }

        public static void setList(String str)
        {
            history.Push(str);
        }
    }
}
