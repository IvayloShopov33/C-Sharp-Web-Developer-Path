using System;
using System.Linq;

namespace _03._The_Angry_Cat
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] priceRatings = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int entryPoint = int.Parse(Console.ReadLine());
            string typeOfItems = Console.ReadLine();
            
            int entryPointItem = priceRatings[entryPoint];
            int sumOfPriceOnTheLeft = 0;
            int sumOfPriceOnTheRight = 0;

            if (typeOfItems == "cheap")
            {
                for (int i = 0; i < entryPoint; i++)
                {
                    if (priceRatings[i] < entryPointItem)
                    {
                        sumOfPriceOnTheLeft += priceRatings[i];
                    }
                }

                for (int i = entryPoint+1; i < priceRatings.Length; i++)
                {
                    if (priceRatings[i] < entryPointItem)
                    {
                        sumOfPriceOnTheRight += priceRatings[i];
                    }
                }
            }
            else if (typeOfItems == "expensive")
            {
                for (int i = 0; i < entryPoint; i++)
                {
                    if (priceRatings[i] >= entryPointItem)
                    {
                        sumOfPriceOnTheLeft += priceRatings[i];
                    }
                }

                for (int i = entryPoint + 1; i < priceRatings.Length; i++)
                {
                    if (priceRatings[i] >= entryPointItem)
                    {
                        sumOfPriceOnTheRight += priceRatings[i];
                    }
                }
            }

            if (sumOfPriceOnTheLeft >= sumOfPriceOnTheRight)
            {
                Console.WriteLine($"Left - {sumOfPriceOnTheLeft}");
            }          
            else
            {
                Console.WriteLine($"Right - {sumOfPriceOnTheRight}");
            }
        }
    }
}
