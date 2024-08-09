using System;

namespace _02._Equal_Sums_Even_Odd_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
           
            for (int num = first; num <= second; num++)
            {
                int oddSum=0;
                int evenSum=0;
                string currentNum = num.ToString(); //превръща числото в текст
                for (int digit = 0; digit <6; digit++)
                {
                    if (digit%2==0)
                        evenSum += currentNum[digit];
                    else
                        oddSum += currentNum[digit];
                }
                if (evenSum==oddSum)
                    Console.Write($"{num} ");
            }
        }
    }
}
