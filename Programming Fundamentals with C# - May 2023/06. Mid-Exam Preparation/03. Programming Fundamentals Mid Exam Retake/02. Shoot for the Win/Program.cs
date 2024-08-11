using System;
using System.Linq;

namespace _02._Shoot_for_the_Win
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string input = Console.ReadLine();
            int shots = 0;
            while (input!="End")
            {
                int targetIndex = int.Parse(input);
                if (targetIndex>=0 && targetIndex<targets.Length && targets[targetIndex]!=-1)
                {
                    shots++;
                    int targetNumber = targets[targetIndex];
                    targets[targetIndex] = -1;
                    for (int i = 0; i < targets.Length; i++)
                    {
                        if (i!=targetIndex && targets[i]!=-1)
                        {
                            if (targets[i]>targetNumber)
                            {
                                targets[i] -= targetNumber;
                            }
                            else
                            {
                                targets[i] += targetNumber;
                            }
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Shot targets: {shots} -> {string.Join(' ', targets)}");
        }
    }
}
