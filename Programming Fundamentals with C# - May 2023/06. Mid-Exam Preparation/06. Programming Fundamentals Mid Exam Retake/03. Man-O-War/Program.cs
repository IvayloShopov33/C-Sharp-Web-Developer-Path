using System;
using System.Linq;

namespace _03._Man_O_War
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] pirateShip = Console.ReadLine().Split('>').Select(int.Parse).ToArray();
            int[] warship = Console.ReadLine().Split('>').Select(int.Parse).ToArray();
            int maxHealthCapacity = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split();
            bool gameOver = false;
            while (input[0] != "Retire")
            {
                if (input[0] == "Fire" && !gameOver)
                {
                    int index = int.Parse(input[1]);
                    if (index >= 0 && index < warship.Length)
                    {
                        int damage = int.Parse(input[2]);
                        warship[index] -= damage;
                        if (warship[index] <= 0)
                        {
                            Console.WriteLine("You won! The enemy ship has sunken.");
                            gameOver = true;
                            break;
                        }
                    }
                }

                else if (input[0] == "Defend" && !gameOver)
                {
                    int startIndex = int.Parse(input[1]);
                    int endIndex = int.Parse(input[2]);
                    if ((startIndex >= 0 && startIndex < pirateShip.Length) &&
                        (endIndex >= 0 && endIndex < pirateShip.Length))
                    {
                        int damage = int.Parse(input[3]);
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            pirateShip[i] -= damage;
                            if (pirateShip[i] <= 0)
                            {
                                Console.WriteLine("You lost! The pirate ship has sunken.");
                                gameOver = true;
                                break;
                            }
                        }
                    }
                }

                else if (input[0] == "Repair" && !gameOver)
                {
                    int index = int.Parse(input[1]);
                    if (index >= 0 && index < pirateShip.Length)
                    {
                        int health = int.Parse(input[2]);
                        pirateShip[index] += health;
                        if (pirateShip[index] > maxHealthCapacity)
                        {
                            pirateShip[index] = maxHealthCapacity;
                        }
                    }
                }

                else if (input[0] == "Status" && !gameOver)
                {
                    int count = 0;
                    double minimumHealth = 0.2 * maxHealthCapacity;
                    for (int i = 0; i < pirateShip.Length; i++)
                    {
                        if (pirateShip[i]<minimumHealth)
                        {
                            count++;
                        }
                    }

                    Console.WriteLine($"{count} sections need repair.");
                }

                input = Console.ReadLine().Split();
            }

            if (!gameOver)
            {
                int pirateShipSum = pirateShip.Sum();
                int warshipSum = warship.Sum();
                Console.WriteLine($"Pirate ship status: {pirateShipSum}");
                Console.WriteLine($"Warship status: {warshipSum}");
            }
        }
    }
}
