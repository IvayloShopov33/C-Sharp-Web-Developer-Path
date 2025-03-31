using System;

namespace _02.MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rooms = Console.ReadLine().Split('|');
            int health = 100;
            int bitcoins = 0;
            string[] room;
            
            for (int i = 0; i < rooms.Length; i++)
            {
                room = rooms[i].Split();
                if (room[0] == "potion")
                {
                    int hp = int.Parse(room[1]);
                    health += hp;
                    
                    if (health > 100)
                    {
                        int difference = health - hp;
                        hp = 100 - difference;
                        health = 100;                      
                    }
                    
                    Console.WriteLine($"You healed for {hp} hp.");
                    Console.WriteLine($"Current health: {health} hp.");
                }
                else if (room[0] == "chest")
                {
                    int bitcoinsInTheRoom = int.Parse(room[1]);
                    bitcoins += bitcoinsInTheRoom;
                    Console.WriteLine($"You found {bitcoinsInTheRoom} bitcoins.");
                }
                else
                {
                    int strength = int.Parse(room[1]);
                    health -= strength;
                    
                    if (health <= 0)
                    {
                        Console.WriteLine($"You died! Killed by {room[0]}.");
                        Console.WriteLine($"Best room: {i+1}");
                        
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"You slayed {room[0]}.");
                    }
                }
            }

            Console.WriteLine("You've made it!");
            Console.WriteLine($"Bitcoins: {bitcoins}");
            Console.WriteLine($"Health: {health}");
        }
    }
}
