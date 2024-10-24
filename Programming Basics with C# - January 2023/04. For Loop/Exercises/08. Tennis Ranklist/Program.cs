using System;

namespace _08._Tennis_Ranklist
{
    class Program
    {
        static void Main(string[] args)
        {
            int tournaments = int.Parse(Console.ReadLine());
            int initialPoints = int.Parse(Console.ReadLine());
            
            string stage;
            int points1 = 0;
            int points2 = 0;
            int points3 = 0;
            int points = 0;
            int p1 = 0;
            int p2 = 0;
            int p3 = 0;
            
            for (int i = 1; i <= tournaments; i++)
            {
                stage = Console.ReadLine();
                if (stage == "F")
                {
                    points1 =  1200;
                    p1++;
                }
                else if (stage == "W")
                {
                    points2 = 2000;
                    p2++;
                }
                else if (stage == "SF")
                {
                    points3 = 720;
                    p3++;
                }
                
                points = initialPoints + points1 * p1 + points2 * p2 + points3 * p3;
            }
            
            double average = (points1 * p1 + points2 * p2 + points3 * p3) / tournaments;
            double percentWin = (double)p2 / tournaments * 100;
            
            Console.WriteLine($"Final points: {points}");
            Console.WriteLine($"Average points: {Math.Floor(average)}");
            Console.WriteLine($"{percentWin:f2}%");
        }
    }
}
