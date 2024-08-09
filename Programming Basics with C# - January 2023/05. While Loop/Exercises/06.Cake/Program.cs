using System;

namespace _06.Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int pieceAmount = length * width;
            while (input!="STOP")
            {
                int pieceTaken = int.Parse(input);
                if (pieceTaken<pieceAmount)
                {
                    pieceAmount -= pieceTaken;
                    input = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine($"No more cake left! You need {Math.Abs(pieceAmount-pieceTaken)} pieces more.");
                    break;
                }
            }
            if (input=="STOP")
            {
                Console.WriteLine($"{pieceAmount} pieces are left.");
            }
            
        }
    }
}
