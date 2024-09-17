using System;

namespace _08._Lunch_Break
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameSeries = Console.ReadLine();
            int episodeDuration = int.Parse(Console.ReadLine());
            int lunchTime = int.Parse(Console.ReadLine());
            
            double timeForSeries = (double)lunchTime * 5 / 8;
            if (timeForSeries >= episodeDuration)
            {
                Console.WriteLine($"You have enough time to watch {nameSeries} and left with {Math.Ceiling(timeForSeries-episodeDuration)} minutes free time.");
            }
            else
            {
                Console.WriteLine($"You don't have enough time to watch {nameSeries}, you need {Math.Ceiling(episodeDuration-timeForSeries)} more minutes.");
            }
        }
    }
}
