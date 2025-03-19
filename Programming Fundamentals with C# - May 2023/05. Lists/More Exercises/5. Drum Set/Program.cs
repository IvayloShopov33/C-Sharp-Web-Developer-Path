using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Drum_Set
{
    class Program
    {
        static void Main(string[] args)
        {
            float money = float.Parse(Console.ReadLine());
            List<int> drumsQuality = Console.ReadLine().Split().Select(int.Parse).ToList();            
            List<int> drumsQualityCopy = drumsQuality.ToList();
            string input = Console.ReadLine();
            
            while (input != "Hit it again, Gabsy!")
            {
                int power = int.Parse(input);
                for (int i = 0; i < drumsQuality.Count; i++)
                {
                    drumsQuality[i] -= power;
                }
                
                for (int i = 0; i < drumsQualityCopy.Count; i++)
                {
                    if (drumsQuality[i] <= 0)
                    {
                        int indexNum = i;
                        float moneyForNewDrum = drumsQualityCopy[indexNum] * 3;
                        
                        if (moneyForNewDrum <= money)
                        {
                            money -= moneyForNewDrum;
                            drumsQuality[indexNum] = drumsQualityCopy[indexNum];
                        }
                    }
                }                      

                input = Console.ReadLine();
            }
            
            drumsQuality.RemoveAll(x => x <= 0);
            Console.WriteLine(string.Join(' ', drumsQuality));
            Console.WriteLine($"Gabsy has {money:f2}lv.");
        }
    }
}
