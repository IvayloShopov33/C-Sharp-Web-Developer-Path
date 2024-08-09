using System;

namespace _5_task
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int mostGoals=0;
            string topScorer=string.Empty;

            while (name != "END")
            {
                int goals = int.Parse(Console.ReadLine());

                if (goals > mostGoals)
                {
                    topScorer = name;
                    mostGoals = goals;
                }

                if (goals >= 10)
                {
                    break;
                }              

                name = Console.ReadLine();            
            }

            Console.WriteLine($"{topScorer} is the best player!");

            if (mostGoals >= 3)
            { 
                Console.WriteLine($"He has scored {mostGoals} goals and made a hat-trick !!!"); 
            }
            else
            { 
                Console.WriteLine($"He has scored {mostGoals} goals."); 
            }

        }
    }
}
