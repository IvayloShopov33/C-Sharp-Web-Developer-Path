using System;

namespace Guess_a_number
{
    class Program
    {
        static void Main(string[] args)
        {
            Random randomNumber = new Random();
            int computerNumber = randomNumber.Next(1, 101);
            int attempts = 10;
            
            while (true)
            {
                Console.Write("Guess a number (1-100): ");
                string playerInput = Console.ReadLine();
                
                bool isValid = int.TryParse(playerInput, out int playerNumber);
                attempts--;
                
                if (isValid)
                {
                    if (playerNumber == computerNumber)
                    {
                        Console.WriteLine("You guessed it!");
                        break;
                    }
                    else if (playerNumber > computerNumber)
                        Console.WriteLine("Too High");
                    else
                        Console.WriteLine("Too Low");
                }
                else
                    Console.WriteLine("Invalid input");
                
                if (attempts > 0)
                {
                    Console.WriteLine($"You have {attempts} left!");
                }
                else
                {
                    Console.WriteLine("You do not have any attempts left!");
                    Console.WriteLine("Game over!");
                    
                    break;
                }
            }
        }
    }
}
