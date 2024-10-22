using System;

namespace _06._Oscars
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameActor = Console.ReadLine();
            double points = double.Parse(Console.ReadLine());
            int assessmenterQuantity = int.Parse(Console.ReadLine());
            
            string assessmenterName;
            double assessmenterPoints=0.0;
            int length;
            double finalPoints = 0.0;
            
            for (int i = 1; i <= assessmenterQuantity; i++)
            {
                assessmenterName = Console.ReadLine();
                assessmenterPoints = double.Parse(Console.ReadLine());
                
                length = assessmenterName.Length;
                finalPoints = points + ((length * assessmenterPoints) / 2);
                points = finalPoints;
                
                if (finalPoints > 1250.5)
                {
                    Console.WriteLine($"Congratulations, {nameActor} got a nominee for leading role with {finalPoints:F1}!");
                    break;
                }
            }
            
            if (finalPoints <= 1250.5)              
                Console.WriteLine($"Sorry, {nameActor} you need {1250.5 - finalPoints:F1} more!");
        }
    }
}
