using System;

namespace _9._Greater_of_Two_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            string valueType = Console.ReadLine();
            string value1 = Console.ReadLine();
            string value2 = Console.ReadLine();
            if (valueType=="int")
            {
                GetMaxInt(value1, value2);
            }
            else if (valueType=="string")
            {
                GetMaxString(value1, value2);
            }
            else if (valueType=="char")
            {
                GetMaxChar(value1, value2);
            }
        }
        static void GetMaxInt(string value1, string value2)
        {
            double value3 = double.Parse(value1);
            double value4 = double.Parse(value2);
            if (value3>value4)
                Console.WriteLine(value3);
            else if (value3<value4)
                Console.WriteLine(value4);
            else
                Console.WriteLine(value3);
        }
        static void GetMaxString(string value1, string value2)
        {
            
             if (string.Compare(value1, value2,true)==1)
            {
                Console.WriteLine(value1);
            }
            else
            {
                Console.WriteLine(value2);
            }
        }
        static void GetMaxChar (string value1, string value2)
        {
            char a = char.Parse(value1);
            char b = char.Parse(value2);
            if (a>b)
                Console.WriteLine(a);
            else if(b>a)
                Console.WriteLine(b);
            else
                Console.WriteLine(a);
        }
    }
}
