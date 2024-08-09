using System;

namespace Rock___Paper___Scissors
{
    class RockPaperScissors
    {
        static void Main(string[] args)
        {
            const string Rock = "Rock";
            const string Paper = "Paper";
            const string Scissors = "Scissors";
            Console.Write("Choose [r]ock, [p]aper pr [s]cissors: ");
            string playerMove = Console.ReadLine();
            if (playerMove == "r" || playerMove == "rock")
                playerMove = Rock;
            else if (playerMove == "p" || playerMove == "paper")
                playerMove = Paper;
            else if (playerMove == "s" || playerMove == "scissors")
                playerMove = Scissors;
            else
            {
                Console.WriteLine("Invalid input. Try again....");
                return;
            }
            Random random = new Random();
            int computerRandomNumber = random.Next(1, 4);
            string computerMove = string.Empty;
            switch (computerRandomNumber)
            {
                case 1:
                    computerMove = "Rock";
                    break;
                case 2:
                    computerMove = "Paper";
                    break;
                case 3:
                    computerMove = "Scissors";
                    break;
            }
            Console.WriteLine($"The computer chose {computerMove}.");
            if ((playerMove=="Rock" && computerMove=="Scissors") ||
                (playerMove=="Paper" && computerMove=="Rock") ||
                (playerMove=="Scissors" && computerMove=="Paper"))
            {
                Console.WriteLine("You won.");
            }
            else if ((playerMove == "Scissors" && computerMove == "Rock") ||
                (playerMove == "Rock" && computerMove == "Paper") ||
                (playerMove == "Paper" && computerMove == "Scissors"))
            {
                Console.WriteLine("You lost.");
            }
            else
                Console.WriteLine("This game is a draw.");
        }
    }
}
