using System;

namespace _2._Bit_at_Position_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int p = 1;
            n = n >> p;
            Console.WriteLine(n&1);
        }
    }
}
