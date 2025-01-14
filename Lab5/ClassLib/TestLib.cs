using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassLib
{
    public class TestLib
    {
        public string Program1(string input)
        {
            return $"Program 1 result for input: {input}";
        }

        public string Program2(int number)
        {
            return $"Program 2 result: {number * 2}";
        }

        public string Program3(string text)
        {
            return $"Program 3 transformed text: {text.ToUpper()}";
        }
    }
}