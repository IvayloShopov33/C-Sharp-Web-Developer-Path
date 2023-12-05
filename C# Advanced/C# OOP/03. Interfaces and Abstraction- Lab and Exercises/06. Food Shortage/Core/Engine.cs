using FoodShortage.Core.Interfaces;
using FoodShortage.Models;
using FoodShortage.Models.Interfaces;

namespace FoodShortage.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            List<IBuyer> buyers = new List<IBuyer>();

            int peopleCount = int.Parse(Console.ReadLine());
            for (int i = 1; i <= peopleCount; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input.Length == 4)
                {
                    IBuyer citizen = new Citizen(input[0], int.Parse(input[1]), input[2], input[3]);
                    buyers.Add(citizen);
                }
                else if (input.Length == 3)
                {
                    IBuyer rebel = new Rebel(input[0], int.Parse(input[1]), input[2]);
                    buyers.Add(rebel);
                }
            }

            string buyerName = string.Empty;
            while (true)
            {
                buyerName = Console.ReadLine();
                if (buyerName == "End")
                {
                    break;
                }

                IBuyer buyer = buyers.FirstOrDefault(x => x.Name == buyerName);
                if (buyer != null)
                {
                    buyer.BuyFood();
                }
            }

            int totalboughtFood = buyers.Select(x => x.Food).Sum();
            Console.WriteLine(totalboughtFood);
        }
    }
}
