using System;

namespace _01.Clock
{
    class Program
    {
        static void Main(string[] args)
        {
           for (int h=0;h<=23;h++) //върти се 24 пъти
            {
                for (int m=0;m<=59;m++) //върти се 24*60 пъти
                {
                   for (int s=0; s<=59;s++) //върти се 24*60*60 пъти
                    {
                        Console.WriteLine($"{h}:{m}:{s}");
                    }
                }
            }
        }
    }
}
