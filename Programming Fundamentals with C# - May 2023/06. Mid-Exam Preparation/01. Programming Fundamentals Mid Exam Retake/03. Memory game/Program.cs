using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Memory_game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> cards = Console.ReadLine().Split().ToList();
            string[] input = Console.ReadLine().Split();
            int moves = 0;
            bool finish = false;
            while (input[0] != "end")
            {
                int index1 = int.Parse(input[0]);
                int index2 = int.Parse(input[1]);
                moves++;
                if ((index1 == index2) || (index1 < 0 || index1 >= cards.Count) || index2 < 0 || (index2 >= cards.Count))
                {
                    string element1 = $"-{moves}a";
                    string element2 = element1;
                    if (cards.Count % 2 == 1)
                    {
                        cards.Insert((cards.Count - 1) / 2, element1);
                        cards.Insert((cards.Count - 1) / 2, element2);
                    }
                    else
                    {
                        cards.Insert(cards.Count / 2, element1);
                        cards.Insert(cards.Count / 2, element2);
                    }
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                }

                else
                {
                    if (cards[index1] == cards[index2])
                    {
                        Console.WriteLine($"Congrats! You have found matching elements - {cards[index1]}!");
                        if (index1 > index2)
                        {
                            cards.RemoveAt(index2);
                            cards.RemoveAt(index1 - 1);
                        }

                        else
                        {
                            cards.RemoveAt(index1);
                            cards.RemoveAt(index2 - 1);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Try again!");
                    }

                }

                if (cards.Count == 0)
                {
                    Console.WriteLine($"You have won in {moves} turns!");
                    finish = true;
                    break;
                }

                input = Console.ReadLine().Split();
            }

            if (!finish)
            {
                Console.WriteLine("Sorry you lose :(");
                Console.WriteLine(string.Join(' ', cards));
            }
        }
    }
}
