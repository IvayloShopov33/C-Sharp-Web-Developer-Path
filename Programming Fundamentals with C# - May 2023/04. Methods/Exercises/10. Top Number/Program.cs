using System;
using System.Linq;

namespace _10._Top_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            TopNumber(number);
        }
        static void TopNumber(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                int[] n = i.ToString().Select(o => Convert.ToInt32(o) - 48).ToArray();
                if (n.Sum()%8==0)
                {
                    for (int j = 0; j < n.Length; j++)
                    {
                        if (n[j]%2==1)
                        {
                            Console.WriteLine(i);
                            break;
                        }
                    }
                }
            }
        }
    }
}
