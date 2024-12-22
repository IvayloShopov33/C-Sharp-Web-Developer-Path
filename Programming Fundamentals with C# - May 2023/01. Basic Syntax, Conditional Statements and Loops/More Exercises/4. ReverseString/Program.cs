using System;
using System.Linq;

namespace _4.ReverseString_except
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            //string strReversed = string.Empty;
            //for (int i = str.Length - 1; i >= 0; i--)
            //{
            //    strReversed += str[i];
            //}
            //Console.WriteLine(strReversed);
            
            string str1 = new string (str.Reverse().ToArray());
            Console.WriteLine(str1);
        }
    }
}
