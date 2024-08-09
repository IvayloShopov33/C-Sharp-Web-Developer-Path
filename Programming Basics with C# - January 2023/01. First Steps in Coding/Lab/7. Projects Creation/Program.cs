using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int numberproject = int.Parse(Console.ReadLine());
            int necessaryhour = numberproject * 3;
            Console.WriteLine($"The architect {name} will need {necessaryhour} hours to complete {numberproject} project/s.");
        }
    }
}
