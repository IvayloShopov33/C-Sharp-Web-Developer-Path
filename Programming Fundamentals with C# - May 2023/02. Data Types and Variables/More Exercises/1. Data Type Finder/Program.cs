using System;

namespace _1._Data_Type_Finder_exception
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int integer;
            float floater;
            bool flag;
            char ch;
            while (input!="END")
            {
                if (int.TryParse(input, out integer))
                    Console.WriteLine($"{input} is integer type");
                else if (float.TryParse(input, out floater))
                    Console.WriteLine($"{input} is floating point type");
                else if (bool.TryParse(input, out flag))
                    Console.WriteLine($"{input} is boolean type");
                else if (char.TryParse(input, out ch))
                    Console.WriteLine($"{input} is character type");
                else
                    Console.WriteLine($"{input} is string type");
                input = Console.ReadLine();
            }
        }
    }
}
