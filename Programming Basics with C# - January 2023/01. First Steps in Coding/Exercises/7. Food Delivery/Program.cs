using System;

namespace _07._Food_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int chicken = int.Parse(Console.ReadLine());
            int fish = int.Parse(Console.ReadLine());
            int vegan = int.Parse(Console.ReadLine());
            
            double chickenPrice = chicken * 10.35;
            double fishPrice = fish * 12.4;
            double veganPrice = vegan * 8.15;
            
            double sum = chickenPrice + fishPrice + veganPrice;
            double dessert = sum * 0.2;
            double delivery = 2.5;
            double all = sum + dessert + delivery;
            
            Console.WriteLine(all);
        }
    }
}
