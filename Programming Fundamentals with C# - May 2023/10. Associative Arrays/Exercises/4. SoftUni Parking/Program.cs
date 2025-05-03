using System;
using System.Collections.Generic;

namespace _4._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> carsInParking =
                new Dictionary<string, string>();
            int commandsCount = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < commandsCount; i++)
            {
                string[] commands = Console.ReadLine().Split();
                string username = commands[1];
                
                if (commands[0] == "register")
                {
                    string licensePlateNumber = commands[2];
                    if (!carsInParking.ContainsKey(username))
                    {
                        carsInParking.Add(username, licensePlateNumber);
                        Console.WriteLine($"{username} registered {licensePlateNumber} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {carsInParking[username]}");
                    }
                }
                else if (commands[0] == "unregister")
                {
                    if (!carsInParking.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                    else
                    {
                        carsInParking.Remove(username);
                        Console.WriteLine($"{username} unregistered successfully");
                    }
                }
            }

            foreach (var car in carsInParking)
            {
                Console.WriteLine($"{car.Key} => {car.Value}");
            }
        }
    }
}
