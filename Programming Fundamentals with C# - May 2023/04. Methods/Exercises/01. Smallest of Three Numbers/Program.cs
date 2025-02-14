using System;

namespace _1._Smallest_of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            
            if (a <= b && a <= c)
                FirstIsTheSmallest(a, b, c);
            else if (b <= a && b <= c)
                SecondIsTheSmallest(a, b, c);
            else if (c <= a && c <= b)
                ThirdIsTheSmallest(a, b, c);
        }
        
        static void FirstIsTheSmallest(int a, int b, int c)
        {
            Console.WriteLine(a);
        }
        
        static void SecondIsTheSmallest(int a, int b, int c)
        {
            Console.WriteLine(b);
        }
        
        static void ThirdIsTheSmallest(int a, int b, int c)
        {
            Console.WriteLine(c);
        }
    }
}
