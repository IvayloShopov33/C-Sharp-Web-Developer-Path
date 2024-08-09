using System;

namespace _05._Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= 9; i++)
            {
                for (int k = 1; k <=9; k++)
                {
                    for (int l = 1; l  <= 9; l++)
                    {
                        for (int m = 1; m <=9; m++)
                        {
                            if (n%i==0 &&
                                n%k==0 &&
                                n%l==0 &&
                                n%m==0)
                                Console.Write($"{i}{k}{l}{m} ");
                        }
                    }
                }
            }
        }
    }
}
