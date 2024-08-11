using System;

namespace _01._Guinea_Pig
{
    class Program
    {
        static void Main(string[] args)
        {
            float food = float.Parse(Console.ReadLine());
            float hay = float.Parse(Console.ReadLine());
            float cover = float.Parse(Console.ReadLine());
            float weight = float.Parse(Console.ReadLine());
            food *= 1000;
            hay *= 1000;
            cover *= 1000;
            weight *= 1000;
            int days = 0;
            bool isEnough = false;
            while (food>0 && cover>0 && hay>0)
            {
                days++;
                if (days==31)
                {
                    isEnough = true;
                    break;
                }
                food -= 300;
                if (days%2==0)
                {
                    hay -= food * 0.05f;
                }
                if (days%3==0)
                {
                    cover -= weight / 3;
                }
            }
            if (isEnough)
            {
                food /= 1000;
                hay /= 1000;
                cover /= 1000;
                Console.WriteLine($"Everything is fine! Puppy is happy! Food: {food:f2}, Hay: {hay:f2}, Cover: {cover:f2}.");
            }
            else
            {
                Console.WriteLine("Merry must go to the pet store!");
            }
        }
    }
}
