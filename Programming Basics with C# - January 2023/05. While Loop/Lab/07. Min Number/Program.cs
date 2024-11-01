using System;

namespace _07._Min_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int minNum = int.MaxValue;
            string input = Console.ReadLine();
            
            while (input != "Stop")
            {
                int num = int.Parse(input);
                if (num < minNum)
                {
                    minNum = num;
                }
                
                input = Console.ReadLine();
            }
            
            Console.WriteLine(minNum);
        }
    }
}
