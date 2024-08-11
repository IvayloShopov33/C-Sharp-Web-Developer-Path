using System;

namespace _1._Data_Types
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataType = Console.ReadLine();
            DataType(dataType);
        }
        static void DataType(string dataType)
        {
            if (dataType=="int")
            {
                int number = int.Parse(Console.ReadLine());
                Console.WriteLine(number*2);
            }
            else if (dataType=="real")
            {
                double number = double.Parse(Console.ReadLine());
                double result = number * 1.5;
                Console.WriteLine($"{result:f2}");
            }
            else if (dataType=="string")
            {
                string str = Console.ReadLine();
                string[] str1 = new string[str.Length + 2];
                str1[0] = "$";
                str1[str1.Length - 1] = "$";
                for (int i = 1; i < str1.Length-1; i++)
                {
                    str1[i] += str[i - 1];
                }
                for (int i = 0; i < str1.Length; i++)
                {
                    Console.Write(str1[i]);
                }
            }
        }
    }
}
