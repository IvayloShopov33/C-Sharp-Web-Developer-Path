using System;

namespace _2_task
{
    class Program
    {
        static void Main(string[] args)
        {
            double price = double.Parse(Console.ReadLine());

            int romanticNote = int.Parse(Console.ReadLine());
            int waxRose = int.Parse(Console.ReadLine());
            int keychain = int.Parse(Console.ReadLine());
            int caricature = int.Parse(Console.ReadLine());
            int luckySurprise = int.Parse(Console.ReadLine());

            double sum = romanticNote * 0.6 + waxRose * 7.2 + keychain * 3.6 + caricature * 18.2 + luckySurprise * 22;
            int sum1 = romanticNote + waxRose + keychain + caricature + luckySurprise;

            if (sum1 > 25)
            {
                sum -= sum * 0.35;
            }

            sum -= sum * 0.1;

            if (sum >= price)
            {
                Console.WriteLine($"Yes! {sum - price:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {price - sum:f2} lv needed.");
            }
        }
    }
}
